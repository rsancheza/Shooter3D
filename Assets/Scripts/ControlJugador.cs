using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    [Header("Vidas")]
    public int vidasActual;
    public int vidasMax;
    [Header("Movimiento")]
    public float velocidad;
    public float fuerzaSalto;
    [Header("Camara")]
    public float sensibilidadRaton;
    public float maxVistaX;
    public float minVistaX;
    private float rotacionX;
    private Camera camara;
    private Rigidbody fisica;
    private ControlArma arma;
    private void Awake()
    {
        camara = Camera.main;
        fisica = GetComponent<Rigidbody>();
        arma = GetComponent<ControlArma>();

        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        Time.timeScale = 1.0f;
        ControlHood.instancia.ActualizarNumBolas(arma.municionActual, arma.municionMax);
        ControlHood.instancia.ActualizarVida(vidasActual, vidasMax);
        ControlHood.instancia.ActualizarPuntuacion(0);
    }

    void Update()
    {
        if (ControlJuego.instancia.juegoPausado) return;

        Movimiento();
        VistaCamara();
        if (Input.GetButtonDown("Jump"))
        {
            Salto();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (arma.PuedeDisparar())
                arma.Disparar();
        }
    }

    private void Movimiento()
    {
        float x = Input.GetAxis("Horizontal") * velocidad;
        float z = Input.GetAxis("Vertical") * velocidad;
        //fisica.velocity = new Vector3 (x, fisica.velocity.y, z);
        Vector3 direccion = transform.right*x+transform.forward*z+transform.up*fisica.velocity.y;
        fisica.velocity = direccion;
    }
    private void VistaCamara()
    {
        float y = Input.GetAxis("Mouse X") * sensibilidadRaton;
        rotacionX += Input.GetAxis("Mouse Y") * sensibilidadRaton;
        rotacionX = Mathf.Clamp(rotacionX, minVistaX, maxVistaX);
        camara.transform.localRotation= Quaternion.Euler(-rotacionX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }
    private void Salto()
    {
        Ray rayo = new Ray(transform.position,Vector3.down);
        if (Physics.Raycast(rayo, 1.5f))
        {
            fisica.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    public void QuitarVidasJugador(int cantidad)
    {
        vidasActual -= cantidad;
        ControlHood.instancia.ActualizarVida(vidasActual, vidasMax);
        if (vidasActual <= 0)
            TerminaJugador();
    }
    void TerminaJugador()
    {
        Time.timeScale = 0f;
        ControlHood.instancia.EstablecerVentanaFinJuego(false);
    }

    public void IncrementarVida(int cantidadVida)
    {
        vidasActual = Mathf.Clamp(cantidadVida+vidasActual, 0, vidasMax);
        ControlHood.instancia.ActualizarVida(vidasActual, vidasMax);
    }

    public void IncrementarNumBolas(int cantidadBolas)
    {
        arma.municionActual = Mathf.Clamp(arma.municionActual+cantidadBolas, 0, arma.municionMax);
        ControlHood.instancia.ActualizarNumBolas(arma.municionActual, arma.municionMax);
    }
}
