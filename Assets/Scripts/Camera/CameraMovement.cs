using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform playerTransform;

    private float startPosition;
    private float subir;
    private Transform t;

	void Start () {
        t = GetComponent<Transform>();
        startPosition = t.position.z;
        subir = t.position.y; //manera de hacer que la camara siga en el eje Y al personaje
    }
	
	void Update () {

        Vector3 position = new Vector3(playerTransform.position.x, playerTransform.position.y + subir, playerTransform.position.z + startPosition);
        t.position = position;
	}
}
