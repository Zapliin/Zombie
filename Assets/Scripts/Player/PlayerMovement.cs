using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public string direction;
    public float moveVertical;
    public Animator animator;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update () {
        moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        animator.SetFloat("VerticalSpeed", moveVertical);
        animator.SetFloat("HorizontalSpeed", moveHorizontal);

        if (moveHorizontal > 0)
        {   
            if (direction != "Right")
            {
                //Flip();
                direction = "Right";
            }
        } else if (moveHorizontal < 0)
        {
            if (direction != "Left")
            {
                //Flip();
                direction = "Left";
            }
        }
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
