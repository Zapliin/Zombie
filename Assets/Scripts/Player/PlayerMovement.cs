using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public string direction;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -200.0F, 0);
    }
	
	// Update is called once per frame
	void Update () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {   
            if (direction != "Up")
            {
                Flip();
                direction = "Up";
            }
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (direction != "Down")
            {
                Flip();
                direction = "Down";
            }
        }
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
