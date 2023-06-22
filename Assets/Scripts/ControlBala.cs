using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour
{
    public GameObject particulasExplosion;
    public int da�oEnemigo, da�oJugador;
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
            other.GetComponent<ControlJugador>().QuitarVidasJugador(da�oEnemigo);
        }else if(other.CompareTag("Enemigo"))
        {
            other.GetComponent<ControlEnemigo>().QuitarVidasEnemigo(da�oJugador);
        }

        GameObject particulas = Instantiate(particulasExplosion, transform.position, Quaternion.identity);
        Destroy(particulas, 1);

        gameObject.SetActive(false);
    }
}
