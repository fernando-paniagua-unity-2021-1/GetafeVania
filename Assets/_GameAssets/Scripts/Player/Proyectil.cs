using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    //Deberes: HACER QUE EL PROYECTIL MATE A LOS ENEMIGOS, CADENCIA DE DISPARO, HACER MÁS ENEMIGOS

    public float rotationSpeed;
    public float timeToDestroy;
    
    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.parent.gameObject, timeToDestroy);
    }
}
