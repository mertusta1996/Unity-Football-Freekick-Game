using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FreekickCore : MonoBehaviour
{
    [Header("Ball")]
    public Rigidbody ball;
    public AudioSource shootAudioSource;
    public AudioClip shootAudioClip;
    
    [Header("UI")]
    public RectTransform ballHitPos;
    public Slider shootSlider;
    public TrajectoryLineRenderer trajectoryLineRenderer;
    public GameObject ballHitCanvas, directionCanvas, freekickPositionSelectionPanel, freekickSettingPanel, freekickCompletedPanel;
    public TextMeshProUGUI ballDistanceText;

    [Header("Freekick Positions")] 
    public Transform freekickPoint;
    public Transform farTarget, nearTarget, goalCenter;
    
    private float _power;
    private const float XMin = -4.5f, XMax = 4.5f, ZMin = -4f, ZMax = 4f, BallHitPosRadius = 0.435f;
    private Vector3 _farTargetLocalPos, _nearTargetLocalPos;
    private bool _isUnavailableForNewFreekick, _isShooting, _isBallHit, _isSetShootSlider;
    private bool _isRightKickAngle, _isLeftKickAngle;
    private bool _isForwardFreekickPosition, _isBackFreekickPosition, _isRightFreekickPosition, _isLeftFreekickPosition;
    private bool _isUpBallHitPos, _isDownBallHitPos, _isRightBallHitPos, _isLeftBallHitPos;

    private void Awake()
    {
        _farTargetLocalPos = farTarget.localPosition;
        _nearTargetLocalPos = nearTarget.localPosition;
    }

    private void Update()
    {
        if (!_isUnavailableForNewFreekick && Input.GetKeyDown(KeyCode.Return)) NewFreekickCreate();
        _isRightKickAngle = !_isBallHit && Input.GetKey(KeyCode.RightArrow);
        _isLeftKickAngle = !_isBallHit && Input.GetKey(KeyCode.LeftArrow);
        _isForwardFreekickPosition = !_isShooting && Input.GetKey(KeyCode.W);
        _isBackFreekickPosition = !_isShooting && Input.GetKey(KeyCode.S);
        _isRightFreekickPosition = !_isShooting && Input.GetKey(KeyCode.D);
        _isLeftFreekickPosition = !_isShooting && Input.GetKey(KeyCode.A);

        // Set Freekick UI.
        if (_isShooting == false)
        {
            SetNewFreekickUI();
        }
        else if (directionCanvas.activeSelf)
        {
            directionCanvas.SetActive(false);
        }

        if (_isShooting)
        {
            if (!_isBallHit)
            {
                if (!ballHitCanvas.activeSelf) ballHitCanvas.SetActive(true);
                if (!trajectoryLineRenderer.gameObject.activeSelf) trajectoryLineRenderer.gameObject.SetActive(true);
                SetInstructionPanels(false, true, false);

                // Set New Freekick Shoot Ball Hit Pos.
                _isUpBallHitPos = Input.GetKey(KeyCode.W);
                _isDownBallHitPos = Input.GetKey(KeyCode.S);
                _isRightBallHitPos = Input.GetKey(KeyCode.D);
                _isLeftBallHitPos = Input.GetKey(KeyCode.A);

                var ballHitPosLocal = ballHitPos.localPosition;
                var distance = Vector3.Distance(ballHitPosLocal, Vector3.zero);

                var fromOriginToObject = ballHitPosLocal - Vector3.zero;
                if (distance > BallHitPosRadius)
                {
                    fromOriginToObject *= BallHitPosRadius / distance;
                    ballHitPos.localPosition = Vector3.zero + fromOriginToObject;
                }

                // Set Freekick Curve Settings.
                ballHitPosLocal = ballHitPos.localPosition;
                farTarget.localPosition = new Vector3(_farTargetLocalPos.x - ballHitPosLocal.x * 20f, _farTargetLocalPos.y - ballHitPosLocal.y * 5f, _farTargetLocalPos.z);
                nearTarget.localPosition = new Vector3(_nearTargetLocalPos.x - ballHitPosLocal.x * 0.5f, _nearTargetLocalPos.y - ballHitPosLocal.y * 0.5f, _nearTargetLocalPos.z);
                trajectoryLineRenderer.CreateTrajectoryLine(ball.transform, nearTarget, farTarget);
                trajectoryLineRenderer.transform.position = Vector3.zero;

                // Shoot Freekick.
                _isSetShootSlider = Input.GetKey(KeyCode.Space);

                if (!Input.GetKeyUp(KeyCode.Space)) return;
                ShootToTargets();
                StartCoroutine(WaitForResetShootSlider());
            }
            else
            {
                if (ballHitCanvas.activeSelf) ballHitCanvas.SetActive(false);
                if (trajectoryLineRenderer.gameObject.activeSelf) trajectoryLineRenderer.gameObject.SetActive(false);
            }
        }
    }

    private void FixedUpdate()
    {
        if(_isRightKickAngle) SetKickAngle(1);
        if(_isLeftKickAngle) SetKickAngle(-1);
        if(_isForwardFreekickPosition) TranslateFreekickPointWithInput(Vector3.forward);
        if(_isBackFreekickPosition) TranslateFreekickPointWithInput(-Vector3.forward);
        if(_isRightFreekickPosition) TranslateFreekickPointWithInput(Vector3.right);
        if(_isLeftFreekickPosition) TranslateFreekickPointWithInput(-Vector3.right);
        if(_isUpBallHitPos) ballHitPos.Translate(Vector3.up * (0.2f * Time.fixedDeltaTime));
        if(_isDownBallHitPos) ballHitPos.Translate(-Vector3.up * (0.2f * Time.fixedDeltaTime));
        if(_isRightBallHitPos) ballHitPos.Translate(Vector3.right * (0.2f * Time.fixedDeltaTime));
        if(_isLeftBallHitPos) ballHitPos.Translate(-Vector3.right * (0.2f * Time.fixedDeltaTime));
        if(_isSetShootSlider) SetShootSlider();
    }

    private void NewFreekickCreate()
    {
        if (trajectoryLineRenderer.gameObject.activeSelf) trajectoryLineRenderer.gameObject.SetActive(false);
        _isBallHit = false;
        _isShooting = !_isShooting;
        ball.Sleep();
        var ballTransform = ball.transform;
        ballTransform.localPosition = Vector3.zero;
        ballTransform.localEulerAngles = Vector3.zero;
    }

    private void SetNewFreekickUI()
    {
        if (!directionCanvas.activeSelf) directionCanvas.SetActive(true);
        if (ballHitCanvas.activeSelf) ballHitCanvas.SetActive(false);
        if (!ballDistanceText.gameObject.activeSelf) ballDistanceText.gameObject.SetActive(true);
        
        ballDistanceText.text = DistanceConversion.Distance((ball.position - goalCenter.position).magnitude);
        SetInstructionPanels(true, false, false);
    }

    private void TranslateFreekickPointWithInput(Vector3 direction)
    {
        freekickPoint.Translate(direction * (5f * Time.fixedDeltaTime));
        
        // restricting the ball in an area.
        if (freekickPoint.transform.localPosition.x > XMax || freekickPoint.transform.localPosition.x < XMin ||
            freekickPoint.transform.localPosition.z > ZMax || freekickPoint.transform.localPosition.z < ZMin)
        {
            freekickPoint.Translate(-direction * (5f * Time.fixedDeltaTime));
        }
    }
    
    private void SetKickAngle(int direction)
    {
        freekickPoint.transform.Rotate(freekickPoint.up, direction * 0.4f);
        trajectoryLineRenderer.transform.eulerAngles = Vector3.zero;
    }

    private void SetInstructionPanels(bool positionSelection, bool setting, bool completed)
    {
        if (freekickPositionSelectionPanel.activeSelf != positionSelection) freekickPositionSelectionPanel.SetActive(positionSelection);
        if (freekickSettingPanel.activeSelf != setting) freekickSettingPanel.SetActive(setting);
        if (freekickCompletedPanel.activeSelf != completed) freekickCompletedPanel.SetActive(completed);
    }

    private void SetShootSlider()
    {
        if (_power >= 30f) return;
        _power++;
        shootSlider.value = _power / 30f;
    }

    private void ResetShootSlider()
    {
        _power = 0;
        shootSlider.value = 0;
        _isUnavailableForNewFreekick = false;
    }

    private IEnumerator WaitForResetShootSlider()
    {
        _isBallHit = true;
        _isUnavailableForNewFreekick = true;
        yield return new WaitForSecondsRealtime(4f);
        SetInstructionPanels(false, false, true);
        ResetShootSlider();
    }

    private void ShootToTargets()
    {
        if (ballDistanceText.gameObject.activeSelf) ballDistanceText.gameObject.SetActive(false);
        SetInstructionPanels(false, false, false);

        BallSoundPlayer.PlaySound(shootAudioSource, shootAudioClip, 1 + (2 - _power * 0.0666f));
        StartCoroutine(ShootToNearTarget());
    }

    private IEnumerator ShootToNearTarget()
    {
        while ((ball.position - nearTarget.position).magnitude > 0.2f)
        {
            ball.position = Vector3.MoveTowards(ball.position, nearTarget.position, 0.1f + _power / 60f);
            yield return new WaitForSeconds(0.01f);
        }

        ShootToFarTarget();
        yield return null;
    }

    private void ShootToFarTarget()
    {
        var shoot = (farTarget.position - ball.position).normalized;
        ball.AddForce((shoot + new Vector3(0f, _power / 105f, 0f)) * _power / 2.4f, ForceMode.Impulse);
    }
}