using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public string direction;
    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
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
