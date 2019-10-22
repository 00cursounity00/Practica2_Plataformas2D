using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float velocidad;
    private float x, y;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(x) > 0)
        {
            rb.velocity = new Vector2(x * velocidad, 0);
        }
    }

    public void RecibirDaño(float daño)
    {

    }
}
