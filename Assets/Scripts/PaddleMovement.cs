using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    //Store object speed and a reference to it's rigidbody
    [SerializeField] float speed = 20;
    new Rigidbody2D rigidbody;

    //Cache reference the rigidbody
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    //Move by an amount equal to the input
    void FixedUpdate()
    {
        move(Input.GetAxis("Horizontal"));
    }

    //Move right or left depending on whether the input was positive or negative
    private void move(float direction)
    {
        rigidbody.velocity = new Vector2(direction * speed, 0);
    }
}
