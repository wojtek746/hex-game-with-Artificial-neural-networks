using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borgoCreate : MonoBehaviour
{
    public around a;
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
        a = FindObjectsOfType<around>()[0];
    }

    public IEnumerator Create(string name, int idHex, int rotation)
    {
        //jeżeli na scenie
        if (idHex > 0 && idHex <= 19)
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
                yield break;
            }

            bool isEmpty = true;
            GameObject currenthex = GameObject.Find("hex " + idHex);

            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");
                if (hex != null)
                {
                    Property currentProperty = hex.GetComponent<Property>();
                    if (currentProperty != null)
                    {
                        isEmpty = false;
                    }
                }
            }
            if (isEmpty)
            {
                //tworzymy element na scenie
                GameObject hex;
                hex = GameObject.Find("hex " + idHex);
                GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
                newObject.transform.parent = hex.transform;
                newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
                newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation * 60));
                newObject.transform.name = "hex";
                Property currentProperty = newObject.GetComponent<Property>();
                if (currentProperty != null)
                {
                    currentProperty.whereLook = rotation;
                    currentProperty.whereIs = idHex;
                    currentProperty.StartGame();
                }
            }

            if (name == "HQ")
            {
                //sztab musi być postawiony
                if (!isEmpty)
                {
                    while (true)
                    {
                        isEmpty = true;

                        idHex = Random.Range(1, 20);

                        currenthex = GameObject.Find("hex " + idHex);

                        if (currenthex != null)
                        {
                            Transform hex = currenthex.transform.Find("hex");
                            if (hex != null)
                            {
                                Property currentProperty = hex.GetComponent<Property>();
                                if (currentProperty != null)
                                {
                                    isEmpty = false;
                                }
                            }
                        }
                        if (isEmpty)
                        {
                            //tworzymy element na scenie
                            GameObject hex;
                            hex = GameObject.Find("hex " + idHex);
                            GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
                            newObject.transform.parent = hex.transform;
                            newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
                            newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation * 60));
                            newObject.transform.name = "hex";
                            Property currentProperty = newObject.GetComponent<Property>();
                            if (currentProperty != null)
                            {
                                currentProperty.whereLook = rotation;
                                currentProperty.whereIs = idHex;
                                currentProperty.StartGame();
                            }
                            break;
                        }
                    }
                }
            }

            /*currenthex = GameObject.Find("hex " + idHex);
            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");
                if (hex != null)
                {
                    Property currentProperty = hex.GetComponent<Property>();

                    if (currentProperty != null)
                    {
                        GameObject lookhex = null;
                        Transform lookinghex = null;
                        Property lookProperty = null;
                        //wojownicy funkcyjni
                        if (currentProperty.isOficer)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (currentProperty.functions[i] > 0)
                                {
                                    int currentIdHex = a.a(idHex, (currentProperty.whereLook + i) % 6, 0);
                                    lookhex = GameObject.Find("hex " + currentIdHex);
                                    if (lookhex != null)
                                    {
                                        lookinghex = currenthex.transform.Find("hex");
                                        if (lookinghex != null)
                                        {
                                            lookProperty = hex.GetComponent<Property>();
                                            if (lookProperty != null)
                                            {
                                                lookProperty.strength[0] = lookProperty.strength[0] + 1; 
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (currentProperty.isZwiadowca)
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (currentProperty.functions[i] > 0)
                                {
                                    int currentIdHex = a.a(idHex, (currentProperty.whereLook + i) % 6, 0);
                                    lookhex = GameObject.Find("hex " + currentIdHex);
                                    if (lookhex != null)
                                    {
                                        lookinghex = currenthex.transform.Find("hex");
                                        if (lookinghex != null)
                                        {
                                            lookProperty = hex.GetComponent<Property>();
                                            if (lookProperty != null)
                                            {
                                                lookProperty.initiative[1] = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }*/
        }
        else
        {
            //w sklepie
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
                case "Battle":
                    gameObject = Battle;
                    break;
                case "Move":
                    gameObject = Move;
                    break;
                case "Grenade":
                    gameObject = Grenade;
                    break;
                default:
                    gameObject = null;
                    break;
            }

            if (gameObject == null)
            {
                yield break;
            }

            GameObject currenthex = GameObject.Find("borgo " + idHex * -1);
            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");
                if (hex == null)
                {
                    //dodajemy do sklepu
                    GameObject newObject = Instantiate(gameObject, currenthex.transform.position, currenthex.transform.rotation);
                    newObject.transform.parent = currenthex.transform;
                    newObject.transform.position = new Vector3(currenthex.transform.position.x, currenthex.transform.position.y, -1);
                    newObject.transform.name = "hex";
                }
            }
        }

        StopCoroutine("Create");
        yield return null;
    }
}
