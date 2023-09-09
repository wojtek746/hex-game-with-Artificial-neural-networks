using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public borgoCreate borgo; 


    public List<int> getId(int which)
    {
        List<int> lista = new List<int>();

        return lista; 
    }

    public void Start()
    {
        borgo = FindObjectsOfType<borgoCreate>()[0];

        borgo.StartGame();
        StartCoroutine(borgo.Create("Brawler", 3, 4)); 
    }
}
