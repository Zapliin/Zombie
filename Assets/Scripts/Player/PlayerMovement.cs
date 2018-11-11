using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public Transform firePoint;
    public Animator animator;
    public GameObject bulletPrefab;

    private Transform t;
    private Vector3 initialPos;
    private float firePosX;
    private float firePosZ;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        initialPos = firePoint.position;
    }
	
	void Update () {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        float AimVertical = Input.GetAxisRaw("AimVertical");
        float AimHorizontal = Input.GetAxisRaw("AimHorizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed;

        //Animaciones
        animator.SetFloat("VerticalSpeed", moveVertical);
        animator.SetFloat("HorizontalSpeed", moveHorizontal);

        firePoint.position = new Vector3(firePosX, firePoint.position.y, firePosZ);

        if (AimHorizontal != 0)
        {
            firePosX = t.position.x + initialPos.x * AimHorizontal;
            firePosZ = t.position.z + initialPos.z * AimHorizontal;
            Shoot();
        }

        if (AimVertical != 0)
        {
            firePosX = t.position.x + initialPos.z * AimVertical;
            firePosZ = t.position.z + initialPos.x * AimVertical;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
