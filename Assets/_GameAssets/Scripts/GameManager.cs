using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int numeroCorazones;
    [SerializeField] int numeroCorazonesMax;
    [SerializeField] float vidaCorazon;
    [SerializeField] float vidaCorazonMax;
    [SerializeField] int numeroVidas;
    [SerializeField] int numeroVidasMax;
    [SerializeField] int puntuacion;
    private UIManager ui;

    private void Start()
    {
        ui = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    public int GetNumeroCorazones()
    {
        return numeroCorazones;
    }

    public void QuitarVida(float dano)
    {
        float resto = vidaCorazon - dano;
        vidaCorazon = resto;

        if (vidaCorazon <= 0)
        {
            ui.ActualizarVida(numeroCorazones, 0);
            numeroCorazones--;
            print(vidaCorazon);
            vidaCorazon = vidaCorazonMax;
            print(vidaCorazon);

            if (numeroCorazones == 0)
            {
                RestarVida();
            }
        }

        if (resto < 0)
        {
            QuitarVida(resto * -1);
        }

        ui.ActualizarVida(numeroCorazones, vidaCorazon);
    }

    private void RestarVida()
    {

    }

    public void SumarPuntos(int puntos)
    {
        puntuacion += puntos;
        ui.ActualizarPuntuacion(puntuacion);
    }
}
