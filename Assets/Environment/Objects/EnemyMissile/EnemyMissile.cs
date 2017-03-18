using UnityEngine;
using System.Collections;

public class EnemyMissile : MonoBehaviour {

    public float moveSpeed;

    public GameObject explosion;

    private Vector3 start;
    private Vector3 end;

    public float maxSidewaysLimit;

	// Use this for initialization
	void Start ()
    {
        start = this.transform.position;
        end = new Vector3(this.transform.position.x + Random.Range(-1f * maxSidewaysLimit, maxSidewaysLimit),
            -10f, -1f);
        

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        this.transform.Translate((end - start).normalized * Time.deltaTime * moveSpeed);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Explosion")
        {
            GameObject.Find("GameController").GetComponent<GameController>().score++;
        }

        explodeMissile();
    }

    void explodeMissile()
    {
        GameObject newExplosion = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
    }
}
