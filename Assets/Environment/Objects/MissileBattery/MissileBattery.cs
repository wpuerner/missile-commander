﻿using UnityEngine;
using System.Collections;

public class MissileBattery : MonoBehaviour {

    public KeyCode fireMissileKey;
    GameObject missileStartMarker;

    public GameObject playerMissile;

	// Use this for initialization
	void Start () {
        foreach (Transform child in this.transform)
        {
            if(child.gameObject.name == "MissileStartMarker")
            {
                missileStartMarker = child.gameObject;
            }
        }

        if(missileStartMarker == null)
        {
            Debug.Log("There is no Missile Start Marker in this Missile Battery!");
        }
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(fireMissileKey))
        {
            GameObject firedMissile = Instantiate(playerMissile, missileStartMarker.transform.position,
                Quaternion.identity) as GameObject;
        }
	
	}

    void fireMissile()
    {

    }
}
