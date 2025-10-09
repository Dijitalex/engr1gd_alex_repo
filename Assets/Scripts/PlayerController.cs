using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    float movementX;
    float movementY;
    [SerializeField] float speed = 150; //W SPEED

    [SerializeField] Rigidbody2D rb; //remember default is private, serializefield will keep it private but accessible in the unity editor

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;

        Debug.Log(v);

    }
    void FixedUpdate()
    {//As opposed to regular Update(), game physics will not be time depend on frames cough cough Touhou
        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        float YmoveDistance = movementY * speed * Time.fixedDeltaTime;

        transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
        //rb.linearVelocity = new Vector2 (40*XmoveDistance, 40*YmoveDistance);
        //rb.linearVelocityX = XmoveDistance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grnd"))//collision.gameObject.tag == "ground"
        {
            //rb.AddForce(new Vector2(5, 175));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }
    
}
