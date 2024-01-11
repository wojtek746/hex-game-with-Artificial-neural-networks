using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hegemoniaCore : MonoBehaviour
{
    hegemoniaBattle battle;
    hegemoniaCreate create;
    around a;
    Core core;
    private NeuralNetwork siec;

    //                                        0       1        2        3        4           5              6            7           8           9            10        11           12              13              14        15       16      17      18
    public string[] objects = new string[] { "HQ", "Runner", "Boss", "Brute", "Ganger", "Gladiator", "Quartermaster", "Officer", "Officer2", "NetFlighter", "Guard", "SuperNet", "Transport", "UniversalSolidier", "Scout", "Battle", "Move", "Push", "Sniper" };
    public string[] objects_neural = new string[] { "HQ", "biegacz", "boss", "bydlak", "ganger", "gladiator", "kwatermistrz", "oficer", "oficer2", "sieciarz", "straznik", "supersieciarz", "transport", "uniwersalnyzolnierz", "zwiadowca", "Battle", "Move", "Push", "Sniper" };
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
        GameObject currenthex1 = GameObject.Find("neuralNetwork");
        if (currenthex1 != null)
        {
            Transform hex = currenthex1.transform;

            if (hex != null)
            {
                NeuralNetwork currentProperty = hex.GetComponent<NeuralNetwork>();

                if (currentProperty != null)
                {
                    siec = currentProperty;
                }
            }
        }

        //StartCoroutine(create.Create("Officer", -2, 4)); 
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
        if(emptyHexs.Count > 0)
        {
            siec.Destroy();
            siec.Generate("hegemonia", "borgo", "HQ");
            siec.GetInputs("hegemonia");

            int[] outputs = new int[120];
            for (int j = 0; j < outputs.Length; j++)
            {
                outputs[j] = -1000;
            }

            for (int j = 0; j < emptyHexs.Count; j++)
            {
                for (int k = 0; k < 6; k++)
                {
                    int index = emptyHexs[j] * 6 + k;
                    outputs[index] = siec.GetNeuron(10, index);
                }
            }

            int maxResult = -999;
            int result = 0;

            for (int j = 0; j < outputs.Length; j++)
            {
                if (outputs[j] > maxResult)
                {
                    maxResult = outputs[j];
                    result = j;
                }
            }
            if (result > 0)
            {
                StartCoroutine(create.Create("HQ", Mathf.FloorToInt(result / 6), result % 6));
            }
        }
        emptyHexs = new List<int>();
    }

    public void turn()
    {
        for (int i = 0; i < 3; i++)
        {
            shop[i] = Random.Range(1, objects.Length);
            StartCoroutine(create.Create(objects[shop[i]], (i * -1) - 1, 0));
        }
        Debug.Log("hegemonia shop: " + shop[0] + " " + shop[1] + " " + shop[2]);
        for (int i = 0; i < 3; i++)
        {
            if (objects[shop[i]] != "Battle" && objects[shop[i]] != "Move" && objects[shop[i]] != "Push" && objects[shop[i]] != "Sniper")
            {
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

                int[] outputs = new int[120];
                for (int j = 0; j < outputs.Length; j++)
                {
                    outputs[j] = -1000;
                }

                if (emptyHexs.Count > 0)
                {
                    siec.Destroy();
                    siec.Generate("hegemonia", "borgo", objects_neural[shop[i]]);
                    siec.GetInputs("hegemonia");

                    for (int j = 0; j < emptyHexs.Count; j++)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            int index = emptyHexs[j] * 6 + k;
                            outputs[index] = siec.GetNeuron(10, index);
                        }
                    }
                }

                int max_result = -999;
                int result = 0;

                for (int j = 0; j < outputs.Length; j++)
                {
                    if (outputs[j] > max_result)
                    {
                        max_result = outputs[j];
                        result = j;
                    }
                }

                if (result > 0)
                {
                    StartCoroutine(create.Create(objects[shop[i]], Mathf.FloorToInt(result / 6), result % 6));
                }

                emptyHexs = new List<int>();

                GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                if (hegemoniaShop != null)
                {
                    Transform hex = hegemoniaShop.transform.Find("hex");
                    if (hex != null)
                    {
                        DestroyImmediate(hex.gameObject);
                    }
                }
            }
            else
            {
                if (objects[shop[i]] == "Battle")
                {
                    int[] outputs = new int[2];
                    for (int j = 0; j < outputs.Length; j++)
                    {
                        outputs[j] = -1000;
                    }

                    siec.Destroy();
                    siec.Generate("hegemonia", "borgo", "Battle");
                    siec.GetInputs("hegemonia");

                    for (int j = 0; j < 2; j++)
                    {
                        outputs[j] = siec.GetNeuron(10, j);
                    }

                    int max_result = -999;
                    int result = 0;

                    for (int j = 0; j < outputs.Length; j++)
                    {
                        if (outputs[j] > max_result)
                        {
                            max_result = outputs[j];
                            result = j;
                        }
                    }

                    if (result == 0)
                    {
                        core.battle();
                    }

                    GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                    if (hegemoniaShop != null)
                    {
                        Transform hex = hegemoniaShop.transform.Find("hex");
                        if (hex != null)
                        {
                            DestroyImmediate(hex.gameObject);
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

                    int[] outputs = new int[120];
                    for (int j = 0; j < outputs.Length; j++)
                    {
                        outputs[j] = -1000;
                    }

                    if (emptyHexs.Count > 0)
                    {
                        siec.Destroy();
                        siec.Generate("hegemonia", "borgo", "Move");
                        siec.GetInputs("hegemonia");

                        for (int j = 0; j < emptyHexs.Count; j++)
                        {
                            for (int k = 0; k < 6; k++)
                            {
                                int index = emptyHexs[j] * 6 + k;
                                GameObject currenthex = GameObject.Find("hex " + (a.a(emptyHexs[j], k, 0)));
                                if (currenthex != null)
                                {
                                    Transform currentHex = currenthex.transform.Find("hex");
                                    if (currentHex == null)
                                    {
                                        outputs[index] = siec.GetNeuron(10, index);
                                    }
                                }
                            }
                        }
                    }

                    int max_result = -999;
                    int result = 0;

                    for (int j = 0; j < outputs.Length; j++)
                    {
                        if (outputs[j] > max_result)
                        {
                            max_result = outputs[j];
                            result = j;
                        }
                    }

                    emptyHexs = new List<int>();

                    if (result > 5)
                    {

                        GameObject hex1 = GameObject.Find("hex " + Mathf.FloorToInt(result / 6));
                        GameObject hex2 = GameObject.Find("hex " + a.a(Mathf.FloorToInt(result / 6), result % 6, 0));

                        UnityEngine.Debug.Log($"hegemonia move: z {Mathf.FloorToInt(result / 6)} do {a.a(Mathf.FloorToInt(result / 6), result % 6, 0)}");

                        if (hex1 != null && hex2 != null)
                        {
                            Transform hex = hex1.transform.Find("hex");
                            if (hex != null)
                            {
                                hex.SetParent(hex2.transform);
                                hex.localPosition = new Vector3(0, 0, -1);
                            }
                        }
                    }

                    GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                    if (hegemoniaShop != null)
                    {
                        Transform hex = hegemoniaShop.transform.Find("hex");
                        if (hex != null)
                        {
                            DestroyImmediate(hex.gameObject);
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

                    int[] outputs = new int[120];
                    for (int j = 0; j < outputs.Length; j++)
                    {
                        outputs[j] = -1000;
                    }

                    if (emptyHexs.Count > 0)
                    {
                        siec.Destroy();
                        siec.Generate("hegemonia", "borgo", "Push");
                        siec.GetInputs("hegemonia");

                        for (int j = 0; j < emptyHexs.Count; j++)
                        {
                            for (int k = 0; k < 6; k++)
                            {
                                int index = emptyHexs[j] * 6 + k;
                                GameObject currenthex = GameObject.Find("hex " + (a.a(emptyHexs[j], k, 0)));
                                if (currenthex != null)
                                {
                                    Transform currentHex = currenthex.transform.Find("hex");
                                    if (currentHex == null)
                                    {
                                        outputs[index] = siec.GetNeuron(10, index);
                                    }
                                }
                            }
                        }
                    }

                    int max_result = -999;
                    int result = 0;

                    for (int j = 0; j < outputs.Length; j++)
                    {
                        if (outputs[j] > max_result)
                        {
                            max_result = outputs[j];
                            result = j;
                        }
                    }

                    emptyHexs = new List<int>();

                    if (result > 5)
                    {

                        GameObject hex1 = GameObject.Find("hex " + Mathf.FloorToInt(result / 6));
                        GameObject hex2 = GameObject.Find("hex " + a.a(Mathf.FloorToInt(result / 6), result % 6, 0));

                        UnityEngine.Debug.Log($"hegemonia push: z {Mathf.FloorToInt(result / 6)} do {a.a(Mathf.FloorToInt(result / 6), result % 6, 0)}");

                        if (hex1 != null && hex2 != null)
                        {
                            Transform hex = hex1.transform.Find("hex");
                            if (hex != null)
                            {
                                hex.SetParent(hex2.transform);
                                hex.localPosition = new Vector3(0, 0, -1);
                            }
                        }
                    }

                    GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                    if (hegemoniaShop != null)
                    {
                        Transform hex = hegemoniaShop.transform.Find("hex");
                        if (hex != null)
                        {
                            DestroyImmediate(hex.gameObject);
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

                    if (emptyHexs.Count > 0)
                    {
                        int[] outputs = new int[20];
                        for (int j = 0; j < outputs.Length; j++)
                        {
                            outputs[j] = -1000;
                        }

                        siec.Destroy();
                        siec.Generate("hegemonia", "borgo", "Sniper");
                        siec.GetInputs("hegemonia");

                        for (int j = 0; j < emptyHexs.Count; j++)
                        {
                            int index = emptyHexs[j];
                            outputs[index] = siec.GetNeuron(10, index);
                        }

                        int max_result = -999;
                        int result = 0;

                        for (int j = 0; j < outputs.Length; j++)
                        {
                            if (outputs[j] > max_result)
                            {
                                max_result = outputs[j];
                                result = j;
                            }
                        }

                        if (result > 0)
                        {
                            GameObject currenthex = GameObject.Find("hex " + result);
                            if (currenthex != null)
                            {
                                Transform currentHex = currenthex.transform.Find("hex");
                                if (currentHex != null)
                                {
                                    Debug.Log($"hegemonia sniper na {result}");
                                    DestroyImmediate(currentHex.gameObject);
                                }
                            }
                        }
                    }
                    emptyHexs = new List<int>();

                    GameObject hegemoniaShop = GameObject.Find("hegemonia " + (i + 1));
                    if (hegemoniaShop != null)
                    {
                        Transform hex = hegemoniaShop.transform.Find("hex");
                        if (hex != null)
                        {
                            DestroyImmediate(hex.gameObject);
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
