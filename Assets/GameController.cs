using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{ 
    public int level = 1;
    public int score = 0;

    public GameObject enemyMissile;

    Text scoreText;
    Text levelText;

    // Use this for initialization
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        levelText = GameObject.Find("Level").GetComponent<Text>();

        StartCoroutine(instantiateEnemyMissiles(level + 10));

    }

    // Update is called once per frame
    void Update()
    {
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
            yield return new WaitForSeconds(Random.Range(0.5f, 10f));
        }

        yield return new WaitForSeconds(5f);
        finishLevel();
    }

    void finishLevel()
    {
        Debug.Log("Finishing level");
        //check and see if the score is high enough to add another city

        //check if there are any cities left. If there aren't end the game

        if (GameObject.FindGameObjectsWithTag("City").Length == 0)
        {
            Debug.Log("Game over");

            //turn on the game over UI
            GameObject.Find("GameOver").GetComponent<Text>().enabled = true;
            GameObject.Find("GameOverComment").GetComponent<Text>().text = "Your score: " + score.ToString();
            GameObject.Find("GameOverComment").GetComponent<Text>().enabled = true;
            GameObject.Find("GameOverInstructions").GetComponent<Text>().enabled = true;

            //wait for the user to press a key
        }
        else
        {
            level++;
            StartCoroutine(instantiateEnemyMissiles(level + 10));
        }


    }
}
