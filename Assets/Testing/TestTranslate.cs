using UnityEngine;
using System.Collections;

public class TestTranslate : MonoBehaviour {

    public Vector3 move_direction;
    public float move_speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(move_speed * move_direction * Time.deltaTime);

	}
}
