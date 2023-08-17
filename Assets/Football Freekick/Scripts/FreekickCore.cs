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
    public GameObject ballHitCanvas;
    public GameObject directionCanvas;
    public GameObject freekickPositionSelectionPanel;
    public GameObject freekickSettingPanel;
    public GameObject freekickCompletedPanel;
    public TextMeshProUGUI ballDistanceText;
    
    [Header("Freekick Positions")]
    public Transform freekickPoint;
    public Transform farTarget;
    public Transform nearTarget;
    public Transform goalCenter;
    
    private const float XMin = -4.8f;
    private const float XMax = 4.8f;
    private const float ZMin = -4.4f;
    private const float ZMax = 4.4f;
    private bool _isShooting;
    private bool _isBallHit;
    private bool _isAvailableForNewFreekick = true;
    private float _power;

    public void Update()
    {
        SetKickAngle();
        NewFreekickCreate();

        if (_isShooting == false)
        {
            SetNewFreekickPosition();
            return;
        }

        SetCanvasVisibility();
        SetFreekick();
        ShootFreekick();
    }

    private void NewFreekickCreate()
    {
        if (!Input.GetKeyDown(KeyCode.Return) || !_isAvailableForNewFreekick) return;
        if (trajectoryLineRenderer.gameObject.activeSelf) trajectoryLineRenderer.gameObject.SetActive(false);

        _isBallHit = false;

        _isShooting = !_isShooting;
        ball.Sleep();

        var ballTransform = ball.transform;
        ballTransform.localPosition = Vector3.zero;
        ballTransform.localEulerAngles = Vector3.zero;
    }

    private void SetNewFreekickPosition()
    {
        if (!directionCanvas.activeSelf) directionCanvas.SetActive(true);
        if (ballHitCanvas.activeSelf) ballHitCanvas.SetActive(false);
        if (!ballDistanceText.gameObject.activeSelf) ballDistanceText.gameObject.SetActive(true);

        ballDistanceText.text = DistanceConversion.Distance((ball.position - goalCenter.position).magnitude);

        SetInstructionPanels(true, false, false);
        
        if (Input.GetKey(KeyCode.W)) TranslateFreekickPointWithInput(Vector3.forward);
        if (Input.GetKey(KeyCode.S)) TranslateFreekickPointWithInput(-Vector3.forward);
        if (Input.GetKey(KeyCode.D)) TranslateFreekickPointWithInput(Vector3.right);
        if (Input.GetKey(KeyCode.A)) TranslateFreekickPointWithInput(-Vector3.right);
    }

    private void TranslateFreekickPointWithInput(Vector3 direction)
    {
        freekickPoint.Translate(direction * (5f * Time.deltaTime));
        
        // restricting the ball in an area.
        if (freekickPoint.transform.localPosition.x > XMax || freekickPoint.transform.localPosition.x < XMin ||
            freekickPoint.transform.localPosition.z > ZMax || freekickPoint.transform.localPosition.z < ZMin)
        {
            freekickPoint.Translate(-direction * (5f * Time.deltaTime));
        }
    }

    private void SetFreekickCurveSettings(Vector3 ballHitDir, float ballHitValue, Vector3 farTargetDir, float farTargetValue,Vector3 nearTargetDir, float nearTargetValue)
    {
        ballHitPos.Translate(ballHitDir * (ballHitValue * Time.deltaTime));
        farTarget.Translate(farTargetDir * (farTargetValue * Time.deltaTime));
        nearTarget.Translate(nearTargetDir * (nearTargetValue * Time.deltaTime));
    }

    private void SetKickAngle()
    {
        if (_isBallHit) return;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            freekickPoint.transform.Rotate(freekickPoint.up, 0.4f);
            trajectoryLineRenderer.transform.eulerAngles = Vector3.zero;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            freekickPoint.transform.Rotate(freekickPoint.up, -0.4f);
            trajectoryLineRenderer.transform.eulerAngles = Vector3.zero;
        }
    }

    private void SetCanvasVisibility()
    {
        if (directionCanvas.activeSelf)
            directionCanvas.SetActive(false);

        if (!_isBallHit)
        {
            if (!ballHitCanvas.activeSelf) ballHitCanvas.SetActive(true);
            if (!trajectoryLineRenderer.gameObject.activeSelf) trajectoryLineRenderer.gameObject.SetActive(true);
            SetInstructionPanels(false, true, false);
        }
        else
        {
            if (ballHitCanvas.activeSelf) ballHitCanvas.SetActive(false);
            if (trajectoryLineRenderer.gameObject.activeSelf) trajectoryLineRenderer.gameObject.SetActive(false);
        }
    }

    private void SetInstructionPanels(bool positionSelection, bool setting, bool completed)
    {
        if (freekickPositionSelectionPanel.activeSelf != positionSelection) freekickPositionSelectionPanel.SetActive(positionSelection);
        if (freekickSettingPanel.activeSelf != setting) freekickSettingPanel.SetActive(setting);
        if (freekickCompletedPanel.activeSelf != completed) freekickCompletedPanel.SetActive(completed);
    }

    private void SetFreekick()
    {
        if (_isBallHit) return;
        if (Input.GetKey(KeyCode.S) && ballHitPos.localPosition.y > -0.435f)
        {
            if (ballHitPos.localPosition.y < 0 && ballHitPos.localPosition.magnitude > 0.435) return;
            SetFreekickCurveSettings(-Vector3.up, 0.2f, Vector3.up, 1f, Vector3.up, 0.1f);
        }

        if (Input.GetKey(KeyCode.W) && ballHitPos.localPosition.y < 0.435f)
        {
            if (ballHitPos.localPosition.y > 0 && ballHitPos.localPosition.magnitude > 0.435) return;
            SetFreekickCurveSettings(Vector3.up, 0.2f, -Vector3.up, 1f, -Vector3.up, 0.1f);
        }

        if (Input.GetKey(KeyCode.A) && ballHitPos.localPosition.x > -0.435f)
        {
            if (ballHitPos.localPosition.x < 0 && ballHitPos.localPosition.magnitude > 0.435) return;
            SetFreekickCurveSettings(-Vector3.right, 0.2f, Vector3.right, 4f, Vector3.right, 0.1f);
        }

        if (Input.GetKey(KeyCode.D) && ballHitPos.localPosition.x < 0.435f)
        {
            if (ballHitPos.localPosition.x > 0 && ballHitPos.localPosition.magnitude > 0.435) return;
            SetFreekickCurveSettings(Vector3.right, 0.2f, -Vector3.right, 4f, -Vector3.right, 0.1f);
        }
        
        trajectoryLineRenderer.CreateTrajectoryLine(ball.transform, nearTarget, farTarget);
        trajectoryLineRenderer.transform.position = Vector3.zero;
    }

    private void ShootFreekick()
    {
        if (_isBallHit) return;
        if (Input.GetKey(KeyCode.Space))
        {
            SetShootSlider();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ShootToTargets();
            StartCoroutine(WaitForResetShootSlider());
        }
    }

    private void SetShootSlider()
    {
        if (_power >= 50f) return;
        _power++;
        shootSlider.value = _power / 50f;
    }

    private void ResetShootSlider()
    {
        _power = 0;
        shootSlider.value = 0;
        _isAvailableForNewFreekick = true;
    }

    private IEnumerator WaitForResetShootSlider()
    {
        _isBallHit = true;
        _isAvailableForNewFreekick = false;
        yield return new WaitForSecondsRealtime(4f);
        SetInstructionPanels(false, false, true);
        ResetShootSlider();
    }

    private void ShootToTargets()
    {
        if (ballDistanceText.gameObject.activeSelf) ballDistanceText.gameObject.SetActive(false);
        SetInstructionPanels(false, false, false);

        BallSoundPlayer.PlaySound(shootAudioSource, shootAudioClip, 1 - (1 - (50f / _power)) * 0.2f);
        StartCoroutine(ShootToNearTarget());
    }

    private IEnumerator ShootToNearTarget()
    {
        while ((ball.position - nearTarget.position).magnitude > 0.2f)
        {
            ball.position = Vector3.MoveTowards(ball.position, nearTarget.position, 0.1f + _power / 100f);
            yield return new WaitForSeconds(0.01f);
        }

        ShootToFarTarget();
        yield return null;
    }

    private void ShootToFarTarget()
    {
        Vector3 shoot = (farTarget.position - ball.position).normalized;
        ball.AddForce((shoot + new Vector3(0f, _power / 175f, 0f)) * _power / 4f, ForceMode.Impulse);
    }
}
