using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioCerrado;
    [SerializeField]
    private GameObject gameOver;

    private bool puertaAbierta;

    public bool PuertaAbierta { get => puertaAbierta; set => puertaAbierta = value; }

    private void OnMouseDown()
    {
        if (puertaAbierta)
        { 
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            audioCerrado.Play();
        }
        Debug.Log("I'm a Door");
    }
}
