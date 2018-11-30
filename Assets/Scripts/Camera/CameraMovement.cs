using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform playerTransform;

    private float startPosition;
    private Transform t;

	void Start () {
        t = GetComponent<Transform>();
        startPosition = t.position.z;
    }
	
	void Update () {

        Vector3 position = new Vector3(playerTransform.position.x, t.position.y, playerTransform.position.z + startPosition);
        t.position = position;
	}
}
