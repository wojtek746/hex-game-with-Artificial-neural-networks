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
    public int maxTurn;
    public int coIle; 
    private int i; 
    private int turn; 
    private bool isGame;
    private int which;
    public bool endTurn; 

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

        isGame = true;
        endTurn = true; 
        i = 0;
        turn = 1; 
        which = 1; 

        borgo.StartGame();
        hegemonia.StartGame();
    }

    public void Update()
    {
        if (isGame)
        {
            if (i % coIle == 0 && endTurn)
            {
                if (which == 1)
                {
                    borgo.turn();
                    which = 2;
                    endTurn = false;
                }
                else
                {
                    hegemonia.turn();
                    which = 1;
                    endTurn = false;
                    turn++;
                }
            }
            if (!isHQLife() || turn >= maxTurn)
            {
                UnityEngine.Debug.Log("ktoś wygrał :) w turze: " + turn);
                isGame = false;
            }
        }
        i++;
        i %= coIle;
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
                                                if ((itsDirection + lookingProperty.whereLook - 1) % 6 >= 0)
                                                {
                                                    if (lookingProperty.functions[(itsDirection + lookingProperty.whereLook - 1) % 6] > 0)
                                                    {
                                                        UnityEngine.Debug.Log($"sprawdzamy medyka {whereLook} {itsDirection}");
                                                        sumMedic += lookingProperty.functions[(itsDirection + lookingProperty.whereLook - 1) % 6];
                                                        DestroyImmediate(lookingHex.gameObject);
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
