using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velas : MonoBehaviour
{
    [SerializeField]
    private GameObject luz, fuego;
    [SerializeField]
    private GameManager gameManager;
    private Color colorLuz;
    

    private void OnMouseDown()
    {
        colorLuz = luz.GetComponent<Light>().color;
        luz.SetActive(false);
        fuego.SetActive(false);
        gameManager.OrdenSeleccionado(colorLuz);
        Debug.Log("Soy de color: " + colorLuz);
    }
}
