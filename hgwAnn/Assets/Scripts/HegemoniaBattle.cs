using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class HegemoniaBattle : MonoBehaviour
{
    public HegemoniaCore hegemonia;
    public core Core;
    public HegemoniaDelete Delete; 

    public void StartGame()
    {
        hegemonia = FindObjectsOfType<HegemoniaCore>()[0];
        Core = FindObjectsOfType<core>()[0];
        Delete = FindObjectsOfType<HegemoniaDelete>()[0];
    }

    public void InitiativeBattle(int initiative)
    {
        for (int i = 0; i < 19; i++)
        {
            if (!hegemonia.hex[i].net)
            {
                if (hegemonia.hex[i].initiative[initiative]) 
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (hegemonia.hex[i].strength[j] > 0) 
                        {
                            //atak na blisko
                            if (hegemonia.hex[i].distance[j] == 0) 
                            {
                                int a = hegemonia.Around(i, j, 0);
                                if (a != 0)
                                {
                                    Core.Attack("hegemonia", a, hegemonia.hex[i].strength[j], false); 
                                }
                            }
                            //atak na daleko
                            else if (hegemonia.hex[i].distance[j] == 1)
                            {
                                int k = 1;
                                while (true)
                                {
                                    int a = hegemonia.Around(i, j, k);
                                    if (a == 0)
                                    {
                                        break;
                                    }
                                    Core.Attack("hegemonia", a, hegemonia.hex[i].strength[j], false);
                                    k++;
                                }
                            }
                            //sieæ
                            else if (hegemonia.hex[i].distance[j] == 2)
                            {
                                int a = hegemonia.Around(i, j, 0);
                                if (a != 0)
                                {
                                    Core.Attack("hegemonia", a, hegemonia.hex[i].strength[j], true);
                                }
                            }
                            //mo¿e wybraæ, czy na blisko, czy na daleko
                            else
                            {
                                //kod do zrobienia; tymczasowo:
                                int k = 1;
                                while (true)
                                {
                                    int a = hegemonia.Around(i, j, k);
                                    if (a == 0)
                                    {
                                        break;
                                    }
                                    Core.Attack("hegemonia", a, hegemonia.hex[i].strength[j], false);
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
        if (hegemonia.hex[idHex].isLife) 
        {
            if (health > 0)
            {
                //obni¿enie zdrowia atakowanego (nie jest on na razie usuwany, poniewa¿ nawet, je¿eli bêdzie mia³ -100 ¿ycia, to i tak mo¿e atakowaæ w tej inicjatywie)
                hegemonia.hex[idHex - 1].setHealth(hegemonia.hex[idHex - 1].health - health); 
            }
            else if (isNet)
            {
                hegemonia.net.Add(idHex - 1);
            }
        }
    }

}
