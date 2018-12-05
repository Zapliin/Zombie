using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWall2Piso : MonoBehaviour {

    public GameObject primer;
    public GameObject techo;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            techo.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            techo.SetActive(true);
            primer.SetActive(true);
        }
    }
}
