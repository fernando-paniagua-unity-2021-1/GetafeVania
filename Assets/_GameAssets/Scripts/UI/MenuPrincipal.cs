using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        PlayerPrefs.DeleteKey("x");
        PlayerPrefs.DeleteKey("y");
        PlayerPrefs.DeleteKey("z");
        PlayerPrefs.DeleteKey("Puntuacion");
        PlayerPrefs.Save();
        SceneManager.LoadScene("Scene1");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Continuar()
    {
        SceneManager.LoadScene("Scene1");
    }
}
