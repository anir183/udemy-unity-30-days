using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement and Input")]
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed = 1.5f;

    [Header("Constraints")]
    [SerializeField] private Vector2 boundary = new Vector2(32, 18);

    [Header("Collectibles")]
    [SerializeField] private string collectibleTag = "Carrot";

    private float speedModifier = 0.15f;
    private float horzInput, vertInput;

    private void FixedUpdate()
    {
        // calculate joystick input
        horzInput = joystick.Horizontal * moveSpeed * speedModifier;
        vertInput = joystick.Vertical * moveSpeed * speedModifier;

        // move player
        transform.Translate(horzInput, vertInput, 0);

        // force player within boundary
        if (transform.position.x > boundary.x)
            transform.position = new Vector2(boundary.x, transform.position.y);
        else if (transform.position.x < -boundary.x)
            transform.position = new Vector2(-boundary.x, transform.position.y);

        if (transform.position.y > boundary.y)
            transform.position = new Vector2(transform.position.x, boundary.y);
        else if (transform.position.y < -boundary.y)
            transform.position = new Vector2(transform.position.x, -boundary.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collectibleTag)
        {
            CollectableController.instance.incrScore();
            Destroy(collision.gameObject);
        }
    }
}
