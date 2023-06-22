using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{

    public int puntuacionParaGanar;
    public int puntuacionActual;
    public bool juegoPausado;

    public static ControlJuego instancia;

    private void Awake()
    {
        instancia = this;
    }

    void Start()
    {
         
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            CambiarPausa();
        }

        int numEnemigos = GameObject.FindGameObjectsWithTag("Enemigo").Length;
        if(numEnemigos <= 0)
            GanarJuego();
    }

    public void CambiarPausa()
    {
        juegoPausado = !juegoPausado;
        Time.timeScale = (juegoPausado ? 0.0f : 1f);
        Cursor.lockState = (juegoPausado) ? CursorLockMode.None : CursorLockMode.Locked;
        ControlHood.instancia.CambiarEstadoVentanaPausa(juegoPausado);
    }

    public void GanarJuego()
    {
        Time.timeScale = 0f;
        ControlHood.instancia.EstablecerVentanaFinJuego(true);
    }

    public void PonerPuntuacion(int puntuacion)
    {
        puntuacionActual += puntuacion;
        ControlHood.instancia.ActualizarPuntuacion(puntuacionActual);
        /*if (puntuacionActual >= puntuacionParaGanar)
            GanarJuego();*/
    }

}
