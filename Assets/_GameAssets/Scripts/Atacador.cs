using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacador : MonoBehaviour
{
    [SerializeField] float fuerza;
    [SerializeField] float dano;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1,1.5f) * fuerza;
            collision.gameObject.GetComponent<Player>().RecibirDano(dano);
        }
    }
}
