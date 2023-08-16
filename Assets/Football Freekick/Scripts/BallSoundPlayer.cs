using UnityEngine;

public class BallSoundPlayer : MonoBehaviour
{
    public static void PlaySound(AudioSource audioSource, AudioClip audioClip, float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(audioClip);
    }
    
    public static void PlaySound(AudioSource audioSource, AudioClip audioClip, float pitch, float sound)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(audioClip, sound);
    }
}
