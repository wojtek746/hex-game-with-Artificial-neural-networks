using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public borgoCore borgo;
    public around a;
    public hegemoniaCore hegemonia;
    public string first;
    public string second;

    public List<int> getId(int which)
    {
        List<int> lista = new List<int>();

        return lista; 
    }

    public void Start()
    {
        GameObject hex;

        switch (first)
        {
            case "borgo":
                hex = GameObject.Find("borgo");
                break;
            case "hegemonia":
                hex = GameObject.Find("hegemonia");
                break;
            default:
                hex = null;
                break;
        }

        hex.transform.position = new Vector3(-4.5f, hex.transform.position.y, hex.transform.position.z);


        borgo = FindObjectsOfType<borgoCore>()[0];
        a = FindObjectsOfType<around>()[0];
        hegemonia = FindObjectsOfType<hegemoniaCore>()[0];

        borgo.StartGame();
        hegemonia.StartGame();

        //StartCoroutine(borgo.Create("Butcher", 3, 4));

        //borgoBattle battle = FindObjectsOfType<borgoBattle>()[0];
        //battle.StartGame();
        //battle.InitiativeBattle(3);

        //StartCoroutine(borgo.Create("Medic", 1, 4));

        //GameObject currenthex = GameObject.Find("hex " + 3);

        /*if (currenthex != null)
        {
            Transform currentHex = currenthex.transform.Find("hex");

            if (currentHex != null)
            {
                Property currentProperty = currentHex.GetComponent<Property>();

                if (currentProperty != null)
                {
                    currentProperty.health = 0; 
                }
            }
        }*/
        for (int turn = 0; turn < 1; turn++)
        {
            borgo.turn();
            hegemonia.turn();
            if (!isHQLife())
            {
                UnityEngine.Debug.Log("ktoś wygrał :)");
                break;
            }
        }

        GameObject currenthex = GameObject.Find("neuralNetwork");

        if (currenthex != null)
        {
            Transform currentHex = currenthex.transform;

            if (currentHex != null)
            {
                NeuralNetwork currentProperty = currentHex.GetComponent<NeuralNetwork>();

                if (currentProperty != null)
                {
                    currentProperty.GetInputs("borgo");
                    Debug.Log(currentProperty.GetNeuron(10, 100));
                }
            }
        }
    }

    public int isMedic(int whereIs)
    {
        GameObject currenthex = GameObject.Find("hex " + whereIs);
        int sumMedic = 0; 

        if (currenthex != null)
        {
            Transform currentHex = currenthex.transform.Find("hex");

            if (currentHex != null)
            {
                Property currentProperty = currentHex.GetComponent<Property>();

                if (currentProperty != null)
                {
                    for (int ourDirection = 0; ourDirection < 6; ourDirection++)
                    {
                        int whereLook = a.a(whereIs, ourDirection, 0); 
                        GameObject lookinghex = GameObject.Find("hex " + whereLook);

                        if (lookinghex != null)
                        {
                            Transform lookingHex = lookinghex.transform.Find("hex");

                            if (lookingHex != null)
                            {
                                Property lookingProperty = lookingHex.GetComponent<Property>();

                                if (lookingProperty != null)
                                {
                                    if (currentProperty.nameSztab == lookingProperty.nameSztab && lookingProperty.isMedyk)
                                    {
                                        for (int itsDirection = 0; itsDirection < 6; itsDirection++)
                                        {
                                            if (a.a(lookingProperty.whereIs, itsDirection, 0) == whereIs)
                                            {
                                                if (lookingProperty.functions[(itsDirection + lookingProperty.whereLook - 1) % 6] > 0)
                                                {
                                                    UnityEngine.Debug.Log($"sprawdzamy mekyka {whereLook} {itsDirection}");
                                                    sumMedic += lookingProperty.functions[(itsDirection + lookingProperty.whereLook - 1) % 6];
                                                    Destroy(lookingHex.gameObject);
                                                    UnityEngine.Debug.Log("Usunięto mekyka"); 
                                                    break; 
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        return sumMedic; 
    }

    public void battle()
    {
        for(int i = 0; i < 4; i++)
        {
            switch (first)
            {
                case "borgo":
                    borgo.InitiativeBattle(i); 
                    switch (second)
                    {
                        case "borgo":
                            borgo.InitiativeBattle(i);
                            break;
                        case "hegemonia":
                            hegemonia.InitiativeBattle(i);
                            break;
                        default:
                            break; 
                    }
                    break;
                case "hegemonia":
                    hegemonia.InitiativeBattle(i);
                    switch (second)
                    {
                        case "borgo":
                            borgo.InitiativeBattle(i);
                            break;
                        case "hegemonia":
                            hegemonia.InitiativeBattle(i);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            afterBattle();
        }
    }

    public void afterBattle()
    {
        for (int i = 1; i <= 19; i++)
        {
            GameObject currenthex = GameObject.Find("hex " + i);

            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");

                if (hex != null)
                {
                    Property currentProperty = hex.GetComponent<Property>();

                    if (currentProperty != null)
                    {
                        currentProperty.afterBattle(); 
                    }
                }
            }
        }
    }

    public bool isHQLife()
    {
        int ileZyje = 0; 
        for (int i = 1; i <= 1; i++)
        {
            GameObject currenthex = GameObject.Find("hex " + i);

            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");

                if (hex != null)
                {
                    Property currentProperty = hex.GetComponent<Property>();

                    if (currentProperty != null)
                    {
                        if(currentProperty.name == "sztab")
                        {
                            ileZyje++; 
                        }
                    }
                }
            }
        }
        if(ileZyje >= 2)
        {
            return true; 
        }
        return false; 
    }
}
