using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.Animations;

public class ControlEnemigo : MonoBehaviour
{
    [Header("Estadisticas")]
    public int vidasActual;
    public int vidasMax;
    public int puntuacionEnemigo;

    [Header("Movimiento")]
    public float velocidad;
    public float velocidad1;
    public float rangoAtaque;
    public float yPathOffset;
    public bool siemprePersigue;
    public float rangoPerseguir;
    private List<Vector3> listaCaminos;
    private ControlArma arma;
    private ControlJugador objetivo;
    void Start()
    {
        arma=GetComponent<ControlArma>();
        objetivo=FindObjectOfType<ControlJugador>();
        InvokeRepeating("ActualizarCaminos", 0.0f, 0.5f);
    }

    void ActualizarCaminos()
    {
        NavMeshPath caminoCalculado = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, objetivo.transform.position, NavMesh.AllAreas, caminoCalculado);
        listaCaminos = caminoCalculado.corners.ToList();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, objetivo.transform.position);
        if (distancia < rangoPerseguir)
        {
            if (distancia > rangoAtaque)
            {
                PerseguirObjetivo();
            }
            else
            {
                if (distancia < rangoAtaque)
                {
                    if (arma.PuedeDisparar())

                        arma.Disparar();
                }
            }
        }
    }
    private void PerseguirObjetivo()
    {
        if (listaCaminos == null || listaCaminos.Count == 0)
            return;
        transform.position = Vector3.MoveTowards(transform.position, listaCaminos[0] +
                                     new Vector3(0, yPathOffset, 0), velocidad1 * Time.deltaTime);
        transform.LookAt(objetivo.transform);
        if (transform.position == listaCaminos[0]+new Vector3(0, yPathOffset,0))
        {
            listaCaminos.RemoveAt(0);
        }
    }
    public void QuitarVidasEnemigo(int cantidad)
    {
        vidasActual -= cantidad;
        ControlJuego.instancia.PonerPuntuacion(puntuacionEnemigo);
        if (vidasActual <= 0)
            Destroy(gameObject);
    }
}
