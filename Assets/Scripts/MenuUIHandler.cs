using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI recordText;

    public InputField NameInputField;
    
    private void Start()
    {
        //recordText.text = MainManager.Instance.recordPlayer + " - " + MainManager.Instance.recordScore;
    }

    public void StartNew()
    {
        //Debug.Log(NameInputField.Text);
        //MainManager.Instance.playerName = NameInputField.Text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity player
    #endif
    }

}
