using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Animator animator;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
	
	void Update () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        //Animaciones
        animator.SetFloat("VerticalSpeed", moveVertical);
        animator.SetFloat("HorizontalSpeed", moveHorizontal);

    }
}
