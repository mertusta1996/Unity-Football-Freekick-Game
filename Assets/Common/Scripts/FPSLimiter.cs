using System.Globalization;
using TMPro;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int target = 60;
    public TextMeshProUGUI fpsText; 
    
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }
     
    void Update()
    {
        if(Application.targetFrameRate != target)
            Application.targetFrameRate = target;

        fpsText.text = $"{Mathf.RoundToInt(1.0f / Time.deltaTime)} Fps";
    }
}
