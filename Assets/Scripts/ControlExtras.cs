using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoExtra
{
    Vida,
    Bolas
}

public class ControlExtras : MonoBehaviour
{
    public int cantidad;
    public TipoExtra tipo;
    private void OnTriggerEnter(Collider other)
    {
        ControlJugador jugador = null;

        if (other.CompareTag("Player"))
        {
            jugador = other.GetComponent<ControlJugador>();


            switch (tipo)
            {
                case TipoExtra.Vida:
                    jugador.IncrementarVida(cantidad);
                    break;
                case TipoExtra.Bolas:
                    jugador.IncrementarNumBolas(cantidad);
                    break;
            }
            Destroy(gameObject);
        }
    }
}
