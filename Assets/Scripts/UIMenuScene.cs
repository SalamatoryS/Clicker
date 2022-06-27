using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuScene : MonoBehaviour
{
    public InputField text;
    
    public Text champText;

    private void Start()
    {
        DataBetweenScenes.Instance.LoadUser();
        if (DataBetweenScenes.Instance.maxScore == 0)
            champText.text = "Our Champion is missing";
        else
        {
            champText.text = "Our Champion is \n" + DataBetweenScenes.Instance.maxScoreName +
                "\nwith " + DataBetweenScenes.Instance.maxScore + " Score";
        }
    }
    public void StartGame()
    {
       DataBetweenScenes.Instance.userName = text.text;
       SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit():
#endif
    }

    public void DeleteData()
    {
        DataBetweenScenes.Instance.DeleteResult();
        SceneManager.LoadScene(0);
    }
}
