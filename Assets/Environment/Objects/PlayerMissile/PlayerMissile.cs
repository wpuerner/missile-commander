using UnityEngine;
using System.Collections;

public class PlayerMissile : MonoBehaviour {

    public float moveSpeed;

    public GameObject explosion;

    private Vector3 start;
    private Vector3 end;

    float moveDistance;

	// Use this for initialization
	void Start () {
        Vector3 crosshareLocation = GameObject.Find("Crosshare").transform.position;
        end = new Vector3(crosshareLocation.x, crosshareLocation.y, -1f);
        start = this.transform.position;
        moveDistance = (end - start).magnitude;
	}
        
    void FixedUpdate()
    {
        this.transform.Translate((end - start).normalized * Time.deltaTime * moveSpeed);
        if((this.transform.position - start).magnitude >= moveDistance)
        {
            explodeMissile();
        }
    }

    void explodeMissile()
    {
        GameObject newExplosion = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(this.gameObject);
    }
    
}
