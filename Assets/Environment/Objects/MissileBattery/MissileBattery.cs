using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MissileBattery : MonoBehaviour {

    public KeyCode fireMissileKey;
    GameObject missileStartMarker;

    public GameObject playerMissile;

    Stack<GameObject> playerMissileStock;

	// Use this for initialization
	void Awake () {

        playerMissileStock = new Stack<GameObject>();

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
            if(playerMissileStock.Count > 0)
            {
                GameObject retrievedPlayerMissile = playerMissileStock.Pop();
                retrievedPlayerMissile.GetComponent<SpriteRenderer>().enabled = false;

                GameObject firedMissile = Instantiate(playerMissile, missileStartMarker.transform.position,
                Quaternion.identity) as GameObject;

                if (this.gameObject.name == "CenterMissileBattery")
                {
                    firedMissile.GetComponent<PlayerMissile>().moveSpeed = firedMissile.GetComponent<PlayerMissile>().moveSpeed * 1.2f;
                }
            }

            
            
        }
	
	}

    public void generateMissileStock()
    {
        Debug.Log(this.gameObject.name + ": Generating missile stock");
        while(playerMissileStock.Count > 0)
        {
            GameObject retrievedPlayerMissile = playerMissileStock.Pop();
        }

        foreach(Transform child in this.transform)
        {
            if (child.name == "stockedPlayerMissile")
            {
                child.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                playerMissileStock.Push(child.gameObject);
            }
        }
    }
}
