using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GameObject panelInventario;
    [SerializeField]
    private GameObject prefabItem;

    //Array de Imágenes correspondiente a los corazones
    public Image[] corazones;
    
    //Lista de items en el inventario
    public List<Item.ItemValues> inventario = new List<Item.ItemValues>();


    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }
    }

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
            if (PlayerPrefs.HasKey("Puntuacion"))
            {
                AddPuntuacion(PlayerPrefs.GetInt("Puntuacion"));
            }
            if (PlayerPrefs.HasKey("sonido"))
            {
                bool sonido = bool.Parse(PlayerPrefs.GetString("sonido"));
                float volumen = PlayerPrefs.GetFloat("volumen");
                if (sonido==false)
                {
                    AudioListener.volume = 0;
                } else
                {
                    AudioListener.volume = volumen;
                }
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

    public void GuardarCheckpoint(Vector3 position)
    {
        PlayerPrefs.SetFloat("x", position.x);
        PlayerPrefs.SetFloat("y", position.y);
        PlayerPrefs.SetFloat("z", position.z);
        PlayerPrefs.SetInt("Puntuacion", puntuacion);
        PlayerPrefs.Save();
    }

    public void AddItem(GameObject item)
    {
        //Agregar el nombre del item al inventario (es una lista de nombres)
        inventario.Add(item.GetComponentInChildren<Item>().GetItemName());

        //Creamos el item del UI
        GameObject nuevoItem = Instantiate(prefabItem, panelInventario.transform);
        Sprite sprite = item.GetComponentInChildren<SpriteRenderer>().sprite;
        nuevoItem.GetComponent<Image>().sprite = sprite;
    }
    public bool HasItem(Item.ItemValues itemBuscado)
    {
        foreach(Item.ItemValues item in inventario)
        {
            if (itemBuscado == item)
            {
                return true;
            }
        }
        return false;
    }
}
