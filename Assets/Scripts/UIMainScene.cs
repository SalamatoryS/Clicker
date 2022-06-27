using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainScene : MonoBehaviour
{
    GameManager gameManager;

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
}
