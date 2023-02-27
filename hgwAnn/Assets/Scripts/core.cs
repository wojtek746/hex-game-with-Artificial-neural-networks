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
    public List<int> id; 

    void Start()
    {
        //standardowe na start
        for (int i = 0; i < 40; i++)
        {
            id.Add(0);
        }
        heg = FindObjectsOfType<HegemoniaConfig>()[0];
        bor = FindObjectsOfType<BorgoConfig>()[0];
        hegBattle = FindObjectsOfType<HegemoniaBattle>()[0];
        borBattle = FindObjectsOfType<BorgoBattle>()[0];
        hegDelete = FindObjectsOfType<HegemoniaDelete>()[0];
        borDelete = FindObjectsOfType<BorgoDelete>()[0];

        //postawianie sztabu pierwszego bota
        switch (bot1)
        {
            case "Borgo":
                bor.isLife = true; 
                bor.StartGame(1, bot2);
                GetId(1);
                UnityEngine.Debug.Log($"core Start(): bor.StartGame(): {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]}");
                break;
            case "Hegemonia":
                heg.isLife = true;
                heg.StartGame(1, bot2);
                GetId(1);
                UnityEngine.Debug.Log($"core Start(): heg.StartGame(): {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]}");
                break;
        }
        //postawianie sztabu drógiego bota
        switch (bot2)
        {
            case "Borgo":
                bor.isLife = true;
                bor.StartGame(2, bot1);
                GetId(2);
                UnityEngine.Debug.Log($"core Start(): bor.StartGame(): {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]}");
                break;
            case "Hegemonia":
                heg.isLife = true;
                heg.StartGame(2, bot1);
                GetId(2); 
                UnityEngine.Debug.Log($"core Start(): heg.StartGame(): {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]}");
                break;
        }

        //zrobienie 4x na zmianê ruchu ka¿dego bota
        //for (int j = 0; j < 4; j++)
        int j = 0; 
        for (j = 0; j <= 1000; j++)
        {
            if (!iswin)
            {
                //pierwszy bot atakuje
                switch (bot1)
                {
                    case "Hegemonia":
                        heg.Movement();
                        GetId(1); 
                        break;
                    case "Borgo":
                        bor.Movement();
                        GetId(1);
                        break;
                }
                switch (bot2)
                {
                    case "Hegemonia":
                        heg.Movement();
                        GetId(2);
                        break;
                    case "Borgo":
                        bor.Movement();
                        GetId(2);
                        break;
                }
            }
            else
            {
                break; 
            }
        }
        if(j == 1000)
        {
            lose("tie"); 
        }
    }

    public void Battle()
    {
        isBattle++; 
        for(int i = 0; i < 4; i++)
        {
            UnityEngine.Debug.Log($"core Battle(); i = {i}");
            switch (bot1)
            {
                case "Borgo":
                    borBattle.InitiativeBattle(i);
                    break;
                case "Hegemonia":
                    hegBattle.InitiativeBattle(i);
                    break;
            }
            switch (bot2)
            {
                case "Borgo":
                    borBattle.InitiativeBattle(i);
                    break;
                case "Hegemonia":
                    hegBattle.InitiativeBattle(i);
                    break;
            }
            switch (bot1)
            {
                case "Borgo":
                    bor.Net();
                    borDelete.DeleteAll();
                    if (!bor.isHQLife(false))
                    {
                        lose("Borgo");
                    }
                    break;
                case "Hegemonia":
                    heg.Net();
                    hegDelete.DeleteAll();
                    if (!heg.isHQLife(false))
                    {
                        lose("Hegemonia");
                    }
                    break;
            }
            switch (bot2)
            {
                case "Borgo":
                    bor.Net();
                    borDelete.DeleteAll();
                    if (!bor.isHQLife(false))
                    {
                        lose("Borgo");
                    }
                    break;
                case "Hegemonia":
                    heg.Net();
                    hegDelete.DeleteAll();
                    if (!heg.isHQLife(false))
                    {
                        lose("Hegemonia");
                    }
                    break;
            }
        }
    }

    public void lose(string name)
    {
        iswin = true; 
        UnityEngine.Debug.Log($"core lose({name})"); 
        if(name == "tie")
        {
            switch (bot1)
            {
                case "Hegemonia":
                    heg.lose();
                    break;
                case "Borgo":
                    bor.lose();
                    break;
            }
            switch (bot2)
            {
                case "Hegemonia":
                    heg.lose();
                    break;
                case "Borgo":
                    bor.lose();
                    break;
            }
        }
        else
        {
            switch (bot1)
            {
                case "Hegemonia":
                    if(name == bot1)
                    {
                        heg.lose();
                    }
                    break;
                case "Borgo":
                    if (name == bot1)
                    {
                        bor.lose();
                    }
                    break;
            }
            switch (bot2)
            {
                case "Hegemonia":
                    if (name == bot2)
                    {
                        heg.lose();
                    }
                    break;
                case "Borgo":
                    if (name == bot2)
                    {
                        bor.lose();
                    }
                    break;
            }
        }
    }

    public void Attack(string name, int idHex, int health, bool isNet)
    {
        UnityEngine.Debug.Log($"core Attack({name}, {idHex}, {health})");
        switch (bot1)
        {
            case "Hegemonia":
                if (name != "Hegemonia")
                {
                    GetId(2);
                    hegBattle.Attack(idHex, health, isNet);
                }
                break;
            case "Borgo":
                if (name != "Borgo")
                {
                    GetId(2);
                    borBattle.Attack(idHex, health, isNet);
                }
                break;
        }
        switch (bot2)
        {
            case "Hegemonia":
                if (name != "Hegemonia")
                {
                    GetId(1);
                    hegBattle.Attack(idHex, health, isNet);
                }
                break;
            case "Borgo":
                if (name != "Borgo")
                {
                    GetId(1);
                    borBattle.Attack(idHex, health, isNet);
                }
                break;
        }
    }

    public void GetId(int s)
    {
        switch (s)
        {
            case 1:
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
                break;
            case 2:
                switch (bot2)
                {
                    case "Hegemonia":
                        for (int i = 0; i < 40; i++)
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
                break; 
        }
    }

    public void Grenade(string name, int idHex)
    {
        UnityEngine.Debug.Log($"core Grenade({name}, {idHex})"); 
        switch (bot1)
        {
            case "Hegemonia":
                if(name != "Hegemonia")
                {
                    GetId(2); 
                    heg.GrenadeF(idHex); 
                }
                break;
            case "Borgo":
                if(name != "Borgo")
                {
                    GetId(2);
                    bor.GrenadeF(idHex); 
                }
                break; 
        }
        switch (bot2)
        {
            case "Hegemonia":
                if(name != "Hegemonia")
                {
                    GetId(1);
                    heg.GrenadeF(idHex); 
                }
                break;
            case "Borgo":
                if(name != "Borgo")
                {
                    GetId(1);
                    bor.GrenadeF(idHex); 
                }
                break; 
        }
    }

    public void Pushing(string name, int idHex)
    {
        UnityEngine.Debug.Log($"core Pushing({name}, {idHex})"); 
        //przepychanie odpowiedniego elementu odpowiedniego bota
        switch (bot1)
        {
            case "Hegemonia":
                switch (bot2){
                    case "Hegemonia":
                        if(name != "hegemonia")
                        {
                            heg.Pushing(idHex);
                        }
                        else
                        {
                            bor.Pushing(idHex); 
                        }
                        break;
                    case "Borgo":
                        if(name != "borgo")
                        {
                            bor.Pushing(idHex); 
                        }
                        else
                        {
                            heg.Pushing(idHex); 
                        }
                        break;
                }
                break;
            case "Borgo":
                switch (bot2)
                {
                    case "Hegemonia":
                        if (name != "hegemonia")
                        {
                            heg.Pushing(idHex);
                        }
                        else
                        {
                            bor.Pushing(idHex); 
                        }
                        break;
                    case "Borgo":
                        if (name != "borgo")
                        {
                            bor.Pushing(idHex);
                        }
                        else
                        {
                            heg.Pushing(idHex); 
                        }
                        break;
                }
                break;
        }
    }
}
