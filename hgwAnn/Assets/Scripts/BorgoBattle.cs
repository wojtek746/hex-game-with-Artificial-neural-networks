using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class BorgoBattle : MonoBehaviour
{
    public BorgoCore borgo;
    public core Core;
    public BorgoDelete Delete;

    void Start()
    {
        borgo = FindObjectsOfType<BorgoCore>()[0];
        Core = FindObjectsOfType<core>()[0];
        Delete = FindObjectsOfType<BorgoDelete>()[0];
    }

    public void InitiativeBattle(int initiative)
    {
        for (int i = 0; i < 19; i++)
        {
            if (!borgo.hex[i].net)
            {
                if (borgo.hex[i].initiative[initiative])
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (borgo.hex[i].strength[j] > 0)
                        {
                            //atak na blisko
                            if (borgo.hex[i].distance[j] == 0)
                            {
                                int a = borgo.Around(i, j, 0);
                                if (a != 0)
                                {
                                    Core.Attack("Borgo", a, borgo.hex[i].strength[j], false);
                                }
                            }
                            //atak na daleko
                            else if (borgo.hex[i].distance[j] == 1)
                            {
                                int k = 1;
                                while (true)
                                {
                                    int a = borgo.Around(i, j, k);
                                    if (a == 0)
                                    {
                                        break;
                                    }
                                    Core.Attack("Borgo", a, borgo.hex[i].strength[j], false);
                                    k++;
                                }
                            }
                            //sieæ
                            else if (borgo.hex[i].distance[j] == 2)
                            {
                                int a = borgo.Around(i, j, 0);
                                if (a != 0)
                                {
                                    Core.Attack("Borgo", a, borgo.hex[i].strength[j], true);
                                }
                            }
                            //mo¿e wybraæ, czy na blisko, czy na daleko
                            else
                            {
                                //kod do zrobienia; tymczasowo:
                                int k = 1;
                                while (true)
                                {
                                    int a = borgo.Around(i, j, k);
                                    if (a == 0)
                                    {
                                        break;
                                    }
                                    Core.Attack("Borgo", a, borgo.hex[i].strength[j], false);
                                    k++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void Attack(int idHex, int health, bool isNet)
    {
        //sprawdzamy, czy mo¿emy zaatakowaæ
        if (borgo.hex[idHex].isLife)
        {
            if (health > 0)
            {
                //medyk leczy atakowanego
                ArrayList a = borgo.isLooking(idHex + 1, "Medic");
                if ((bool)a[0])
                {
                    if (borgo.hex[Int32.Parse(a[1].ToString())].distance[Int32.Parse(a[2].ToString())] == 2)
                    {
                        health--;
                        Delete.Delete(Int32.Parse(a[1].ToString()));
                    }
                }

                //obni¿enie zdrowia atakowanego (nie jest on na razie usuwany, poniewa¿ nawet, je¿eli bêdzie mia³ -100 ¿ycia, to i tak mo¿e atakowaæ w tej inicjatywie)
                borgo.hex[idHex - 1].setHealth(borgo.hex[idHex - 1].health - health);
            }
            else if (isNet)
            {
                borgo.net.Add(idHex - 1);
            }
        }
    }

}
