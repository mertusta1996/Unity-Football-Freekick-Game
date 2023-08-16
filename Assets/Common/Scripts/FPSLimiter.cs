using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int target = 60;
     
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }
     
    void Update()
    {
        if(Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}
