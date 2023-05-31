using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class HegemoniaConfig : MonoBehaviour
{
    public HegemoniaCore Hegemonia;
    public HegemoniaCreate Create;
    public HegemoniaDelete Delete;
    public HegemoniaBattle Battle;
    public bool isLife; 
    public core Core;
    public string pathToPython; 

    public List<int> shop = new List<int>{ 0, 0, 0, 0, 0 };

    public void StartGame(int which, string oponent)
    {
        //standardowe na start
        Hegemonia = FindObjectsOfType<HegemoniaCore>()[0];
        Delete = FindObjectsOfType<HegemoniaDelete>()[0];
        Create = FindObjectsOfType<HegemoniaCreate>()[0];
        Battle = FindObjectsOfType<HegemoniaBattle>()[0];
        Core = FindObjectsOfType<core>()[0];
        Create.StartGame();
        Delete.StartGame();
        Battle.StartGame();
        Hegemonia.StartGame();

        GameObject hegemonia = GameObject.Find("hegemonia");
        int pyth;
        Hegemonia.which = which;
        Hegemonia.oponent = oponent;

        string path = $"{Application.dataPath}/python/hegemonia/{Hegemonia.oponent.ToLower()}";
        pathToPython = path.Replace(@"/", @"\"); 

        //ustawianie sklepu w odpowiednim miejscu
        if (which == 1)
        {
            hegemonia.transform.position = new Vector3(-4.9f, 0.45f, 0);
        }
        else if (which != 2)
        {
            hegemonia.SetActive(false);
            return;
        }

        GetId();
    }

    public void Test()
    {
        Create.Create("Runner", 2, 1);
        Create.Create("Guard", 2, 1);
        Create.Create("Guard", 3, 1);
        Delete.Delete(3); 
    }

    public void GetId()
    {
        //pobranie tablicy id z rdzenia (nie wa�ne jak dzia�a, wa�ne, �e dzia�a xd)
        if (Hegemonia.which == 1)
        {
            for (int i = 0; i < 40; i++)
            {
                Hegemonia.id[i] = Core.id[i];
            }
        }
        else
        {
            for (int i = 0; i < 40; i++)
            {
                if (i % 2 == 0)
                {
                    Hegemonia.id[i] = Core.id[i] * -1;
                }
                else
                {
                    Hegemonia.id[i] = Core.id[i];
                }
            }
        }
    }

    public int GiveId(int i)
    {
        if(i < 2)
        {
            return 0; 
        }
        if (i % 2 == 0)
        {
            return Hegemonia.GetId(Hegemonia.hex[(i / 2) - 1].name);
        }
        return Hegemonia.hex[((i - 1) / 2) - 1].whereLook; 
    }
}
