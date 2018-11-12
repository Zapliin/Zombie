using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public float speed = 20f;
    public Rigidbody rb;
    public int damage = 20;
    public float bulletDuration;

    public float tick;
    private Vector3 velocity;

	void Start () {
        float AimVertical = Input.GetAxisRaw("AimVertical");
        float AimHorizontal = Input.GetAxisRaw("AimHorizontal");

        velocity = new Vector3(AimHorizontal, 0, AimVertical);
        rb.velocity = velocity * speed;
        tick = Time.time + bulletDuration;
	}

    private void OnTriggerEnter(Collider hitInfo)
    {   
        if (!hitInfo.gameObject.CompareTag("Bullet"))
        {
            ZombieProperties zombie = hitInfo.GetComponent<ZombieProperties>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (tick < Time.time)
        {
            Destroy(gameObject);
        }
    }

}
