using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad;
    [SerializeField] float fuerza;
    [SerializeField] float fuerzaSalto;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] Transform puntoDisparo;
    [SerializeField] Transform detectorSuelo;
    [SerializeField] LayerMask layerSuelo;
    [SerializeField] PhysicsMaterial2D pm2d;
    private AudioSource[] audios;
    private float x, y;
    private Rigidbody2D rb;
    private GameManager gm;
    private Animator animator;
    private const int AUDIO_SHURIKEN = 0;
    private const int AUDIO_JUMP = 1;
    private bool enSuelo = false;

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
        ObtenerEnSuelo();
        if (x > 0)
        {
            //x = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (x < 0)
        {
            //x = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("disparando", true);
            Invoke("QuitarDisparar", 0.1f);
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
            animator.SetBool("corriendo", true);
            rb.velocity = new Vector2(x * velocidad, rb.velocity.y);
        }
        else
        {
            animator.SetBool("corriendo", false);
            //rb.velocity = new Vector2(0, 0);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }*/

    public void RecibirDano(float dano)
    {
        gm.QuitarVida(dano);
    }

    private void Disparar()
    {
        GameObject proyectil = Instantiate(prefabProyectil, puntoDisparo.position, puntoDisparo.rotation);
        proyectil.GetComponent<Rigidbody2D>().AddForce(puntoDisparo.right * fuerza);
    }

    private void QuitarDisparar()
    {
        animator.SetBool("disparando", false);
    }

    private void Saltar()
    {
        if (ObtenerEnSuelo())
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            //rb.AddForce(new Vector2(0, 1) * fuerzaSalto);
        }
    }

    private bool ObtenerEnSuelo()
    {
        Collider2D cd = Physics2D.OverlapBox(detectorSuelo.position, new Vector2(0.457f,0.1f), 0, layerSuelo);

        if (cd != null)
        {
            animator.SetBool("saltando", true);
            Invoke("QuitarDisparar", 0.1f);
            GetComponent<CapsuleCollider2D>().sharedMaterial = null;
            return true;
        }

        GetComponent<CapsuleCollider2D>().sharedMaterial = pm2d;
        return false;
    }

    private void QuitarSaltar()
    {
        animator.SetBool("saltando", false);
    }
}
