using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class HegemoniaCreate : MonoBehaviour
{
    public BorgoCore borgo;

    public GameObject HQ;
    public GameObject Brawler;
    public GameObject Medic;
    public GameObject Mutant;
    public GameObject Super_Mutant;
    public GameObject Officer;
    public GameObject Super_Officer;
    public GameObject Butcher;
    public GameObject Assassin;
    public GameObject NetFlighter;
    public GameObject Scout;
    public GameObject Battle;
    public GameObject Move;
    public GameObject Grenade;

    private void Start()
    {
        borgo = FindObjectsOfType<BorgoCore>()[0];
    }

    public IEnumerator Create(string name, int idHex, int rotation)
    {
        //je¿eli two¿ymy na planszy
        if (idHex > 0 && idHex < 20)
        {
            while (true)
            {
                //sprawdzanie, czy mo¿na stworzyæ w danym miejscu element
                if (borgo.hex[idHex - 1].name == "")
                {
                    GameObject gameObject;

                    switch (name)
                    {
                        case "HQ":
                            gameObject = HQ;
                            break;
                        case "Brawler":
                            gameObject = Brawler;
                            break;
                        case "Medic":
                            gameObject = Medic;
                            break;
                        case "Mutant":
                            gameObject = Mutant;
                            break;
                        case "Super_Mutant":
                            gameObject = Super_Mutant;
                            break;
                        case "Officer":
                            gameObject = Officer;
                            break;
                        case "Super_Officer":
                            gameObject = Super_Officer;
                            break;
                        case "Butcher":
                            gameObject = Butcher;
                            break;
                        case "Assassin":
                            gameObject = Assassin;
                            break;
                        case "NetFlighter":
                            gameObject = NetFlighter;
                            break;
                        case "Scout":
                            gameObject = Scout;
                            break;
                        default:
                            gameObject = null;
                            break;
                    }

                    if (gameObject == null)
                    {
                        StopCoroutine("Create");
                        break;
                    }

                    borgo.hex[idHex - 1].setHealth(borgo.objects[borgo.GetId(name)].health);
                    borgo.hex[idHex - 1].setWhereLook(rotation);
                    for (int i = 0; i < 4; i++)
                    {
                        borgo.hex[idHex - 1].setInitiative(borgo.objects[borgo.GetId(name)].initiative[i], i);
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        borgo.hex[idHex - 1].setDistance(borgo.objects[borgo.GetId(name)].distance[i], i);
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        borgo.hex[idHex - 1].setStrength(borgo.objects[borgo.GetId(name)].strength[i], i);
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        borgo.hex[idHex - 1].setFunctions(borgo.objects[borgo.GetId(name)].functions[i], i);
                    }
                    borgo.hex[idHex - 1].setNet(borgo.objects[borgo.GetId(name)].net);
                    borgo.hex[idHex - 1].setIsLife(borgo.objects[borgo.GetId(name)].isLife);
                    borgo.hex[idHex - 1].setName(name);


                    //tworzymy element na scenie
                    GameObject hex;
                    hex = GameObject.Find("hex " + idHex);
                    GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
                    newObject.transform.parent = hex.transform;
                    newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
                    newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation * 60));
                    UnityEngine.Debug.Log($"borgo Create(name: {name}, idHex: {idHex}({borgo.GetId(name)}), rotation: {rotation}): {borgo.id[2]} {borgo.id[3]} {borgo.id[4]} {borgo.id[5]} {borgo.id[6]} {borgo.id[7]} {borgo.id[8]} {borgo.id[9]} {borgo.id[10]} {borgo.id[11]} {borgo.id[12]} {borgo.id[13]} {borgo.id[14]} {borgo.id[15]} {borgo.id[16]} {borgo.id[17]} {borgo.id[18]} {borgo.id[19]} {borgo.id[20]} {borgo.id[21]} {borgo.id[22]} {borgo.id[23]} {borgo.id[24]} {borgo.id[25]} {borgo.id[26]} {borgo.id[27]} {borgo.id[28]} {borgo.id[29]} {borgo.id[30]} {borgo.id[31]} {borgo.id[32]} {borgo.id[33]} {borgo.id[34]} {borgo.id[35]} {borgo.id[36]} {borgo.id[37]} {borgo.id[38]} {borgo.id[39]}");

                    //sprawdzamy elementy funkcyjne
                    if (name == "HQ" || name == "Scout")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (borgo.hex[idHex - 1].functions[i] > 0) 
                            {
                                int a = borgo.Around(idHex, i, 0);
                                if (a != 0)
                                {
                                    if (borgo.hex[a - 1].isLife) 
                                    {
                                        borgo.hex[a - 1].setInitiative(true, 1); 
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = borgo.isLooking(idHex, "HQ");
                        if ((bool)n[0])
                        {
                            if (borgo.hex[Int32.Parse(n[1].ToString()) - 1].functions[Int32.Parse(n[2].ToString())] > 0) 
                            {
                                if (borgo.hex[idHex - 1].isLife)
                                {
                                    borgo.hex[idHex - 1].setInitiative(true, 1);
                                }
                            }
                        }
                        else
                        {
                            n = borgo.isLooking(idHex, "Scout");
                            if ((bool)n[0])
                            {
                                if (borgo.hex[Int32.Parse(n[1].ToString()) - 1].functions[Int32.Parse(n[2].ToString())] > 0)
                                {
                                    borgo.hex[idHex - 1].setInitiative(true, 1);
                                }
                            }
                        }
                    }
                    if (name == "Officer" || name == "Super_Officer")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (borgo.hex[idHex - 1].functions[i] > 0)
                            {
                                int a = borgo.Around(idHex, i, 0);
                                if (a != 0)
                                {
                                    if (borgo.hex[a - 1].isLife)
                                    {
                                        borgo.hex[a - 1].setStrength(borgo.hex[a - 1].strength[0] + 1, 0); 
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = borgo.isLooking(idHex, "Officer");
                        if ((bool)n[0])
                        {
                            if (borgo.hex[Int32.Parse(n[1].ToString()) - 1].functions[Int32.Parse(n[2].ToString())] > 0)
                            {
                                borgo.hex[idHex - 1].setStrength(borgo.hex[idHex - 1].strength[0] + 1, 0);
                            }
                        }
                        else
                        {
                            n = borgo.isLooking(idHex, "Super_Officer");
                            if ((bool)n[0])
                            {
                                if (borgo.hex[Int32.Parse(n[1].ToString()) - 1].functions[Int32.Parse(n[2].ToString())] > 0)
                                {
                                    borgo.hex[idHex - 1].setStrength(borgo.hex[idHex - 1].strength[0] + 1, 0);
                                }
                            }
                        }
                    }

                    StopCoroutine("Create");
                    break;
                }
                //sztab musi zostaæ postawiony
                else if (name == "HQ")
                {
                    idHex = UnityEngine.Random.Range(0, 20);
                }
                else
                {
                    StopCoroutine("Create");
                    break;
                }
            }
        }
        StopCoroutine("Create");
        yield return null;
    }
}
