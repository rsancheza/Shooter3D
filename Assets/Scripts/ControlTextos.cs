using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlTextos : MonoBehaviour
{
    public void OnMouseDown()
    {
        Debug.Log("Funciona");
        this.GetComponent<TextMeshProUGUI>().color = Color.white;
    }
}
