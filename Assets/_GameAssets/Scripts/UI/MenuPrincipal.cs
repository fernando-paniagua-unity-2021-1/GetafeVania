﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void Salir()
    {
        Application.Quit();
    }
}