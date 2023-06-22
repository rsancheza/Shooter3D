using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlHood : MonoBehaviour
{
    [Header("Hood")]
    public TextMeshProUGUI puntuacionTexto;
    public TextMeshProUGUI numBolasTexto;
    public Image barraVidas;

    [Header("VentanaPausa")]
    public GameObject ventanaPausa;


    [Header("VentanaFinJuego")]
    public GameObject ventanaFinJuego;
    public TextMeshProUGUI resultadoTexto;

    public static ControlHood instancia;

    private void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActualizarVida(int vidaActual, int vidaMax)
    {
        barraVidas.fillAmount = (float) vidaActual / (float) vidaMax;
    }

    public void ActualizarNumBolas(int numBolasActual, int numBolasMax)
    {
        numBolasTexto.text = numBolasActual + "/" + numBolasMax;
    }

    public void CambiarEstadoVentanaPausa(bool estado)
    {
        ventanaPausa.SetActive(estado);
    }

    public void EstablecerVentanaFinJuego(bool ganado)
    {
        ventanaFinJuego.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        resultadoTexto.text = ganado ? "HAS GANADO" : "HAS PERDIDO";
        resultadoTexto.color = ganado ? Color.green : Color.red;
    }

    public void ActualizarPuntuacion(int puntos)
    {
        puntuacionTexto.text = puntos.ToString("0000");
    }

    public void OnBotonMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnBotonVolver()
    {
        ControlJuego.instancia.CambiarPausa();
    }

    public void OnBotonEmpezar()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void OnBotonSalir()
    {
        Application.Quit();
    }

}
