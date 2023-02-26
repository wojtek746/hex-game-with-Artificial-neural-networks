using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class BorgoCreate : MonoBehaviour
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
                    UnityEngine.Debug.Log($"borgo Create(name: {name}, idHex: {idHex}({borgo.GetId(name)}), rotation: {rotation}): {borgo.GetId(borgo.hex[0].name)} {borgo.hex[0].whereLook} {borgo.GetId(borgo.hex[1].name)} {borgo.hex[1].whereLook} {borgo.GetId(borgo.hex[2].name)} {borgo.hex[2].whereLook} {borgo.GetId(borgo.hex[3].name)} {borgo.hex[3].whereLook} {borgo.GetId(borgo.hex[4].name)} {borgo.hex[4].whereLook} {borgo.GetId(borgo.hex[5].name)} {borgo.hex[5].whereLook} {borgo.GetId(borgo.hex[6].name)} {borgo.hex[6].whereLook} {borgo.GetId(borgo.hex[7].name)} {borgo.hex[7].whereLook} {borgo.GetId(borgo.hex[8].name)} {borgo.hex[8].whereLook} {borgo.GetId(borgo.hex[9].name)} {borgo.hex[9].whereLook} {borgo.GetId(borgo.hex[10].name)} {borgo.hex[10].whereLook} {borgo.GetId(borgo.hex[11].name)} {borgo.hex[11].whereLook} {borgo.GetId(borgo.hex[12].name)} {borgo.hex[12].whereLook} {borgo.GetId(borgo.hex[13].name)} {borgo.hex[13].whereLook} {borgo.GetId(borgo.hex[14].name)} {borgo.hex[14].whereLook} {borgo.GetId(borgo.hex[15].name)} {borgo.hex[15].whereLook} {borgo.GetId(borgo.hex[16].name)} {borgo.hex[16].whereLook} {borgo.GetId(borgo.hex[17].name)} {borgo.hex[17].whereLook} {borgo.GetId(borgo.hex[18].name)} {borgo.hex[18].whereLook}");

                    //sprawdzamy elementy funkcyjne
                    if (name == "HQ" || name == "Scout")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[4])[i].ToString()) > 0)
                            {
                                int a = Around(idHex, i, 0);
                                if (a != 0)
                                {
                                    if (((bool)((ArrayList)idObjects[a - 1])[6]))
                                    {
                                        ((ArrayList)((ArrayList)idObjects[a - 1])[1])[1] = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = isLooking(idHex, "HQ");
                        if ((bool)n[0])
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                            {
                                if (((bool)((ArrayList)idObjects[idHex - 1])[6]))
                                {
                                    ((ArrayList)((ArrayList)idObjects[idHex - 1])[1])[1] = true;
                                }
                            }
                        }
                        else
                        {
                            n = isLooking(idHex, "Scout");
                            if ((bool)n[0])
                            {
                                if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                                {
                                    ((ArrayList)((ArrayList)idObjects[idHex - 1])[1])[1] = true;
                                }
                            }
                        }
                    }
                    if (name == "Officer" || name == "Super_Officer")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[4])[i].ToString()) > 0)
                            {
                                int a = Around(idHex, i, 0);
                                if (a != 0)
                                {
                                    if (((bool)((ArrayList)idObjects[a - 1])[6]))
                                    {
                                        ((ArrayList)((ArrayList)idObjects[a - 1])[3])[0] = Int32.Parse(((ArrayList)((ArrayList)idObjects[a - 1])[3])[0].ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = isLooking(idHex, "Officer");
                        if ((bool)n[0])
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                            {
                                ((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0] = Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0].ToString());
                            }
                        }
                        else
                        {
                            n = isLooking(idHex, "Super_Officer");
                            if ((bool)n[0])
                            {
                                if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                                {
                                    ((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0] = Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0].ToString());
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
