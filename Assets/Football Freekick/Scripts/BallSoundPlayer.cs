using UnityEngine;

public class BallSoundPlayer : MonoBehaviour
{
    public static void PlaySound(AudioSource audioSource, AudioClip audioClip, float pitch)
    {
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(audioClip);
    }
    
    public static void PlaySoundByVelocity(AudioSource audioSource, AudioClip audioClip, float pitch, float ballVelocity, float audibleVelocityLimit)
    {
        if (ballVelocity > audibleVelocityLimit)
            PlaySound(audioSource, audioClip, pitch);
    }
}
