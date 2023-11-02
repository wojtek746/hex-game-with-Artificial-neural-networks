using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borgoCore : MonoBehaviour
{
    borgoBattle battle;
    borgoCreate create; 
    public string[] objects = new string[] { "HQ", "Brawler", "Medic", "Mutant", "Super_Mutant", "Officer", "Super_Officer", "Butcher", "Assassin", "NetFlighter", "Scout", "Battle", "Move", "Grenade" }; 
    public int[] shop = new int[3];
    public List<int> emptyHexs = new List<int>();

    public void StartGame()
    {
        battle = FindObjectsOfType<borgoBattle>()[0];
        create = FindObjectsOfType<borgoCreate>()[0];

        battle.StartGame();
        create.StartGame();
        //StartCoroutine(create.Create("Officer", -2, 4)); 
        //zamiast neural network
        for(int i = 1; i <= 19; i++)
        {
            GameObject currenthex = GameObject.Find("hex " + i);
            if(currenthex != null)
            {
                Transform currentHex = currenthex.transform.Find("hex");
                if(currentHex == null)
                {
                    emptyHexs.Add(i); 
                }
            }
        }
        int random = emptyHexs[Random.Range(0, emptyHexs.Count)];

        StartCoroutine(create.Create("HQ", random, Random.Range(0, 7)));
        emptyHexs = new List<int>();
    }

    public void turn()
    {
        for(int i = 0; i < 3; i++)
        {
            shop[i] = Random.Range(1, objects.Length); 
            StartCoroutine(create.Create(objects[shop[i]], (i * -1) - 1, 0));
        }
        for (int i = 0; i < 3; i++)
        {
            if (objects[shop[i]] != "Battle" && objects[shop[i]] != "Move" && objects[shop[i]] != "Grenade")
            {
                //zamiast neural network
                for (int j = 1; j <= 19; j++)
                {
                    GameObject currenthex = GameObject.Find("hex " + j);
                    if (currenthex != null)
                    {
                        Transform currentHex = currenthex.transform.Find("hex");
                        if (currentHex == null)
                        {
                            emptyHexs.Add(j);
                        }
                    }
                }
                int random = emptyHexs[Random.Range(0, emptyHexs.Count)];

                StartCoroutine(create.Create(objects[shop[i]], random, Random.Range(0, 6)));
            }
            else
            {

            }
        }
        for (int i = 1; i <= 3; i++)
        {
            GameObject currenthex = GameObject.Find("borgo " + i);
            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");
                if (hex != null)
                {
                    Destroy(hex.gameObject);
                }
            }
        }
    }

    public void InitiativeBattle(int initiative)
    {
        battle.InitiativeBattle(initiative); 
    }
}
