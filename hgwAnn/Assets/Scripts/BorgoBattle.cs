using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borgoBattle : MonoBehaviour
{
    public GameObject currenthex;
    public GameObject attackhex; 
    public Property currentProperty;
    public Property attackProperty; 
    public around a;
    public string nameSztab; 

    public void StartGame()
    {
        a = FindObjectsOfType<around>()[0];
    }

    public void InitiativeBattle(int initiative)
    {
        for (int i = 1; i <= 19; i++)
        {
            currenthex = GameObject.Find("hex " + i);

            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");

                if (hex != null)
                {
                    currentProperty = hex.GetComponent<Property>();

                    if (currentProperty != null)
                    {
                        if(currentProperty.nameSztab == nameSztab)
                        {
                            if (currentProperty.initiative[initiative] && !currentProperty.net)
                            {
                                for (int kierunek = 0; kierunek < 6; kierunek++)
                                {
                                    int whereLook = 0; 
                                    switch (currentProperty.distance[kierunek])
                                    {
                                        case 0:
                                            if (currentProperty.strength[kierunek] > 0)
                                            {
                                                whereLook = (currentProperty.whereLook + kierunek) % 6;
                                                UnityEngine.Debug.Log($"{whereLook}"); 
                                                whereLook = a.a(i, whereLook, 0);
                                                UnityEngine.Debug.Log($"whereLook: {whereLook} for {currentProperty.strength[kierunek]} on {kierunek}");
                                                if (whereLook != 0)
                                                {
                                                    attackhex = GameObject.Find("hex " + whereLook);
                                                    if (attackhex != null)
                                                    {
                                                        hex = attackhex.transform.Find("hex");
                                                        if (hex != null)
                                                        {
                                                            attackProperty = hex.GetComponent<Property>();
                                                            if (attackProperty != null)
                                                            {
                                                                if (attackProperty.nameSztab != "borgo")
                                                                {
                                                                    attackProperty.health = attackProperty.health - currentProperty.strength[kierunek];
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 1:
                                            if (currentProperty.strength[kierunek] > 0)
                                            {
                                                int j = 1;
                                                while (true)
                                                {
                                                    whereLook = (currentProperty.whereLook + kierunek) % 6;
                                                    whereLook = a.a(i, whereLook, j);
                                                    if (whereLook == 0)
                                                    {
                                                        break;
                                                    }
                                                    attackhex = GameObject.Find("hex " + whereLook);
                                                    if (attackhex != null)
                                                    {
                                                        hex = attackhex.transform.Find("hex");
                                                        if (hex != null)
                                                        {
                                                            attackProperty = hex.GetComponent<Property>();
                                                            if (attackProperty != null)
                                                            {
                                                                if (attackProperty.nameSztab != "borgo")
                                                                {
                                                                    attackProperty.health = attackProperty.health - currentProperty.strength[kierunek];
                                                                }
                                                            }
                                                        }
                                                    }
                                                    j++;
                                                }
                                            }
                                            break;
                                        case 2:
                                            whereLook = (currentProperty.whereLook + kierunek) % 6;
                                            whereLook = a.a(i, whereLook, 0);
                                            if (whereLook != 0)
                                            {
                                                attackhex = GameObject.Find("hex " + whereLook);
                                                if (attackhex != null)
                                                {
                                                    hex = attackhex.transform.Find("hex");
                                                    if (hex != null)
                                                    {
                                                        attackProperty = hex.GetComponent<Property>();
                                                        if (attackProperty != null)
                                                        {
                                                            if (attackProperty.nameSztab != "borgo")
                                                            {
                                                                attackProperty.health = attackProperty.health - currentProperty.strength[kierunek];
                                                                attackProperty.net = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                                if (currentProperty.isOficer)
                                {
                                    //officer(+atak)
                                }
                                if (currentProperty.isZwiadowca)
                                {
                                    //zwiadowca(+iniciatywa)
                                }
                                if (currentProperty.isKwatermistrz)
                                {
                                    //kwatermistrz(zmiana z pięści na strzelbę)
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
