using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abejorro : MonoBehaviour
{
    public int danyo;
    public bool picorro = true;
    public float tiempoReactivacion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!picorro) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<ElementoMovil>().CambiarSentido();
            collision.gameObject.GetComponent<ControlVida>().QuitarSalud(danyo);
            picorro = false;
            Invoke("Reactivar", tiempoReactivacion);
        }
    }
    private void Reactivar()
    {
        picorro = true;
    }
}
