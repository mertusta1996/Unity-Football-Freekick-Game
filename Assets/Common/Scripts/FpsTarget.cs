using System.Collections;
using TMPro;
using UnityEngine;

public class FpsTarget : MonoBehaviour
{
    public bool isFpsTargeting = true;
    public int fpsTarget = 60;
    public TextMeshProUGUI fpsText; 
    
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fpsTarget;
        StartCoroutine(ShowFPS());
    }
     
    private IEnumerator ShowFPS()
    {
        while (isFpsTargeting)
        {
            if(Application.targetFrameRate != fpsTarget)
                Application.targetFrameRate = fpsTarget;
            
            fpsText.text = $"{Mathf.RoundToInt(1.0f / Time.deltaTime)} Fps";
            yield return new WaitForSecondsRealtime(1f);
        }
    }
}