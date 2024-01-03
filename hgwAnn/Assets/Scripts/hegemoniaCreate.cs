using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hegemoniaCreate : MonoBehaviour
{
    public around a;
    public GameObject HQ;
    public GameObject Runner;
    public GameObject Boss;
    public GameObject Brute;
    public GameObject Ganger;
    public GameObject Gladiator;
    public GameObject Quartermaster;
    public GameObject Officer;
    public GameObject Officer2;
    public GameObject NetFlighter;
    public GameObject Guard;
    public GameObject SuperNet;
    public GameObject Transport;
    public GameObject UniversalSolidier;
    public GameObject Scout;
    public GameObject Battle;
    public GameObject Move;
    public GameObject Push;
    public GameObject Sniper;

    public void StartGame()
    {
        a = FindObjectsOfType<around>()[0];
    }

    public IEnumerator Create(string name, int idHex, int rotation)
    {
        //jeżeli na scenie
        if (idHex > 0 && idHex <= 19)
        {
            Debug.Log($"hegemonia create: {name} on {idHex} with rotation {rotation}");
            GameObject gameObject;

            switch (name)
            {
                case "HQ":
                    gameObject = HQ;
                    break;
                case "Runner":
                    gameObject = Runner;
                    break;
                case "Boss":
                    gameObject = Boss;
                    break;
                case "Brute":
                    gameObject = Brute;
                    break;
                case "Ganger":
                    gameObject = Ganger;
                    break;
                case "Gladiator":
                    gameObject = Gladiator;
                    break;
                case "Quartermaster":
                    gameObject = Quartermaster;
                    break;
                case "Officer":
                    gameObject = Officer;
                    break;
                case "Officer2":
                    gameObject = Officer2;
                    break;
                case "NetFlighter":
                    gameObject = NetFlighter;
                    break;
                case "Guard":
                    gameObject = Guard;
                    break;
                case "SuperNet":
                    gameObject = SuperNet;
                    break;
                case "Transport":
                    gameObject = Transport;
                    break;
                case "UniversalSolidier":
                    gameObject = UniversalSolidier;
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
                case "Runner":
                    gameObject = Runner;
                    break;
                case "Boss":
                    gameObject = Boss;
                    break;
                case "Brute":
                    gameObject = Brute;
                    break;
                case "Ganger":
                    gameObject = Ganger;
                    break;
                case "Gladiator":
                    gameObject = Gladiator;
                    break;
                case "Quartermaster":
                    gameObject = Quartermaster;
                    break;
                case "Officer":
                    gameObject = Officer;
                    break;
                case "Officer2":
                    gameObject = Officer2;
                    break;
                case "NetFlighter":
                    gameObject = NetFlighter;
                    break;
                case "Guard":
                    gameObject = Guard;
                    break;
                case "SuperNet":
                    gameObject = SuperNet;
                    break;
                case "UniversalSolidier":
                    gameObject = UniversalSolidier;
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
                case "Push":
                    gameObject = Push;
                    break;
                case "Sniper":
                    gameObject = Sniper;
                    break;
                default:
                    gameObject = null;
                    break;
            }

            if (gameObject == null)
            {
                yield break;
            }

            GameObject currenthex = GameObject.Find("hegemonia " + idHex * -1);
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
