using UnityEngine;

public class MovementWithNewInput : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        // Get rigid body component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Input from player 
        float directionY = Input.GetAxis("Vertical");

        // Movement in y direction
        direction = new Vector2(0, directionY).normalized;

    }

    private void FixedUpdate()
    {
        // Move rigid body
        rb.velocity = new Vector2(0, direction.y * speed);

    }
}
