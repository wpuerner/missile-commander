using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float max_scale = 5f;
    public float min_scale = 0f;

    public float scalingSpeed;
    Vector3 currentScale;

    int scaleDirection = 1;

	// Use this for initialization
	void Start () {
        currentScale = new Vector3(min_scale, min_scale, 1f);
        this.transform.localScale = currentScale;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        currentScale.x += scalingSpeed * scaleDirection;
        currentScale.y += scalingSpeed * scaleDirection;

        if (currentScale.x >= max_scale)
        {
            scaleDirection = -1;
        }
        else if(currentScale.x <= 0f)
        {
            Destroy(this.gameObject);
        }

        this.transform.localScale = currentScale;
	
	}
}
