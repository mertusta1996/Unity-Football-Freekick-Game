using UnityEngine;

public class BallCollisionHandler : MonoBehaviour
{
    private Rigidbody ball;

    private void Awake()
    {
        ball = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer($"Ball Limit Colliders"))
        {
            while (ball.velocity.magnitude > 5f)
            {
                ball.velocity = this.GetComponent<Rigidbody>().velocity * 0.9f;
            }
        }
    }
}
