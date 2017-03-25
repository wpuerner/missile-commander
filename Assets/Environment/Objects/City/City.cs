using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {

    public bool isAlive = true;

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
            killCity();
        }
    }

    public void killCity()
    {
        isAlive = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("GameController").GetComponent<GameController>().deadCities.Enqueue(this.gameObject);
    }

    public void reviveCity()
    {
        isAlive = true;
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
