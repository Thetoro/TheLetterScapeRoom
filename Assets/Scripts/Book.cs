using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField]
    private GameObject acertijo;
    [SerializeField]
    private GameObject[] velas;
    [SerializeField]
    private Color[] colores;

    private List<int> possible;

    private bool puzzleStarted;

    public bool PuzzleStarted { get => puzzleStarted; set => puzzleStarted = value; }

    private void OnMouseDown()
    {
        Debug.Log("I'm a book!");
        acertijo.SetActive(true);
        EmpezarAcertijo();
    }

    private void EmpezarAcertijo()
    {
        if (!puzzleStarted)
        {
            possible = Enumerable.Range(0, 6).ToList();
            for (int i = 0; i < 6; i++)
            {
                int index = Random.Range(0, possible.Count);
                velas[i].gameObject.GetComponentInChildren<Light>().color = colores[possible[index]];
                possible.RemoveAt(index);
                Debug.Log(velas[i] + " Color: " + velas[i].gameObject.GetComponentInChildren<Light>().color);
            }
            foreach (var obj in velas)
            {
                Collider colisionVelas = obj.GetComponent<BoxCollider>();
                colisionVelas.enabled = true;
            }
            puzzleStarted = true;
        }
    }
}
