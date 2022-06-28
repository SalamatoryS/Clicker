using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainScene : MonoBehaviour
{
    GameManager gameManager;
    public GameObject destroyButton;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }
    public void LoadMenu()
    {
        if (gameManager.Score > DataBetweenScenes.Instance.maxScore)
        {
            DataBetweenScenes.Instance.SaveUser(gameManager.Score);
        }
        SceneManager.LoadScene(0);
    }

    public void DestoryEnemies()
    {
        GameObject [] enemiesOnScene = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemiesOnScene.Length; i++)
        {
            Destroy(enemiesOnScene[i]);
            GameManager.monsterCount--;
            gameManager.IncreaseScore(10);
        }
        destroyButton.SetActive(false);
    }
}
