using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int monsterCount = 0;

    public GameObject[] enemy;
    public Text playerName;
    public Text scoreText;
    public GameObject gameOverText;
    public bool isGameActive;
    
    int score = 0;
    int scoreToUp = 0;
    float verticalTop = 4.3f;
    float horizontalTop = 2.6f;
    float spawnRate = 1f;
    float randTime = 3;
    int randLenght;

    public int Score {get{ return score;}}

    private void Start()
    {
        isGameActive = true;
        randLenght = enemy.Length;
        playerName.text = DataBetweenScenes.Instance.userName;
        StartCoroutine(Game());     
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString(); 
    }

    void SpawnEnemy()
    {
        int rand = Random.Range(0, randLenght);
        Vector3 pos = new Vector3(Random.Range(-horizontalTop, horizontalTop), Random.Range(-verticalTop, verticalTop));
        Instantiate(enemy[rand], pos, enemy[rand].gameObject.transform.rotation);
        monsterCount++;
    }

    public void IncreaseScore(int incr)
    {
        score += incr;
        scoreToUp++;
        if (scoreToUp == 5)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].gameObject.GetComponent<Enemy>().EnemyUp();
            }
            scoreToUp = 0;
        }
    }

    IEnumerator Game()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();
            spawnRate = Random.Range(0, randTime);
            if (monsterCount > 10)
            {
                isGameActive = false;
                gameOverText.SetActive(true);
            }
        }
    }
}
