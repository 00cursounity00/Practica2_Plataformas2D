using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numeroCorazones;
    [SerializeField] int numeroCorazonesMax;
    [SerializeField] float vidaCorazon;
    [SerializeField] float vidaCorazonMax;
    [SerializeField] int numeroVidas;
    [SerializeField] int numeroVidasMax;

    public int GetNumeroCorazonesMax()
    {
        return numeroCorazonesMax;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
