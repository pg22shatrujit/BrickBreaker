using UnityEngine;

public class BreakerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10; //Brick breaker speed
    [SerializeField, Range(0, 180)] float releaseAngle = 45; //Angle (with X-axis) the ball releases from the paddle at

    private bool isAttached; //Whether the breaker is attached to the paddle
    new Rigidbody2D rigidbody; //Own rigidbody, new keyword to suppress warning about hiding deprecated Component.rigidbody
    Rigidbody2D paddleRigidbody; //Paddle's rigidbody
    Vector2 releaseDirection; //Direction the ball moves in on release from paddle

    // Start is called before the first frame update
    void Start()
    {
        isAttached = true; //Set is attached to true at the start of the scene
        releaseDirection = new Vector2(Mathf.Cos(releaseAngle), Mathf.Sin(releaseAngle)); //Set normalised release direction using releaseAngle

        //Cache own and paddle's rigidbodies
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        paddleRigidbody = FindObjectOfType<PaddleMovement>().GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Check if is attached to paddle, and match the paddle's velocity if so
        if(isAttached)
        {
            rigidbody.velocity = paddleRigidbody.velocity;

            //On key press, release the ball in the release direction with initial speed
            if(Input.GetKeyDown(KeyCode.Space))
            {
                isAttached = false;
                rigidbody.velocity = speed * releaseDirection;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Check for collision contacts and find normal
        if(collision.contacts.Length != 0) {
            Vector2 contactNormal = collision.contacts[0].normal;

            //Normalize current velocity and find the reflection around the collision normal
            //Using formula reflectionVector = incidentVector - 2 * (incidentVector . normal) *  normal;
            Vector2 velocityNormalized = rigidbody.velocity.normalized;
            velocityNormalized -= 2 * Vector2.Dot(velocityNormalized, contactNormal) * contactNormal;

            //set the velocity using the new normal vector and speed (So we never lose speed on collisions)
            rigidbody.velocity = velocityNormalized * speed;
        }
    }
}
