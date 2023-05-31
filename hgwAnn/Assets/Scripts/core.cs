using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class core : MonoBehaviour
{
    public int isBattle = 0;
    public HegemoniaConfig heg;
    public BorgoConfig bor;
    public BorgoBattle borBattle;
    public HegemoniaBattle hegBattle;
    public BorgoDelete borDelete;
    public HegemoniaDelete hegDelete;
    public string bot1; 
    public string bot2;
    //public int[] id = new int[40];
    public bool iswin = false; 
    public List<int> id = new List<int>();

    void Start()
    {
        //standardowe na start
        heg = FindObjectsOfType<HegemoniaConfig>()[0];
        bor = FindObjectsOfType<BorgoConfig>()[0];
        hegBattle = FindObjectsOfType<HegemoniaBattle>()[0];
        borBattle = FindObjectsOfType<BorgoBattle>()[0];
        hegDelete = FindObjectsOfType<HegemoniaDelete>()[0];
        borDelete = FindObjectsOfType<BorgoDelete>()[0];

        //postawianie sztabu pierwszego bota
        bor.isLife = true;
        bor.StartGame(1, bot2);
        for (int i = 0; i < 40; i++)
        {
            id[i] = bor.GiveId(i);
        }

        //postawianie sztabu drógiego bota
        heg.isLife = true;
        heg.StartGame(2, bot1);
        GetId();

        bor.Test(); 
        heg.Test(); 
    }

    public void GetId()
    {
        switch (bot1)
        {
            case "Hegemonia":
                for (int i = 0; i < 40; i++)
                {
                    id[i] = heg.GiveId(i);
                }
                break;
            case "Borgo":
                for (int i = 0; i < 40; i++)
                {
                    id[i] = bor.GiveId(i);
                }
                break;
        }
        switch (bot2)
        {
            case "Hegemonia":
                for (int i = 0; i < 40; i++)
                {
                    if (id[i] == 0)
                    {
                        if (i % 2 == 0)
                        {
                            id[i] = heg.GiveId(i) * -1;
                        }
                        else
                        {
                            id[i] = heg.GiveId(i);
                        }
                    }
                }
                break;
            case "Borgo":
                for (int i = 0; i < 40; i++)
                {
                    if (i % 2 == 0)
                    {
                        id[i] = bor.GiveId(i) * -1;
                    }
                    else
                    {
                        id[i] = heg.GiveId(i);
                    }
                }
                break;
        }
    }
}
