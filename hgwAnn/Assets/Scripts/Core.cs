using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public borgoCreate borgo;
    public around a; 

    public List<int> getId(int which)
    {
        List<int> lista = new List<int>();

        return lista; 
    }

    public void Start()
    {
        borgo = FindObjectsOfType<borgoCreate>()[0];
        a = FindObjectsOfType<around>()[0];

        borgo.StartGame();
        StartCoroutine(borgo.Create("Butcher", 3, 4));

        borgoBattle battle = FindObjectsOfType<borgoBattle>()[0];
        battle.StartGame(); 
        battle.InitiativeBattle(3); 
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
                                    if(currentProperty.nameSztab == lookingProperty.nameSztab && lookingProperty.isMedyk)
                                    {
                                        for(int itsDirection = 0; itsDirection < 6; itsDirection++)
                                        {
                                            if(a.a(lookingProperty.whereIs, itsDirection, 0) == whereIs)
                                            {
                                                if (lookingProperty.functions[itsDirection] > 0)
                                                {
                                                    sumMedic += lookingProperty.functions[itsDirection];
                                                    Destroy(lookingHex);
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
}
