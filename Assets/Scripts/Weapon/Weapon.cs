using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public int damage;
    public float fireRate;
    public float speed;

    public string getName()
    {
        return this.gameObject.name;
    }
}
