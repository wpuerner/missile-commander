using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Explosion")
        {
            Destroy(this.gameObject);
        }
    }
}
