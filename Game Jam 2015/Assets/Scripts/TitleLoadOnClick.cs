﻿using UnityEngine;
using System.Collections;

public class TitleLoadOnClick : MonoBehaviour
{

    //public GameObject loadingImage;

    public void LoadScene(int level)
    {
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
        Debug.Log("Seleccionado " + level);
    }

    public void Exit() {
        Application.Quit();
    }
}