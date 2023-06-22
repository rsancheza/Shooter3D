using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioArmas : MonoBehaviour
{
    public GameObject[] armas;
    public GameObject[] balas;
    public AudioClip[] sonidos;
    public float[] cadencia;
    public int armaSeleccionada = 0;

    private ControlArma controlArma;
    private PoolDeObjetos pool;

    void Start()
    {
        controlArma = this.transform.parent.GetComponent<ControlArma>();
        pool = this.transform.parent.GetComponent<PoolDeObjetos>();
        SeleccionarArma();
    }

    
    void Update()
    {
        int armaAnterior = armaSeleccionada;

        if (Input.GetButtonDown("Fire2"))
        {
            if (armaSeleccionada >= armas.Length - 1)
                armaSeleccionada = 0;
            else
                armaSeleccionada++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (armaSeleccionada >= armas.Length - 1)
                armaSeleccionada = 0;
            else
                armaSeleccionada++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (armaSeleccionada <= 0)
                armaSeleccionada = armas.Length-1;
            else
                armaSeleccionada--;
        }

        if (armaAnterior != armaSeleccionada)
            SeleccionarArma();

        
    }

    void SeleccionarArma()
    {
        int i = 0;
        foreach (Transform arma in transform)
        {
            if (arma.gameObject.layer == LayerMask.NameToLayer("Arma"))
            {
                if (i == armaSeleccionada)
                {
                    arma.gameObject.SetActive(true);
                    controlArma.sonidoDisparo = sonidos[i];
                    controlArma.frecuenciaDisparo = cadencia[i];
                    pool.objetoPrefab = balas[i];
                }
                else
                    arma.gameObject.SetActive(false);

                i++;
            }
        }
    }
}
