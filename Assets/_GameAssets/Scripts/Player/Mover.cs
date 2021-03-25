﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Fire1-->A, Fire2-->B, Fire3-->X, Fire4-->Y, Fire5-->Gatillo izquierdo
public class Mover : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Animator animator;
    private Rigidbody2D rb2d;
    private float x;

    private bool estaEnElSuelo = false;

    private int contadorSaltos=0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Obtenemos el valor del eje horizontal de control
        x = Input.GetAxis("Horizontal");
        //Corrigiendo la x para que los valores sean 0, 1 ó -1
        if (x > 0.001f) x = 1;
        if (x < -0.001f) x = -1;
        if (Mathf.Abs(x) > 0.001f) 
        {
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }
        //Si el valor absoluto de x es > 0, ejecuta la animación de andar
        //(si el valor absoluto de x es = 0, para la ejecución de andar)
        if (Mathf.Abs(x) > 0.001f)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        //Saltar
        if (Input.GetButtonDown("Fire1"))
        {
            Salta();
        }
    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Time.deltaTime * speed * x, rb2d.velocity.y);
    }
    private void Salta()
    {
        /*
        if (estaEnElSuelo) { 
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
        */
        
        if (contadorSaltos < 2)
        {
            GameManager gm = GameManager.Instance;
            if ((contadorSaltos==0) || (contadorSaltos==1 && gm.HasItem(Item.ItemValues.GemaAmarilla)))
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
            
            contadorSaltos++;
        } 
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        bool puedeSaltar = 
            collision.gameObject.CompareTag("Suelo") || 
            collision.gameObject.CompareTag("Pegajoso");
        if (puedeSaltar)
        {
            estaEnElSuelo = true;
            contadorSaltos = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        estaEnElSuelo = false;
    }
}
