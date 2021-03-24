using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int puntuacion;
    public GameObject prefabPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gm = GameManager.Instance;
            gm.AddPuntuacion(puntuacion);
            //Puntuación volante?
            (Instantiate(prefabPoints, transform.position,transform.rotation)).
                GetComponent<FlyingScore>().SetScoreValue(puntuacion);
            //Destrucción de la moneda
            Destroy(transform.parent.gameObject);
        }
    }
}
