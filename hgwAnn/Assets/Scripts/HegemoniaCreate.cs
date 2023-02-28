using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class HegemoniaCreate : MonoBehaviour
{
    public HegemoniaCore hegemonia;

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

    public void StartGame()
    {
        hegemonia = FindObjectsOfType<HegemoniaCore>()[0];
    }

    public IEnumerator Create(string name, int idHex, int rotation)
    {
        //je¿eli two¿ymy na planszy
        if (idHex > 0 && idHex < 20)
        {
            while (true)
            {
                //sprawdzanie, czy mo¿na stworzyæ w danym miejscu element
                if (hegemonia.hex[idHex - 1].name == "")
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

                    hegemonia.hex[idHex - 1].setHealth(hegemonia.objects[hegemonia.GetId(name)].health);
                    hegemonia.hex[idHex - 1].setWhereLook(rotation);
                    for (int i = 0; i < 4; i++)
                    {
                        hegemonia.hex[idHex - 1].setInitiative(hegemonia.objects[hegemonia.GetId(name)].initiative[i], i);
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        hegemonia.hex[idHex - 1].setDistance(hegemonia.objects[hegemonia.GetId(name)].distance[i], i);
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        hegemonia.hex[idHex - 1].setStrength(hegemonia.objects[hegemonia.GetId(name)].strength[i], i);
                    }
                    for (int i = 0; i < 6; i++)
                    {
                        hegemonia.hex[idHex - 1].setFunctions(hegemonia.objects[hegemonia.GetId(name)].functions[i], i);
                    }
                    hegemonia.hex[idHex - 1].setNet(hegemonia.objects[hegemonia.GetId(name)].net);
                    hegemonia.hex[idHex - 1].setIsLife(hegemonia.objects[hegemonia.GetId(name)].isLife);
                    hegemonia.hex[idHex - 1].setName(name);


                    //tworzymy element na scenie
                    GameObject hex;
                    hex = GameObject.Find("hex " + idHex);
                    GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
                    newObject.transform.parent = hex.transform;
                    newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
                    newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation * 60));
                    UnityEngine.Debug.Log($"hegemonia Create(name: {name}, idHex: {idHex}({hegemonia.GetId(name)}), rotation: {rotation}): {hegemonia.id[2]} {hegemonia.id[3]} {hegemonia.id[4]} {hegemonia.id[5]} {hegemonia.id[6]} {hegemonia.id[7]} {hegemonia.id[8]} {hegemonia.id[9]} {hegemonia.id[10]} {hegemonia.id[11]} {hegemonia.id[12]} {hegemonia.id[13]} {hegemonia.id[14]} {hegemonia.id[15]} {hegemonia.id[16]} {hegemonia.id[17]} {hegemonia.id[18]} {hegemonia.id[19]} {hegemonia.id[20]} {hegemonia.id[21]} {hegemonia.id[22]} {hegemonia.id[23]} {hegemonia.id[24]} {hegemonia.id[25]} {hegemonia.id[26]} {hegemonia.id[27]} {hegemonia.id[28]} {hegemonia.id[29]} {hegemonia.id[30]} {hegemonia.id[31]} {hegemonia.id[32]} {hegemonia.id[33]} {hegemonia.id[34]} {hegemonia.id[35]} {hegemonia.id[36]} {hegemonia.id[37]} {hegemonia.id[38]} {hegemonia.id[39]}");

                    //sprawdzamy elementy funkcyjne
                    if (name == "HQ" || name == "Scout")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (hegemonia.hex[idHex - 1].functions[i] > 0) 
                            {
                                int a = hegemonia.Around(idHex, i, 0);
                                if (a != 0)
                                {
                                    if (hegemonia.hex[a - 1].isLife) 
                                    {
                                        hegemonia.hex[a - 1].setInitiative(true, 1); 
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = hegemonia.isLooking(idHex, "HQ");
                        if ((bool)n[0])
                        {
                            if (hegemonia.hex[Int32.Parse(n[1].ToString()) - 1].functions[Int32.Parse(n[2].ToString())] > 0) 
                            {
                                if (hegemonia.hex[idHex - 1].isLife)
                                {
                                    hegemonia.hex[idHex - 1].setInitiative(true, 1);
                                }
                            }
                        }
                        else
                        {
                            n = hegemonia.isLooking(idHex, "Scout");
                            if ((bool)n[0])
                            {
                                if (hegemonia.hex[Int32.Parse(n[1].ToString()) - 1].functions[Int32.Parse(n[2].ToString())] > 0)
                                {
                                    hegemonia.hex[idHex - 1].setInitiative(true, 1);
                                }
                            }
                        }
                    }
                    if (name == "Officer" || name == "Super_Officer")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (hegemonia.hex[idHex - 1].functions[i] > 0)
                            {
                                int a = hegemonia.Around(idHex, i, 0);
                                if (a != 0)
                                {
                                    if (hegemonia.hex[a - 1].isLife)
                                    {
                                        hegemonia.hex[a - 1].setStrength(hegemonia.hex[a - 1].strength[0] + 1, 0); 
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = hegemonia.isLooking(idHex, "Officer");
                        if ((bool)n[0])
                        {
                            if (hegemonia.hex[Int32.Parse(n[1].ToString()) - 1].functions[Int32.Parse(n[2].ToString())] > 0)
                            {
                                hegemonia.hex[idHex - 1].setStrength(hegemonia.hex[idHex - 1].strength[0] + 1, 0);
                            }
                        }
                        else
                        {
                            n = hegemonia.isLooking(idHex, "Super_Officer");
                            if ((bool)n[0])
                            {
                                if (hegemonia.hex[Int32.Parse(n[1].ToString()) - 1].functions[Int32.Parse(n[2].ToString())] > 0)
                                {
                                    hegemonia.hex[idHex - 1].setStrength(hegemonia.hex[idHex - 1].strength[0] + 1, 0);
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
