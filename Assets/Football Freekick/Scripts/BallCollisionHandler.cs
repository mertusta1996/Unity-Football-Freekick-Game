using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    private Rigidbody ball;

    [Header("AudioSources")]
    public AudioSource netAudioSource;
    public AudioSource crossbarAudioSource;
    public AudioSource ballBounceAudioSource;

    [Header("AudioClips")]
    public AudioClip netAudioClip;
    public AudioClip crossbarAudioClip;
    public AudioClip ballBounceAudioClip;

    private void Awake()
    {
        ball = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var ballVelocity = ball.velocity.magnitude;

        if (collision.gameObject.layer == LayerMask.NameToLayer($"Ball Limit Colliders"))
        {
            if (ballVelocity > 3f)
            {
                BallSoundPlayer.PlaySound(netAudioSource, netAudioClip, 1 + 12f / ballVelocity);
            }

            while (ball.velocity.magnitude > 3f)
            {
                ball.velocity = this.GetComponent<Rigidbody>().velocity * 0.9f;
            }
        }
        
        if (collision.gameObject.layer == LayerMask.NameToLayer($"Crossbar Collider"))
        {
            if (ballVelocity > 1f)
            {
                BallSoundPlayer.PlaySound(crossbarAudioSource, crossbarAudioClip, 1 + 5f / ballVelocity);
            }
        }
        
        if (collision.gameObject.layer == LayerMask.NameToLayer($"Grass"))
        {
            if (ballVelocity > 1f)
            {
                BallSoundPlayer.PlaySound(ballBounceAudioSource, ballBounceAudioClip, 1 + 3f / ballVelocity);
            }
        }
    }
}
