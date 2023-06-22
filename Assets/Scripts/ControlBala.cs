using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour
{
    public GameObject particulasExplosion;
    public int dañoEnemigo, dañoJugador;
    public float tiempoActivo;

    private float tiempoDisparo;

    private void OnEnable()
    {
        tiempoDisparo = Time.time;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time - tiempoDisparo >= tiempoActivo)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ControlJugador>().QuitarVidasJugador(dañoEnemigo);
        }else if(other.CompareTag("Enemigo"))
        {
            other.GetComponent<ControlEnemigo>().QuitarVidasEnemigo(dañoJugador);
        }

        GameObject particulas = Instantiate(particulasExplosion, transform.position, Quaternion.identity);
        Destroy(particulas, 1);

        gameObject.SetActive(false);
    }
}
