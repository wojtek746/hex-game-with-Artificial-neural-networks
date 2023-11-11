using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hegemoniaCore : MonoBehaviour
{
    hegemoniaBattle battle;
    hegemoniaCreate create;
    around a;
    Core core;

    public string[] objects = new string[] { "HQ", "Runner", "Boss", "Brute", "Ganger", "Gladiator", "Quartermaster", "Officer", "Officer2", "NetFlighter", "Guard", "SuperNet", "Transport", "UniversalSolidier", "Scout", "Battle", "Move", "Push", "Sniper" };
    public int[] shop = new int[3];
    public List<int> emptyHexs = new List<int>();

    public void StartGame()
    {
        battle = FindObjectsOfType<hegemoniaBattle>()[0];
        create = FindObjectsOfType<hegemoniaCreate>()[0];
        core = FindObjectsOfType<Core>()[0];
        a = FindObjectsOfType<around>()[0];

        battle.StartGame();
        create.StartGame();
        //StartCoroutine(create.Create("Officer", -2, 4)); 
        //zamiast neural network
        for (int i = 1; i <= 19; i++)
        {
            GameObject currenthex = GameObject.Find("hex " + i);
            if (currenthex != null)
            {
                Transform currentHex = currenthex.transform.Find("hex");
                if (currentHex == null)
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
        for (int i = 0; i < 3; i++)
        {
            shop[i] = Random.Range(1, objects.Length);
            StartCoroutine(create.Create(objects[shop[i]], (i * -1) - 1, 0));
        }
        for (int i = 0; i < 3; i++)
        {
            if (objects[shop[i]] != "Battle" && objects[shop[i]] != "Move" && objects[shop[i]] != "Push" && objects[shop[i]] != "Sniper")
            {
                //zamiast neural network
                emptyHexs = new List<int>();
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
                int random = 0;
                if (emptyHexs.Count > 0)
                {
                    random = emptyHexs[Random.Range(0, emptyHexs.Count)];
                    //

                    StartCoroutine(create.Create(objects[shop[i]], random, Random.Range(0, 6)));
                }

                GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                if (hegemoniaShop != null)
                {
                    Transform hex = hegemoniaShop.transform.Find("hex");
                    if (hex != null)
                    {
                        Destroy(hex.gameObject);
                    }
                }
            }
            else
            {
                if (objects[shop[i]] == "Battle")
                {
                    //zamiast neural network
                    bool random = (Random.Range(0, 2) == 0);
                    //

                    if (random)
                    {
                        core.battle();
                    }

                    GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                    if (hegemoniaShop != null)
                    {
                        Transform hex = hegemoniaShop.transform.Find("hex");
                        if (hex != null)
                        {
                            Destroy(hex.gameObject);
                        }
                    }
                }
                else if (objects[shop[i]] == "Move")
                {
                    //zamiast neural network
                    emptyHexs = new List<int>();
                    for (int j = 1; j <= 19; j++)
                    {
                        GameObject currenthex = GameObject.Find("hex " + j);
                        if (currenthex != null)
                        {
                            Transform currentHex = currenthex.transform.Find("hex");
                            if (currentHex != null)
                            {
                                Property currentProperty = currentHex.GetComponent<Property>();
                                if (currentProperty != null)
                                {
                                    if (currentProperty.nameSztab == "hegemonia")
                                    {
                                        emptyHexs.Add(j);
                                    }
                                }
                            }
                        }
                    }
                    int random1 = 0;
                    List<int> newHexs = new List<int>();
                    if (emptyHexs.Count > 0)
                    {
                        while (true)
                        {
                            random1 = emptyHexs[Random.Range(0, emptyHexs.Count)];
                            for (int j = 0; j < 6; j++)
                            {
                                GameObject currenthex = GameObject.Find("hex " + (a.a(random1, j, 0)));
                                if (currenthex != null)
                                {
                                    Transform currentHex = currenthex.transform.Find("hex");
                                    if (currentHex == null)
                                    {
                                        newHexs.Add(a.a(random1, j, 0));
                                    }
                                }
                            }
                            if (newHexs.Count > 0)
                            {
                                break;
                            }
                        }
                    }
                    int random2 = newHexs[Random.Range(0, newHexs.Count)];
                    //

                    GameObject hex1 = GameObject.Find("hex " + random1);
                    GameObject hex2 = GameObject.Find("hex " + random2);

                    UnityEngine.Debug.Log($"move: z {random1} do {random2}");

                    if (hex1 != null && hex2 != null)
                    {
                        Transform hex = hex1.transform.Find("hex");
                        if (hex != null)
                        {
                            hex.SetParent(hex2.transform);
                            hex.localPosition = new Vector3(0, 0, -1);
                        }
                    }

                    GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                    if (hegemoniaShop != null)
                    {
                        Transform hex = hegemoniaShop.transform.Find("hex");
                        if (hex != null)
                        {
                            Destroy(hex.gameObject);
                        }
                    }
                }
                else if (objects[shop[i]] == "Push")
                {
                    //zamiast neural network
                    emptyHexs = new List<int>();
                    for (int j = 1; j <= 19; j++)
                    {
                        GameObject currenthex = GameObject.Find("hex " + j);
                        if (currenthex != null)
                        {
                            Transform currentHex = currenthex.transform.Find("hex");
                            if (currentHex != null)
                            {
                                Property currentProperty = currentHex.GetComponent<Property>();
                                if (currentProperty != null)
                                {
                                    if (currentProperty.nameSztab != "hegemonia")
                                    {
                                        emptyHexs.Add(j);
                                    }
                                }
                            }
                        }
                    }
                    int random1 = 0;
                    List<int> newHexs = new List<int>();
                    if (emptyHexs.Count > 0)
                    {
                        while (true)
                        {
                            random1 = emptyHexs[Random.Range(0, emptyHexs.Count)];
                            for (int j = 0; j < 6; j++)
                            {
                                GameObject currenthex = GameObject.Find("hex " + (a.a(random1, j, 0)));
                                if (currenthex != null)
                                {
                                    Transform currentHex = currenthex.transform.Find("hex");
                                    if (currentHex == null)
                                    {
                                        newHexs.Add(a.a(random1, j, 0));
                                    }
                                }
                            }
                            if (newHexs.Count > 0)
                            {
                                break;
                            }
                        }
                    }
                    int random2 = newHexs[Random.Range(0, newHexs.Count)];
                    //

                    GameObject hex1 = GameObject.Find("hex " + random1);
                    GameObject hex2 = GameObject.Find("hex " + random2);

                    UnityEngine.Debug.Log($"move: z {random1} do {random2}");

                    if (hex1 != null && hex2 != null)
                    {
                        Transform hex = hex1.transform.Find("hex");
                        if (hex != null)
                        {
                            hex.SetParent(hex2.transform);
                            hex.localPosition = new Vector3(0, 0, -1);
                        }
                    }

                    GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                    if (hegemoniaShop != null)
                    {
                        Transform hex = hegemoniaShop.transform.Find("hex");
                        if (hex != null)
                        {
                            Destroy(hex.gameObject);
                        }
                    }
                }
                else if (objects[shop[i]] == "Sniper")
                {
                    //zamiast neural network
                    emptyHexs = new List<int>();
                    for (int j = 1; j <= 19; j++)
                    {
                        GameObject currenthex = GameObject.Find("hex " + j);
                        if (currenthex != null)
                        {
                            Transform currentHex = currenthex.transform.Find("hex");
                            if (currentHex != null)
                            {
                                Property currentProperty = currentHex.GetComponent<Property>();
                                if (currentProperty != null)
                                {
                                    if (currentProperty.nameSztab != "hegemonia" && currentProperty.name != "sztab")
                                    {
                                        emptyHexs.Add(j);
                                    }
                                }
                            }
                        }
                    }
                    int random = 0;
                    if (emptyHexs.Count > 0)
                    {
                        random = emptyHexs[Random.Range(0, emptyHexs.Count)];
                        //

                        GameObject currenthex = GameObject.Find("hex " + random);
                        if (currenthex != null)
                        {
                            Transform currentHex = currenthex.transform.Find("hex");
                            if (currentHex != null)
                            {
                                Destroy(currentHex.gameObject);
                            }
                        }
                    }

                    GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                    if (hegemoniaShop != null)
                    {
                        Transform hex = hegemoniaShop.transform.Find("hex");
                        if (hex != null)
                        {
                            Destroy(hex.gameObject);
                        }
                    }
                }
            }
        }
    }

    public void InitiativeBattle(int initiative)
    {
        battle.InitiativeBattle(initiative);
    }
}
