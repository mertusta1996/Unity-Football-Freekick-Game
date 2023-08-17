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
            BallSoundPlayer.PlaySoundByVelocity(netAudioSource, netAudioClip, 1 + 12f / ballVelocity, ballVelocity, 3f);

            while (ball.velocity.magnitude > 3f)
            {
                ball.velocity *= 0.9f;
            }
        }
        
        if (collision.gameObject.layer == LayerMask.NameToLayer($"Crossbar Collider"))
        {
            BallSoundPlayer.PlaySoundByVelocity(crossbarAudioSource, crossbarAudioClip, 1 + 5f / ballVelocity, ballVelocity, 1f);
        }
        
        if (collision.gameObject.layer == LayerMask.NameToLayer($"Grass"))
        {
            BallSoundPlayer.PlaySoundByVelocity(ballBounceAudioSource, ballBounceAudioClip, 1 + 3f / ballVelocity, ballVelocity, 1f);
        }
    }
}
