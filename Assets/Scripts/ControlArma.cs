using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlArma : MonoBehaviour
{
    //public GameObject bolaPrefab;
    public Transform puntoSalida;

    public int municionActual;
    public int municionMax;
    public bool municionInfinita;
    public float velocidadBola;
    public float frecuenciaDisparo;
    public AudioClip sonidoDisparo;

    private AudioSource audioSource;
    private bool esJugador;
    private float ultimoTiempoDisparo;
    private PoolDeObjetos bolaPool;

    public void Awake()
    {
        if (GetComponent<ControlJugador>())
        {
            esJugador = true;
        }
        bolaPool = GetComponent<PoolDeObjetos>();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool PuedeDisparar()
    {
        if (Time.time - ultimoTiempoDisparo >= frecuenciaDisparo)
            if (municionActual >0 || municionInfinita == true)
            return true;
        return false; 
    }

    public void Disparar()
    {
        ultimoTiempoDisparo = Time.time;
        municionActual--;
        GameObject bola = bolaPool.getObjeto();
        bola.transform.position = puntoSalida.position;
        bola.transform.rotation = puntoSalida.rotation;
        //GameObject bola = Instantiate(bolaPrefab, puntoSalida.position, puntoSalida.rotation);
        bola.GetComponent<Rigidbody>().velocity = puntoSalida.forward * velocidadBola;
        audioSource.PlayOneShot(sonidoDisparo);
        if (esJugador)
        {
            ControlHood.instancia.ActualizarNumBolas(municionActual, municionMax);
        }
    }

}
