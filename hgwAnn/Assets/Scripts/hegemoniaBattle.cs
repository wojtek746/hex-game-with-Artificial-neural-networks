using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hegemoniaBattle : MonoBehaviour
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
                        if (currentProperty.nameSztab == nameSztab)
                        {
                            if (currentProperty.initiative[initiative] && !currentProperty.net)
                            {
                                for (int direction = 0; direction < 6; direction++)
                                {
                                    int whereLook = 0;
                                    switch (currentProperty.distance[direction])
                                    {
                                        case 0:
                                            if (currentProperty.strength[direction] > 0)
                                            {
                                                whereLook = (currentProperty.whereLook + direction) % 6;
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
                                                                if (attackProperty.nameSztab != nameSztab)
                                                                {
                                                                    attackProperty.health -= currentProperty.strength[direction];
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case 1:
                                            if (currentProperty.strength[direction] > 0)
                                            {
                                                int j = 1;
                                                while (true)
                                                {
                                                    whereLook = (currentProperty.whereLook + direction) % 6;
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
                                                                if (attackProperty.nameSztab != nameSztab)
                                                                {
                                                                    attackProperty.health -= currentProperty.strength[direction];
                                                                }
                                                            }
                                                        }
                                                    }
                                                    j++;
                                                }
                                            }
                                            break;
                                        case 2:
                                            whereLook = (currentProperty.whereLook + direction) % 6;
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
                                                            if (attackProperty.nameSztab != nameSztab)
                                                            {
                                                                attackProperty.health -= currentProperty.strength[direction];
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
                                    for (int direction = 0; direction < 6; direction++)
                                    {
                                        if (currentProperty.functions[direction] > 0)
                                        {
                                            int whereLook = (currentProperty.whereLook + direction) % 6;
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
                                                            if (attackProperty.nameSztab == nameSztab)
                                                            {
                                                                attackProperty.strength[0] += currentProperty.functions[direction];
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (currentProperty.isZwiadowca)
                                {
                                    //zwiadowca(+iniciatywa)
                                    for (int direction = 0; direction < 6; direction++)
                                    {
                                        if (currentProperty.functions[direction] > 0)
                                        {
                                            int whereLook = (currentProperty.whereLook + direction) % 6;
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
                                                            if (attackProperty.nameSztab == nameSztab)
                                                            {
                                                                attackProperty.initiative[currentProperty.functions[direction]] = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                if (currentProperty.isKwatermistrz)
                                {
                                    //kwatermistrz(zmiana z pięści na strzelbę)
                                    for (int direction = 0; direction < 6; direction++)
                                    {
                                        if (currentProperty.functions[direction] > 0)
                                        {
                                            int whereLook = (currentProperty.whereLook + direction) % 6;
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
                                                            if (attackProperty.nameSztab == nameSztab)
                                                            {
                                                                for (int gdzie = 0; gdzie < 6; gdzie++)
                                                                {
                                                                    if (attackProperty.distance[gdzie] != 2)
                                                                    {
                                                                        if (attackProperty.distance[gdzie] == 1)
                                                                        {
                                                                            attackProperty.distance[gdzie] = 0;
                                                                        }
                                                                        else
                                                                        {
                                                                            attackProperty.distance[gdzie] = 1;
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
                        }
                    }
                }
            }
        }
    }
}
