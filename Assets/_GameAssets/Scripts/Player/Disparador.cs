using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject prefabProyectil;
    public Transform puntoSpawn;
    public float fuerzaDisparo;
    public float fuerzaVertical;
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            GameObject proyectil = Instantiate(prefabProyectil, puntoSpawn.position, puntoSpawn.rotation);
            proyectil.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDisparo * transform.localScale.x, fuerzaVertical));
        }
    }
}
