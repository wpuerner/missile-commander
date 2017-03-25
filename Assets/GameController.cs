using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{ 
    public int level = 1;
    public int score = 0;

    public GameObject enemyMissile;

    Text scoreText;
    Text levelText;

    public int numAddLevelMissiles;

    public Queue<GameObject> deadCities;
    
    void Start()
    {
        deadCities = new Queue<GameObject>();

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        levelText = GameObject.Find("Level").GetComponent<Text>();

        resetMissileBatteries();

        StartCoroutine(instantiateEnemyMissiles(level + numAddLevelMissiles));

    }

    

    void Update()
    {
        //update the UI
        scoreText.text = score.ToString();
        levelText.text = level.ToString();
    }

    IEnumerator instantiateEnemyMissiles(int numEnemyMissiles)
    {
        while (numEnemyMissiles > 0)
        {
            GameObject newEnemyMissile = Instantiate(enemyMissile, new Vector3(Random.Range(-8f, 8f),
                5.64f, -1f), Quaternion.identity) as GameObject;
            numEnemyMissiles--;
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
        }

        yield return new WaitForSeconds(5f);
        finishLevel();
    }

    //either end the game or return to the main menu
    void finishLevel()
    {
        Debug.Log("Finishing level");
        //check and see if the score is high enough to add another city

        //check if there are any cities left. If there aren't end the game
        int numAliveCities = 0;
        GameObject[] cities = GameObject.FindGameObjectsWithTag("City");
        for(int i = 0; i < cities.Length; i++)
        {
            if(cities[i].GetComponent<City>().isAlive)
            {
                numAliveCities++;
            }
        }


        if (numAliveCities == 0)
        {
            Debug.Log("Game over");

            //turn on the game over UI
            GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
            GameObject.Find("GameOverComment").GetComponent<Text>().text = "Your score: " + score.ToString();
            GameObject.Find("GameOverComment").GetComponent<Text>().enabled = true;
            GameObject.Find("GameOverInstructions").GetComponent<Text>().enabled = true;

            //wait for the user to press a key
            StartCoroutine(waitForKey());


        }
        else
        {
            //start the next level
            resetMissileBatteries();
            level++;
            StartCoroutine(instantiateEnemyMissiles(level + 10));
        }
    }

    //wait for input from the player after the game has ended
    IEnumerator waitForKey()
    {
        while(!(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.M) || Input.GetKey(KeyCode.R)))
        {
            yield return null;
        }

        if(Input.GetKey(KeyCode.Q))
        {
            Debug.Log("The player quit the game");
            Application.Quit();
        }
        
        if(Input.GetKey(KeyCode.R))
        {
            //restart the game
            Debug.Log("The player restarted the game");
            Application.LoadLevel("DevScene");
        }

        if(Input.GetKey(KeyCode.M))
        {
            //return to the menu
            Debug.Log("The player chose to go to the main menu");
        }

    }

    void resetMissileBatteries()
    {
        GameObject[] batteries = GameObject.FindGameObjectsWithTag("Battery");
        for (int i = 0; i < batteries.Length; i++)
        {
            batteries[i].GetComponent<MissileBattery>().generateMissileStock();
        }
    }

}
