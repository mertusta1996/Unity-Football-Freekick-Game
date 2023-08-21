using UnityEngine;

public class FreekickCamera : MonoBehaviour
{
    public Transform freekickCamera;
    public Transform ballHitCanvas;
    public Transform directionCanvas;
    private float _mouseZ, _initialCamHeight;
    
    private void Start()
    {
        _initialCamHeight = freekickCamera.localPosition.y;
    }
    
    void Update()
    {
        _mouseZ = Input.GetAxis("Mouse ScrollWheel");
        SetCameraHeight(_mouseZ);
    }
    
    private void SetCameraHeight(float heightDiff)
    {
        if (heightDiff == 0) return;
            
        if (_initialCamHeight <= 10f && _initialCamHeight >= 1.85f)
            _initialCamHeight -= heightDiff;
        else if(_initialCamHeight > 10f)
            _initialCamHeight -= 0.2f;
        else if (_initialCamHeight < 1.85f)
            _initialCamHeight += 0.2f;
            
        freekickCamera.localPosition = new Vector3(0, _initialCamHeight, _initialCamHeight * -1.15f);

        var worldCanvasScale = _initialCamHeight / 1.75f;
        ballHitCanvas.localScale = new Vector3(0.35f + worldCanvasScale*0.65f, 0.35f + worldCanvasScale*0.65f, 0.35f + worldCanvasScale*0.65f);
        directionCanvas.localScale = new Vector3(0.75f + worldCanvasScale/4, 0.75f + worldCanvasScale/4, 0.75f + worldCanvasScale/4);
    }
}
