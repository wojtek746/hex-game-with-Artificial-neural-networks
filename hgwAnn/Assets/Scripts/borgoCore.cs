using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borgoCore : MonoBehaviour
{
    borgoBattle battle;
    borgoCreate create;
    around a;
    Core core;
    private NeuralNetwork siec;

    //                                        0       1          2        3           4             5             6             7           8            9            10       11       12       13
    public string[] objects = new string[] { "HQ", "Brawler", "Medic", "Mutant", "Super_Mutant", "Officer", "Super_Officer", "Butcher", "Assassin", "NetFlighter", "Scout", "Battle", "Move", "Grenade" };
    public string[] objects_neural = new string[] { "HQ", "nozownik", "medyk", "mutek", "supermutant", "oficer", "superoficer", "silacz", "zabojca", "sieciarz", "zwiadowca", "Battle", "Move", "Grenade" };
    public int[] shop = new int[3];
    public List<int> emptyHexs = new List<int>();

    private int shopId;
    private bool isTurn;
    private float time; 

    public void StartGame()
    {
        battle = FindObjectsOfType<borgoBattle>()[0];
        create = FindObjectsOfType<borgoCreate>()[0];
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
            if(currenthex != null)
            {
                Transform currentHex = currenthex.transform.Find("hex");
                if(currentHex == null)
                {
                    emptyHexs.Add(i); 
                }
            }
        }
        if(emptyHexs.Count > 0)
        {
            siec.Destroy();
            siec.Generate("borgo", "hegemonia", "HQ");
            siec.GetInputs("borgo");

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
                    //Debug.Log(index); 
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
            if(result > 0)
            {
                StartCoroutine(create.Create("HQ", Mathf.FloorToInt(result / 6), result % 6));
            }
        }
        emptyHexs = new List<int>();

        shopId = 0;
        isTurn = false;
        time = 0; 
    }

    private void Update()
    {
        if (isTurn)
        {
            if (time >= 1)
            {
                if (objects[shop[shopId]] != "Battle" && objects[shop[shopId]] != "Move" && objects[shop[shopId]] != "Grenade")
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
                        siec.Generate("borgo", "hegemonia", objects_neural[shop[shopId]]);
                        siec.GetInputs("borgo");

                        for (int j = 0; j < emptyHexs.Count; j++)
                        {
                            for (int k = 0; k < 6; k++)
                            {
                                int index = emptyHexs[j] * 6 + k;
                                //Debug.Log(index + objects[shop[i]]);
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
                        StartCoroutine(create.Create(objects[shop[shopId]], Mathf.FloorToInt(result / 6), result % 6));
                    }

                    emptyHexs = new List<int>();

                    GameObject borgoShop = GameObject.Find("borgo " + (shopId + 1));
                    if (borgoShop != null)
                    {
                        Transform hex = borgoShop.transform.Find("hex");
                        if (hex != null)
                        {
                            DestroyImmediate(hex.gameObject);
                        }
                    }
                }
                else
                {
                    if (objects[shop[shopId]] == "Battle")
                    {
                        int[] outputs = new int[2];
                        for (int j = 0; j < outputs.Length; j++)
                        {
                            outputs[j] = -1000;
                        }

                        siec.Destroy();
                        siec.Generate("borgo", "hegemonia", "Battle");
                        siec.GetInputs("borgo");

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

                        GameObject borgoShop = GameObject.Find("borgo " + (shopId + 1));
                        if (borgoShop != null)
                        {
                            Transform hex = borgoShop.transform.Find("hex");
                            if (hex != null)
                            {
                                DestroyImmediate(hex.gameObject);
                            }
                        }
                    }
                    else if (objects[shop[shopId]] == "Move")
                    {
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
                                        if (currentProperty.nameSztab == "borgo")
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
                            siec.Generate("borgo", "hegemonia", "Move");
                            siec.GetInputs("borgo");

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

                            UnityEngine.Debug.Log($"borgo move: z {Mathf.FloorToInt(result / 6)} do {a.a(Mathf.FloorToInt(result / 6), result % 6, 0)}");

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

                        GameObject borgoShop = GameObject.Find("borgo " + (shopId + 1));
                        if (borgoShop != null)
                        {
                            Transform hex = borgoShop.transform.Find("hex");
                            if (hex != null)
                            {
                                DestroyImmediate(hex.gameObject);
                            }
                        }
                    }
                    else if (objects[shop[shopId]] == "Grenade")
                    {
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
                                        if (currentProperty.nameSztab != "borgo" && currentProperty.name != "sztab")
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
                            siec.Generate("borgo", "hegemonia", "Grenade");
                            siec.GetInputs("borgo");

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
                                        Debug.Log($"borgo granat na {result}");
                                        DestroyImmediate(currentHex.gameObject);
                                    }
                                }
                            }
                        }
                        emptyHexs = new List<int>();

                        GameObject borgoShop = GameObject.Find("borgo " + (shopId + 1));
                        if (borgoShop != null)
                        {
                            Transform hex = borgoShop.transform.Find("hex");
                            if (hex != null)
                            {
                                DestroyImmediate(hex.gameObject);
                            }
                        }
                    }
                }
                shopId++;
                if (shopId >= 3)
                {
                    isTurn = false;
                    core.endTurn = true;
                }
                time = 0; 
            }
            else
            {
                time += Time.deltaTime; 
            }
        }
    }

    public void turn()
    {
        for(int i = 0; i < 3; i++)
        {
            shop[i] = Random.Range(1, objects.Length);
            StartCoroutine(create.Create(objects[shop[i]], (i * -1) - 1, 0));
        }
        Debug.Log("borgo shop: " + shop[0] + " " + shop[1] + " " + shop[2]);
        shopId = 0;
        time = 0; 
        isTurn = true; 
        //siec.testuj(); 
    }

    public void InitiativeBattle(int initiative)
    {
        battle.InitiativeBattle(initiative); 
    }
}
