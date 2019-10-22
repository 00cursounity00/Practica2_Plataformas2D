using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject panelCorazones;
    [SerializeField] GameObject prefabCorazon;
    private GameManager gm;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        int numeroCorazonesActuales = gm.GetNumeroCorazonesMax();

        for(int i = 0; i < numeroCorazonesActuales; i++)
        {
            Instantiate(prefabCorazon, panelCorazones.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
