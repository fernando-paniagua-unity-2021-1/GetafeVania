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
    private int numeroVidas;//Número de vidas totales
    [SerializeField]
    private int vidaMaxima;//Salud por cada vida
    [SerializeField]
    private int vidaActual;//Cantidad de vida de la vida actual
    //???
    [Header("User Interface")]
    [SerializeField]
    private Text textPuntuacion;
    [SerializeField]
    private GameObject panelCorazonLleno;
    [SerializeField]
    private GameObject corazonLleno;
    [SerializeField]
    private GameObject panelCorazonVacio;
    [SerializeField]
    private GameObject corazonVacio;

    //Array de Imágenes correspondiente a los corazones
    public Image[] corazones;


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
            //Damos dimensión al array de corazones
            corazones = new Image[numeroVidas];
            vidaActual = vidaMaxima;
            for(int i=0;i<numeroVidas; i++)
            {
                //Creación y asignación de padre en un paso
                GameObject corazon = Instantiate(corazonLleno, panelCorazonLleno.transform);
                //Almacenamos cada corazón en su posición en el array
                corazones[i]=corazon.GetComponent<Image>();
                
                Instantiate(corazonVacio, panelCorazonVacio.transform);
                /*
                //Creación y asignación de padre en dos pasos
                GameObject x = Instantiate(corazonLleno);
                x.transform.SetParent(panelCorazonLleno.transform);
                */
                /*
                //Creación no asignándole padre (lo crea como hijo del raiz)
                Instantiate(corazonLleno);
                */
            }
        }
    }

    public void AddPuntuacion(int incrementoPuntos) {
        puntuacion += incrementoPuntos;
        if (textPuntuacion != null)
        {
            textPuntuacion.text = puntuacion.ToString();
        }
    }

    //public void HacerDanyo(int danyo)
    //{
    //    vidaActual -= danyo;
    //    corazones[numeroVidas - 1].fillAmount = (float)vidaActual / (float)vidaMaxima;
    //    if (vidaActual <= 0)
    //    {
    //        vidaActual = vidaMaxima - Mathf.Abs(vidaActual);
    //        numeroVidas--;
    //        corazones[numeroVidas - 1].fillAmount = (float)vidaActual / (float)vidaMaxima;
    //    }
    //}

    public void HacerDanyo(int danyo)
    {
        if (numeroVidas <= 0) return;
        vidaActual -= danyo;
        corazones[numeroVidas - 1].fillAmount = 
            (float)vidaActual / (float)vidaMaxima;
        if (vidaActual <= 0)
        {
            int vidaResidual = Mathf.Abs(vidaActual);
            numeroVidas--;
            if (numeroVidas <= 0)
            {
                print("GAME OVER");
                return;
            }
            vidaActual = vidaMaxima;
            if (vidaResidual>0)
            {
                HacerDanyo(vidaResidual);
            }
        }
    }
}
