using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWalls : MonoBehaviour {

    public GameObject primer;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            primer.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             primer.SetActive(true);
        }
    }
}
