using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] float fuerza;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoDisparo;
    private AudioSource[] audios;
    private float x, y;
    private Rigidbody2D rb;
    private GameManager gm;
    private Animator animator;
    private const int AUDIO_SHURIKEN = 0;
    private const int AUDIO_JUMP = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        audios = GetComponents<AudioSource>();
    }
    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (x > 0)
        {
            x = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (x < 0)
        {
            x = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("dispararNinjutsu", true);
            Invoke("QuitarDispararNinjutsu", 0.2f);
            Disparar();
            //audios[AUDIO_SHURIKEN].Play();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            /*animator.SetBool("dispararNinjutsu", true);
            Invoke("QuitarDispararNinjutsu", 0.1f);*/
            Saltar();
            //audios[AUDIO_JUMP].Play();
        }
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(x) > 0.1f)
        {
            animator.SetBool("walking", true);
            rb.velocity = new Vector2(x * velocidad, 0);
        }
        else
        {
            animator.SetBool("walking", false);
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void RecibirDano(float dano)
    {
        gm.QuitarVida(dano);
    }

    private void Disparar()
    {
        GameObject proyectil = Instantiate(prefabProyectil, puntoDisparo.position, puntoDisparo.rotation);
        proyectil.GetComponent<Rigidbody2D>().AddForce(puntoDisparo.right * fuerza);
    }

    private void QuitarDispararNinjutsu()
    {
        animator.SetBool("dispararNinjutsu", false);
    }

    private void Saltar()
    {

    }
}
