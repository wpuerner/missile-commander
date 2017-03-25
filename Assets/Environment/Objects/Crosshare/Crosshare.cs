using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshare : MonoBehaviour {

    public float moveSpeed;

    int moveUp, moveDown, moveRight, moveLeft;

	// Use this for initialization
	void Start () {

        this.transform.position = new Vector3(0f, 0f, 0f);
		
	}
	
	// Update is called once per frame
	void Update () {

        moveUp = Input.GetKey(KeyCode.W) ? 1 : 0;
        moveDown = Input.GetKey(KeyCode.S) ? 1 : 0;
        moveRight = Input.GetKey(KeyCode.D) ? 1 : 0;
        moveLeft = Input.GetKey(KeyCode.A) ? 1 : 0;

        this.transform.Translate(new Vector3(moveRight + -1 * moveLeft, moveUp + -1 * moveDown, 0) * moveSpeed * Time.deltaTime);
		
	}
}
