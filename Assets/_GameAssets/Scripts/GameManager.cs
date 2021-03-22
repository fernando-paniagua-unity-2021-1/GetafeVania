using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //¿Estado del juego?

    [SerializeField]
    private int puntuacion;
    [SerializeField]
    private bool sonido;
    [SerializeField]
    private float volumenSonido;
    [SerializeField]
    private int numeroVidas;
    //???
    [Header("User Interface")]
    [SerializeField]
    private Text textPuntuacion;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void AddPuntuacion(int incrementoPuntos) {
        puntuacion += incrementoPuntos;
        if (textPuntuacion != null)
        {
            textPuntuacion.text = puntuacion.ToString();
        }
    }
}
