using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    
    public Rigidbody rb;
    public float bulletDuration;
    public int pointHit = 5;

    private float tick;
    private float speed;
    private int damage;

    private Vector3 velocity;

	void Start () {
        GameObject weapon = GameObject.Find("Weapon");
        WeaponProperties weaponProperties = weapon.GetComponent<WeaponProperties>();

        damage = weaponProperties.damage;
        speed = weaponProperties.speed;

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
            Score score = GameObject.Find("Puntuacion").GetComponent<Score>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage);
                score.HitScore(pointHit);
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
