using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class BorgoConfig : MonoBehaviour
{
    public BorgoCore Borgo;
    public BorgoCreate Create;
    public BorgoDelete Delete;
    public BorgoBattle Battle;
    public core Core;
    public bool isLife; 

    public List<int> shop = new List<int>{ 0, 0, 0, 0, 0 };
    public string pathToPython; 

    public void StartGame(int which, string oponent)
    {
        //standardowe na start
        Borgo = FindObjectsOfType<BorgoCore>()[0];
        Create = FindObjectsOfType<BorgoCreate>()[0];
        Delete = FindObjectsOfType<BorgoDelete>()[0];
        Core = FindObjectsOfType<core>()[0];
        Battle = FindObjectsOfType<BorgoBattle>()[0];
        GameObject borgo = GameObject.Find("borgo");
        Borgo.StartGame();
        Create.StartGame();
        Delete.StartGame();
        Battle.StartGame(); 
        int pyth;
        Borgo.which = which;
        Borgo.oponent = oponent;

        string path = $"{Application.dataPath}/python/borgo/{Borgo.oponent.ToLower()}";
        pathToPython = path.Replace(@"/", @"\");

        //ustawianie sklepu w odpowiednim miejscu
        if (which == 1)
        {
            borgo.transform.position = new Vector3(-4.9f, 0.45f, 0);
        }
        else if (which != 2)
        {
            borgo.SetActive(false);
            return;
        }

        GetId();
    }

    public void GetId()
    {
        //pobranie tablicy id z rdzenia (nie wa�ne jak dzia�a, wa�ne, �e dzia�a xd)
        if (Borgo.which == 1)
        {
            for (int i = 0; i < 40; i++)
            {
                Borgo.id[i] = Int32.Parse(Core.id[i].ToString());
            }
        }
        else
        {
            for (int i = 0; i < 40; i++)
            {
                if (i % 2 == 0)
                {
                    Borgo.id[i] = Int32.Parse(Core.id[i].ToString()) * -1;
                }
                else
                {
                    Borgo.id[i] = Int32.Parse(Core.id[i].ToString());
                }
            }
        }
    }

    public int GiveId(int i)
    {
        if (i < 2)
        {
            return 0;
        }
        if (i % 2 == 0)
        {
            return Borgo.GetId(Borgo.hex[(i / 2) - 1].name);
        }
        return Borgo.hex[((i - 1) / 2) - 1].whereLook;
    }
}
