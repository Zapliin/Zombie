using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public GameObject Closed;
    public GameObject Open;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Open.SetActive(true);
            Closed.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Closed.SetActive(true);
            Open.SetActive(false);
        }
    }
}
