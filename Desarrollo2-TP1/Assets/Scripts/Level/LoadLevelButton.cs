﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    

   /* private void Awake()
    {
        var btn = GetComponent<Button>();
        btn.onClick.AddListener(ChangeLevel);
    }*/

    public void ChangeLevel()
    {
        SceneManager.LoadScene("Nivel-1");
    }

    public void Menu()
    {       
        SceneManager.LoadScene("Title");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
