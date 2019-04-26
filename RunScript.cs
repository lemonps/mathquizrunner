using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour
{
    private const float LANEDISTANCE = 3f;
    private const float TURNSPEED = 0.5f;
    // Start is called before the first frame update
    private CharacterController controller;
    public static float speed = 5f;
    private float jumpForce = 5f;
    private float gravity = 12f;
    private float verticalVelocity;
    private int desiredLane = 1;

    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Swipe.Instance.SwipeLeft || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLane(false);
            print("left");
        }

        if (Swipe.Instance.SwipeRight || Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveLane(true);
            print("right");
        }
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
            targetPosition += Vector3.left * LANEDISTANCE;
        if (desiredLane == 2)
            targetPosition += Vector3.right * LANEDISTANCE;


        if (Swipe.Instance.SwipeDown || Input.GetKeyDown(KeyCode.DownArrow))
            anim.SetTrigger("Slide");

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).normalized.x * speed;

        bool grounded = isGrounded();
        anim.SetBool("Grounded", grounded);

        if (grounded)
        {
            verticalVelocity = -0.1f;

            if (Swipe.Instance.SwipeUp || Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
                
            }
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = -jumpForce;
            }
        }
        
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector* Time.deltaTime);

        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero) {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, TURNSPEED);
        }
    }
    private void moveLane(bool goingRight)
    {
        if (!goingRight)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        else
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
    }

    private bool isGrounded()
    {
        Ray groundedRay = new Ray(new Vector3 (controller.bounds.center.x,
            (controller.bounds.center.y - controller.bounds.extents.y)+0.2f,controller.bounds.center.z),Vector3.down);
        Debug.DrawRay(groundedRay.origin, groundedRay.direction, Color.cyan, 1f);

        return (Physics.Raycast(groundedRay, 0.2f + 0.1f));
          
    }


}
