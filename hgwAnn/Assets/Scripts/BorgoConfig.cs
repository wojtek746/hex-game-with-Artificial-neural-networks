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
        Delete.StartGame();
        Battle.StartGame(); 
        int pyth;
        Borgo.which = which;
        Borgo.oponent = oponent; 

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

        //ustawienie w sklepie sztabu
        GameObject hex = GameObject.Find("borgo 1");
        GameObject gameObject = Create.HQ;
        GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
        newObject.transform.parent = hex.transform;
        newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
        shop[1] = Borgo.GetId("HQ");
        ProcessStartInfo start = new ProcessStartInfo();

        //uruchomienie pythona
        start.FileName = "python.exe";
        UnityEngine.Debug.Log($"borgo StartGame(): {Borgo.id[2]} {Borgo.id[3]} {Borgo.id[4]} {Borgo.id[5]} {Borgo.id[6]} {Borgo.id[7]} {Borgo.id[8]} {Borgo.id[9]} {Borgo.id[10]} {Borgo.id[11]} {Borgo.id[12]} {Borgo.id[13]} {Borgo.id[14]} {Borgo.id[15]} {Borgo.id[16]} {Borgo.id[17]} {Borgo.id[18]} {Borgo.id[19]} {Borgo.id[20]} {Borgo.id[21]} {Borgo.id[22]} {Borgo.id[23]} {Borgo.id[24]} {Borgo.id[25]} {Borgo.id[26]} {Borgo.id[27]} {Borgo.id[28]} {Borgo.id[29]} {Borgo.id[30]} {Borgo.id[31]} {Borgo.id[32]} {Borgo.id[33]} {Borgo.id[34]} {Borgo.id[35]} {Borgo.id[36]} {Borgo.id[37]} {Borgo.id[38]} {Borgo.id[39]} hq");
        start.Arguments = $"{Path.Combine("Assets", "python", "borgo", $"{Borgo.oponent.ToLower()}.py")} {Borgo.id[2]} {Borgo.id[3]} {Borgo.id[4]} {Borgo.id[5]} {Borgo.id[6]} {Borgo.id[7]} {Borgo.id[8]} {Borgo.id[9]} {Borgo.id[10]} {Borgo.id[11]} {Borgo.id[12]} {Borgo.id[13]} {Borgo.id[14]} {Borgo.id[15]} {Borgo.id[16]} {Borgo.id[17]} {Borgo.id[18]} {Borgo.id[19]} {Borgo.id[20]} {Borgo.id[21]} {Borgo.id[22]} {Borgo.id[23]} {Borgo.id[24]} {Borgo.id[25]} {Borgo.id[26]} {Borgo.id[27]} {Borgo.id[28]} {Borgo.id[29]} {Borgo.id[30]} {Borgo.id[31]} {Borgo.id[32]} {Borgo.id[33]} {Borgo.id[34]} {Borgo.id[35]} {Borgo.id[36]} {Borgo.id[37]} {Borgo.id[38]} {Borgo.id[39]} hq";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.CreateNoWindow = true;

        //pobranie printów z pythona
        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string a = reader.ReadToEnd().ToString();
                UnityEngine.Debug.Log(a);
                pyth = Int32.Parse(a);
            }
        }

        //stworzenie sztabu w "najlepszym" miejscu
        StartCoroutine(Create.Create("HQ", 7, 0));
        Delete.Delete(-1);
    }

    public void Movement()
    {
        GameObject gameObject;
        string name, fullName;

        GetId();

        //wylosowanie wartoœci do sklepu
        for (int i = 1; i < 4; i++)
        {
            int random = UnityEngine.Random.Range(2, 15);
            GameObject hex = GameObject.Find("borgo " + i);
            switch (random)
            {
                case 2:
                    gameObject = Create.Brawler;
                    name = "brawler";
                    fullName = "Brawler";
                    break;
                case 3:
                    gameObject = Create.Medic;
                    name = "medic";
                    fullName = "Medic";
                    break;
                case 4:
                    gameObject = Create.Mutant;
                    name = "mutant";
                    fullName = "Mutant";
                    break;
                case 5:
                    gameObject = Create.Super_Mutant;
                    name = "super_Mutant";
                    fullName = "Super_Mutant";
                    break;
                case 6:
                    gameObject = Create.Officer;
                    name = "officer";
                    fullName = "Officer";
                    break;
                case 7:
                    gameObject = Create.Super_Officer;
                    name = "super_Officer";
                    fullName = "Super_Officer";
                    break;
                case 8:
                    gameObject = Create.Butcher;
                    name = "butcher";
                    fullName = "Butcher";
                    break;
                case 9:
                    gameObject = Create.Assassin;
                    name = "assassin";
                    fullName = "Assassin";
                    break;
                case 10:
                    gameObject = Create.NetFlighter;
                    name = "netFlighter";
                    fullName = "NetFlighter";
                    break;
                case 11:
                    gameObject = Create.Scout;
                    name = "scout";
                    fullName = "Scout";
                    break;
                case 12:
                    gameObject = Create.Battle;
                    name = "battle";
                    fullName = "Battle";
                    break;
                case 13:
                    gameObject = Create.Move;
                    name = "move";
                    fullName = "Move";
                    break;
                case 14:
                    gameObject = Create.Grenade;
                    name = "grenade";
                    fullName = "Grenade";
                    break;
                default:
                    gameObject = null;
                    name = "";
                    fullName = "";
                    break;
            }

            GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
            newObject.transform.parent = hex.transform;
            newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
            shop[i] = random;
        }

        //uruchomienie wszystkich elementów ze sklepu
        for (int i = 1; i < 4; i++)
        {
            switch (shop[i])
            {
                case 2:
                    gameObject = Create.Brawler;
                    name = "brawler";
                    fullName = "Brawler";
                    break;
                case 3:
                    gameObject = Create.Medic;
                    name = "medic";
                    fullName = "Medic";
                    break;
                case 4:
                    gameObject = Create.Mutant;
                    name = "mutant";
                    fullName = "Mutant";
                    break;
                case 5:
                    gameObject = Create.Super_Mutant;
                    name = "super_Mutant";
                    fullName = "Super_Mutant";
                    break;
                case 6:
                    gameObject = Create.Officer;
                    name = "officer";
                    fullName = "Officer";
                    break;
                case 7:
                    gameObject = Create.Super_Officer;
                    name = "super_Officer";
                    fullName = "Super_Officer";
                    break;
                case 8:
                    gameObject = Create.Butcher;
                    name = "butcher";
                    fullName = "Butcher";
                    break;
                case 9:
                    gameObject = Create.Assassin;
                    name = "assassin";
                    fullName = "Assassin";
                    break;
                case 10:
                    gameObject = Create.NetFlighter;
                    name = "netFlighter";
                    fullName = "NetFlighter";
                    break;
                case 11:
                    gameObject = Create.Scout;
                    name = "scout";
                    fullName = "Scout";
                    break;
                case 12:
                    gameObject = Create.Battle;
                    name = "battle";
                    fullName = "Battle";
                    break;
                case 13:
                    gameObject = Create.Move;
                    name = "move";
                    fullName = "Move";
                    break;
                case 14:
                    gameObject = Create.Grenade;
                    name = "grenade";
                    fullName = "Grenade";
                    break;
                default:
                    gameObject = null;
                    name = "";
                    fullName = "";
                    break;
            }

            //uruchomienie pythona
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            if (name != "grenade")
            {
                UnityEngine.Debug.Log($"borgo Movement(): {Borgo.id[2]} {Borgo.id[3]} {Borgo.id[4]} {Borgo.id[5]} {Borgo.id[6]} {Borgo.id[7]} {Borgo.id[8]} {Borgo.id[9]} {Borgo.id[10]} {Borgo.id[11]} {Borgo.id[12]} {Borgo.id[13]} {Borgo.id[14]} {Borgo.id[15]} {Borgo.id[16]} {Borgo.id[17]} {Borgo.id[18]} {Borgo.id[19]} {Borgo.id[20]} {Borgo.id[21]} {Borgo.id[22]} {Borgo.id[23]} {Borgo.id[24]} {Borgo.id[25]} {Borgo.id[26]} {Borgo.id[27]} {Borgo.id[28]} {Borgo.id[29]} {Borgo.id[30]} {Borgo.id[31]} {Borgo.id[32]} {Borgo.id[33]} {Borgo.id[34]} {Borgo.id[35]} {Borgo.id[36]} {Borgo.id[37]} {Borgo.id[38]} {Borgo.id[39]} {name}");
                start.Arguments = $"{Path.Combine("Assets", "python", "borgo", $"{Borgo.oponent.ToLower()}.py")} {Borgo.id[2]} {Borgo.id[3]} {Borgo.id[4]} {Borgo.id[5]} {Borgo.id[6]} {Borgo.id[7]} {Borgo.id[8]} {Borgo.id[9]} {Borgo.id[10]} {Borgo.id[11]} {Borgo.id[12]} {Borgo.id[13]} {Borgo.id[14]} {Borgo.id[15]} {Borgo.id[16]} {Borgo.id[17]} {Borgo.id[18]} {Borgo.id[19]} {Borgo.id[20]} {Borgo.id[21]} {Borgo.id[22]} {Borgo.id[23]} {Borgo.id[24]} {Borgo.id[25]} {Borgo.id[26]} {Borgo.id[27]} {Borgo.id[28]} {Borgo.id[29]} {Borgo.id[30]} {Borgo.id[31]} {Borgo.id[32]} {Borgo.id[33]} {Borgo.id[34]} {Borgo.id[35]} {Borgo.id[36]} {Borgo.id[37]} {Borgo.id[38]} {Borgo.id[39]} {name}";
            }
            else
            {
                //jeœli jest to granat, jest nam potrzebna jeszcze 1 zmienna na koñcu œcierzki
                int whq = 0;
                for (int j = 0; j < 19; j++)
                {
                    if (Borgo.GetId(Borgo.hex[j].name) == 1) 
                    {
                        whq = j;
                    }
                }
                whq++; 
                UnityEngine.Debug.Log($"borgo Movement(): {Borgo.id[2]} {Borgo.id[3]} {Borgo.id[4]} {Borgo.id[5]} {Borgo.id[6]} {Borgo.id[7]} {Borgo.id[8]} {Borgo.id[9]} {Borgo.id[10]} {Borgo.id[11]} {Borgo.id[12]} {Borgo.id[13]} {Borgo.id[14]} {Borgo.id[15]} {Borgo.id[16]} {Borgo.id[17]} {Borgo.id[18]} {Borgo.id[19]} {Borgo.id[20]} {Borgo.id[21]} {Borgo.id[22]} {Borgo.id[23]} {Borgo.id[24]} {Borgo.id[25]} {Borgo.id[26]} {Borgo.id[27]} {Borgo.id[28]} {Borgo.id[29]} {Borgo.id[30]} {Borgo.id[31]} {Borgo.id[32]} {Borgo.id[33]} {Borgo.id[34]} {Borgo.id[35]} {Borgo.id[36]} {Borgo.id[37]} {Borgo.id[38]} {Borgo.id[39]} grenade {whq}");
                start.Arguments = $"{Path.Combine("Assets", "python", "borgo", $"{Borgo.oponent.ToLower()}.py")} {Borgo.id[2]} {Borgo.id[3]} {Borgo.id[4]} {Borgo.id[5]} {Borgo.id[6]} {Borgo.id[7]} {Borgo.id[8]} {Borgo.id[9]} {Borgo.id[10]} {Borgo.id[11]} {Borgo.id[12]} {Borgo.id[13]} {Borgo.id[14]} {Borgo.id[15]} {Borgo.id[16]} {Borgo.id[17]} {Borgo.id[18]} {Borgo.id[19]} {Borgo.id[20]} {Borgo.id[21]} {Borgo.id[22]} {Borgo.id[23]} {Borgo.id[24]} {Borgo.id[25]} {Borgo.id[26]} {Borgo.id[27]} {Borgo.id[28]} {Borgo.id[29]} {Borgo.id[30]} {Borgo.id[31]} {Borgo.id[32]} {Borgo.id[33]} {Borgo.id[34]} {Borgo.id[35]} {Borgo.id[36]} {Borgo.id[37]} {Borgo.id[38]} {Borgo.id[39]} grenade {whq}";
            }
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;

            //pobranie printów z pythona
            int pyth;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string a = reader.ReadToEnd().ToString();
                    UnityEngine.Debug.Log(a);
                    pyth = Int32.Parse(a);
                }
            }

            //sprawdzanie, czy jest to element funkcyjny
            if (name == "grenade")
            {
                Core.Grenade("Borgo", pyth);
            }
            else
            {
                //je¿eli nie jest funkcyjny, to go ustawia na planszy
                int where, rotation;
                if (pyth != 114)
                {
                    rotation = pyth % 6;
                    where = (int)Math.Floor((double)pyth / 6) + 1;
                    StartCoroutine(Create.Create(fullName, where, rotation));
                }
            }
            if (name == "battle")
            {
                if (pyth == 1)
                {
                    Core.Battle();
                }
            }
            Delete.Delete(i * -1);
        }
    }

    public bool isHQLife(bool isFromHere)
    {
        if (!isFromHere)
        {
            GetId();
        }

        for (int i = 0; i < 19; i++)
        {
            if (Borgo.hex[i].name == "HQ")
            {
                return true;
            }
        }
        return false;
    }

    public void GetId()
    {
        //pobranie tablicy id z rdzenia (nie wa¿ne jak dzia³a, wa¿ne, ¿e dzia³a xd)
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
        return Borgo.id[i];
    }

    public void GrenadeF(int idHex)
    {
        //rdzeñ wysy³a informacjê, ¿e przeciwnik wys³a³ na nasz¹ jednostkê granat
        GetId();
        if (Borgo.GetId(Borgo.hex[idHex - 1].name) > 1) 
        {
            Delete.Delete(idHex);
        }
    }

    public void Pushing(int idHex)
    {
        UnityEngine.Debug.Log($"borgo Pushing({idHex})");
        //sprawdzanie, cze mo¿na przepchn¹æ
        if (Borgo.hex[idHex - 1].name != "")
        {
            //uruchomienie pythona
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            UnityEngine.Debug.Log($"borgo Pushing({idHex}): {Borgo.id[2]} {Borgo.id[3]} {Borgo.id[4]} {Borgo.id[5]} {Borgo.id[6]} {Borgo.id[7]} {Borgo.id[8]} {Borgo.id[9]} {Borgo.id[10]} {Borgo.id[11]} {Borgo.id[12]} {Borgo.id[13]} {Borgo.id[14]} {Borgo.id[15]} {Borgo.id[16]} {Borgo.id[17]} {Borgo.id[18]} {Borgo.id[19]} {Borgo.id[20]} {Borgo.id[21]} {Borgo.id[22]} {Borgo.id[23]} {Borgo.id[24]} {Borgo.id[25]} {Borgo.id[26]} {Borgo.id[27]} {Borgo.id[28]} {Borgo.id[29]} {Borgo.id[30]} {Borgo.id[31]} {Borgo.id[32]} {Borgo.id[33]} {Borgo.id[34]} {Borgo.id[35]} {Borgo.id[36]} {Borgo.id[37]} {Borgo.id[38]} {Borgo.id[39]}");
            start.Arguments = $"{Path.Combine("Assets", "python", "borgo", $"{Borgo.oponent.ToLower()}.py")} {Borgo.id[2]} {Borgo.id[3]} {Borgo.id[4]} {Borgo.id[5]} {Borgo.id[6]} {Borgo.id[7]} {Borgo.id[8]} {Borgo.id[9]} {Borgo.id[10]} {Borgo.id[11]} {Borgo.id[12]} {Borgo.id[13]} {Borgo.id[14]} {Borgo.id[15]} {Borgo.id[16]} {Borgo.id[17]} {Borgo.id[18]} {Borgo.id[19]} {Borgo.id[20]} {Borgo.id[21]} {Borgo.id[22]} {Borgo.id[23]} {Borgo.id[24]} {Borgo.id[25]} {Borgo.id[26]} {Borgo.id[27]} {Borgo.id[28]} {Borgo.id[29]} {Borgo.id[30]} {Borgo.id[31]} {Borgo.id[32]} {Borgo.id[33]} {Borgo.id[34]} {Borgo.id[35]} {Borgo.id[36]} {Borgo.id[37]} {Borgo.id[38]} {Borgo.id[39]} pushing {idHex}";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;

            //pobranie printów z pythona
            int pyth;
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string a = reader.ReadToEnd().ToString();
                    UnityEngine.Debug.Log(a);
                    pyth = Int32.Parse(a);
                }
            }

            //przesuniêcie odpowiedniego elementu do wybranego miejsca
            string name = "";
            switch (Borgo.id[idHex * 2])
            {
                case 2:
                    name = "Brawler";
                    break;
                case 3:
                    name = "Medic";
                    break;
                case 4:
                    name = "Mutant";
                    break;
                case 5:
                    name = "Super_Mutant";
                    break;
                case 6:
                    name = "Officer";
                    break;
                case 7:
                    name = "Super_Officer";
                    break;
                case 8:
                    name = "Butcher";
                    break;
                case 9:
                    name = "Assassin";
                    break;
                case 10:
                    name = "NetFlighter";
                    break;
                case 11:
                    name = "Scout";
                    break;
                default:
                    name = "";
                    break;
            }
            UnityEngine.Debug.Log($"Create({name}, {pyth}, {Borgo.id[(idHex * 2) + 1]})");
            UnityEngine.Debug.Log($"Delete({idHex})");
            StartCoroutine(Create.Create(name, pyth, Borgo.id[(idHex * 2) + 1]));
            Delete.Delete(idHex);
        }
    }

    public void lose()
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python.exe";
        start.Arguments = $"{Path.Combine("Assets", "python", "borgo", $"{Borgo.oponent.ToLower()}Learn.py")}";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.CreateNoWindow = true;
    }

    public void Net()
    {
        foreach (int i in Borgo.net)
        {
            Borgo.hex[i].setNet(true); 
        }
        Borgo.net = new List<int>();
    }

    public void DeleteNet()
    {
        for (int i = 0; i < 19; i++)
        {
            Borgo.hex[i].setNet(false);
        }
    }
}
