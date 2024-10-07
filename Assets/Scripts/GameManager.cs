using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Respuesta
    //Azul RGBA(0.008,0.631,0.812,0.000)
    //Verde RGBA(0.008,0.722,0.255,0.000)
    //Guinda RGBA(0.604,0.047,0.196,0.000)
    //Violeta RGBA(0.788,0.447,0.980,0.000)
    //Morado RGBA(0.592,0.000,1.000,0.000)
    //Rojo RGBA(0.807,0.000,0.000,0.000)

    [SerializeField]
    private GameObject acertijo;
    [SerializeField]
    private GameObject[] velas; 
    [SerializeField]
    private Color[] respuesta;
    [SerializeField]
    private AudioSource audioIncorrecta;
    [SerializeField]
    private AudioSource audioCorrecto;
    [SerializeField]
    private Book book;
    [SerializeField]
    private Door door;
    [SerializeField]
    private GameObject menu;

    private bool respuestaCorrecta;
    private Queue<Color> ordenSeleccionado = new Queue<Color>();
    private Color colorLuz;
    

    private void Start()
    {
        colorLuz.r = 0.988f;
        colorLuz.g = 0.753f;
        colorLuz.b = 0.027f;
        colorLuz.a = 1;
    }

    private void Update()
    {
        Menu();
    }

    public void SalirAcertijo() 
    { 
        acertijo.SetActive(false);
    }

    public void OrdenSeleccionado(Color colorVela)
    {
        if (colorVela == null)
            Debug.Log("Color NULL");
        ordenSeleccionado.Enqueue(colorVela);
        if (ordenSeleccionado.Count == 6)
        {
            CompararRespuesta();
        }
    }

    private void CompararRespuesta()
    {
        for (int i = 0; i < respuesta.Length; i++)
        {
            if (respuesta[i] == ordenSeleccionado.Dequeue())
            {
                respuestaCorrecta = true;
            }
            else { break; }
        }

        if (respuestaCorrecta)
        {
            //Sonido de puerta desbloqueada
            audioCorrecto.Play();
            door.PuertaAbierta = true;
        }
        else
        {
            audioIncorrecta.Play();
            ReiniciarLuces();
            //Book -> puzzleStarted = False
            book.PuzzleStarted = false;

        }
    }

    private void ReiniciarLuces()
    {
        foreach (var obj in velas)
        {
            Collider colisionVelas = obj.GetComponent<BoxCollider>();
            obj.transform.GetChild(0).gameObject.SetActive(true);
            obj.transform.GetChild(1).gameObject.SetActive(true);
            obj.GetComponentInChildren<Light>().color = colorLuz;
            colisionVelas.enabled = false;
        }
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("the last revelation");
    }

    public void Resumir()
    { 
        menu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Salir()
    { 
        Application.Quit();
    }

    public void Menu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
