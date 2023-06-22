using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDeObjetos : MonoBehaviour
{
    public GameObject objetoPrefab;
    public int numObjetoOnStart;

    private List<GameObject> objetosPoled = new List<GameObject>();
    void Start()
    {
        for (int x = 0; x < numObjetoOnStart; x++)
            crearNuevoObjeto();
    }
    private GameObject crearNuevoObjeto()
    {
        GameObject objeto = Instantiate(objetoPrefab);
        objeto.SetActive(false);
        objetosPoled.Add(objeto);
        return objeto;
    }

    public GameObject getObjeto()
    {
        GameObject objeto = objetosPoled.Find(x => x.activeInHierarchy == false);
        if (objeto == null)
        {
            objeto = crearNuevoObjeto();
        }
        objeto.SetActive(true);
        return objeto;
    }
    void Update()
    {
        
    }
}
