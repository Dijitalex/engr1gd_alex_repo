using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    float movementX;
    float movementY;
    bool jumping = false;
    bool touchGround;
    //bool facingRight = true;
    private Animator animator;
    [SerializeField] float speed = 150; //W SPEED
    [SerializeField] float jump = 10f;
    [SerializeField] Rigidbody2D rb; //remember default is private, serializefield will keep it private but accessible in the unity editor
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (movementX < 0 && facingRight)
        // {
        //     transform.localScale.x *= -1;
        // }
    }

    void OnMove(InputValue value)
    {
        UnityEngine.Vector2 v = value.Get<UnityEngine.Vector2>();

        movementX = v.x;
        movementY = v.y;
        animator.SetBool("walking", !Mathf.Approximately(v.x, 0));


        Debug.Log(v);

    }

    void OnJump()
    {
        if (touchGround)
        {
            jumping = true;
        }
    }
    void FixedUpdate()
    {//As opposed to regular Update(), game physics will not be time depend on frames cough cough Touhou
        float XmoveDistance = movementX * speed;
        //float YmoveDistance = movementY * speed * Time.fixedDeltaTime;

        //transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
        //rb.linearVelocity = new Vector2 (40*XmoveDistance, 40*YmoveDistance);
        rb.linearVelocityX = XmoveDistance;

        if (touchGround && jumping)
        {
            rb.AddForce(jump * UnityEngine.Vector2.up, ForceMode2D.Impulse);
            jumping = false;
            animator.SetTrigger("jump");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grnd"))//collision.gameObject.tag == "ground"
        {
            touchGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Grnd"))//collision.gameObject.tag == "ground"
        {
            touchGround = false;
        }
    }
    
}
