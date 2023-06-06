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

        //ustawienie w sklepie sztabu
        GameObject hex = GameObject.Find("hegemonia 1");
        GameObject gameObject = Create.HQ;
        GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
        newObject.transform.parent = hex.transform;
        newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
        shop[1] = Hegemonia.GetId("HQ");

        //uruchomienie pythona
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python.exe";
        UnityEngine.Debug.Log($"hegemonia StartGame(): {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} hq");
        //start.Arguments = $@"C:\Users\code 3\Documents\GitHub\hex-game-with-Artificial-neural-networks\hgwAnn\Assets\python\hegemonia\borgo.py {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} hq";
        //start.Arguments = $"{Path.Combine(Application.dataPath, "python", "hegemonia", $"{Hegemonia.oponent.ToLower()}.py")} {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} hq";
        start.Arguments = $@"{pathToPython}.py {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} hq";

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
                pyth = Convert.ToInt32(a); 
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
            GameObject hex = GameObject.Find("hegemonia " + i);
            switch (random)
            {
                case 2:
                    gameObject = Create.Net_Fighter;
                    name = "net_Fighter";
                    fullName = "Net_Fighter";
                    break;
                case 3:
                    gameObject = Create.The_Boss;
                    name = "the_Boss";
                    fullName = "The_Boss";
                    break;
                case 4:
                    gameObject = Create.OfficerII;
                    name = "officerII";
                    fullName = "OfficerII";
                    break;
                case 5:
                    gameObject = Create.Runner;
                    name = "runner";
                    fullName = "Runner";
                    break;
                case 6:
                    gameObject = Create.Guard;
                    name = "guard";
                    fullName = "Guard";
                    break;
                case 7:
                    gameObject = Create.QuarterMaster;
                    name = "quarterMaster";
                    fullName = "QuarterMaster";
                    break;
                case 8:
                    gameObject = Create.Transport;
                    name = "transport";
                    fullName = "Transport";
                    break;
                case 9:
                    gameObject = Create.Thug;
                    name = "thug";
                    fullName = "Thug";
                    break;
                case 10:
                    gameObject = Create.Net_Master;
                    name = "net_Master";
                    fullName = "Net_Master";
                    break;
                case 11:
                    gameObject = Create.Ganger;
                    name = "ganger";
                    fullName = "Ganger";
                    break;
                case 12:
                    gameObject = Create.Gladiator;
                    name = "gladiator";
                    fullName = "Gladiator";
                    break;
                case 13:
                    gameObject = Create.Uniwersal_Solider;
                    name = "uniwersal_Solider";
                    fullName = "Uniwersal_Solider";
                    break;
                case 14:
                    gameObject = Create.OfficerI;
                    name = "officerI";
                    fullName = "OfficerI";
                    break;
                case 15:
                    gameObject = Create.Scout;
                    name = "scout";
                    fullName = "Scout";
                    break;
                case 16:
                    gameObject = Create.Battle;
                    name = "battle";
                    fullName = "Battle";
                    break;
                case 17:
                    gameObject = Create.Move;
                    name = "move";
                    fullName = "Move";
                    break;
                case 18:
                    gameObject = Create.PushBack;
                    name = "pushBack";
                    fullName = "PushBack";
                    break;
                case 19:
                    gameObject = Create.Sniper;
                    name = "sniper";
                    fullName = "Sniper";
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
                    gameObject = Create.Net_Fighter;
                    name = "net_Fighter";
                    fullName = "Net_Fighter";
                    break;
                case 3:
                    gameObject = Create.The_Boss;
                    name = "the_Boss";
                    fullName = "The_Boss";
                    break;
                case 4:
                    gameObject = Create.OfficerII;
                    name = "officerII";
                    fullName = "OfficerII";
                    break;
                case 5:
                    gameObject = Create.Runner;
                    name = "runner";
                    fullName = "Runner";
                    break;
                case 6:
                    gameObject = Create.Guard;
                    name = "guard";
                    fullName = "Guard";
                    break;
                case 7:
                    gameObject = Create.QuarterMaster;
                    name = "quarterMaster";
                    fullName = "QuarterMaster";
                    break;
                case 8:
                    gameObject = Create.Transport;
                    name = "transport";
                    fullName = "Transport";
                    break;
                case 9:
                    gameObject = Create.Thug;
                    name = "thug";
                    fullName = "Thug";
                    break;
                case 10:
                    gameObject = Create.Net_Master;
                    name = "net_Master";
                    fullName = "Net_Master";
                    break;
                case 11:
                    gameObject = Create.Ganger;
                    name = "ganger";
                    fullName = "Ganger";
                    break;
                case 12:
                    gameObject = Create.Gladiator;
                    name = "gladiator";
                    fullName = "Gladiator";
                    break;
                case 13:
                    gameObject = Create.Uniwersal_Solider;
                    name = "uniwersal_Solider";
                    fullName = "Uniwersal_Solider";
                    break;
                case 14:
                    gameObject = Create.OfficerI;
                    name = "officerI";
                    fullName = "OfficerI";
                    break;
                case 15:
                    gameObject = Create.Scout;
                    name = "scout";
                    fullName = "Scout";
                    break;
                case 16:
                    gameObject = Create.Battle;
                    name = "battle";
                    fullName = "Battle";
                    break;
                case 17:
                    gameObject = Create.Move;
                    name = "move";
                    fullName = "Move";
                    break;
                case 18:
                    gameObject = Create.PushBack;
                    name = "pushBack";
                    fullName = "PushBack";
                    break;
                case 19:
                    gameObject = Create.Sniper;
                    name = "sniper";
                    fullName = "Sniper";
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
                UnityEngine.Debug.Log($"hegemonia Movement(): {pathToPython}.py {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} {name}");
                start.Arguments = $"{pathToPython}.py {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} {name}";
            }
            else
            {
                //jeœli jest to granat, jest nam potrzebna jeszcze 1 zmienna na koñcu œcierzki
                int whq = 0;
                for (int j = 0; j < 19; j++)
                {
                    if (Hegemonia.GetId(Hegemonia.hex[j].name) == 1) 
                    {
                        whq = j;
                    }
                }
                whq++; 
                UnityEngine.Debug.Log($"hegemonia Movement(): {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} grenade {whq}");
                start.Arguments = $"{pathToPython}.py {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} grenade {whq}";
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
                Core.Grenade("Hegemonia", pyth);
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
            if (Hegemonia.hex[i].name == "HQ")
            {
                return true;
            }
        }
        return false;
    }

    public void GetId()
    {
        //pobranie tablicy id z rdzenia (nie wa¿ne jak dzia³a, wa¿ne, ¿e dzia³a xd)
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

    public void GrenadeF(int idHex)
    {
        //rdzeñ wysy³a informacjê, ¿e przeciwnik wys³a³ na nasz¹ jednostkê granat
        GetId();
        if (Hegemonia.GetId(Hegemonia.hex[idHex - 1].name) > 1) 
        {
            Delete.Delete(idHex);
        }
    }

    public void Pushing(int idHex)
    {
        UnityEngine.Debug.Log($"hegemonia Pushing({idHex})");
        //sprawdzanie, cze mo¿na przepchn¹æ
        if (Hegemonia.hex[idHex - 1].name != "")
        {
            //uruchomienie pythona
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            UnityEngine.Debug.Log($"hegemonia Pushing({idHex}): {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]}");
            start.Arguments = $"{pathToPython}.py {Hegemonia.id[2]} {Hegemonia.id[3]} {Hegemonia.id[4]} {Hegemonia.id[5]} {Hegemonia.id[6]} {Hegemonia.id[7]} {Hegemonia.id[8]} {Hegemonia.id[9]} {Hegemonia.id[10]} {Hegemonia.id[11]} {Hegemonia.id[12]} {Hegemonia.id[13]} {Hegemonia.id[14]} {Hegemonia.id[15]} {Hegemonia.id[16]} {Hegemonia.id[17]} {Hegemonia.id[18]} {Hegemonia.id[19]} {Hegemonia.id[20]} {Hegemonia.id[21]} {Hegemonia.id[22]} {Hegemonia.id[23]} {Hegemonia.id[24]} {Hegemonia.id[25]} {Hegemonia.id[26]} {Hegemonia.id[27]} {Hegemonia.id[28]} {Hegemonia.id[29]} {Hegemonia.id[30]} {Hegemonia.id[31]} {Hegemonia.id[32]} {Hegemonia.id[33]} {Hegemonia.id[34]} {Hegemonia.id[35]} {Hegemonia.id[36]} {Hegemonia.id[37]} {Hegemonia.id[38]} {Hegemonia.id[39]} pushing {idHex}";
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
            switch (Hegemonia.id[idHex * 2])
            {
                case 2:
                    name = "Net_Fighter";
                    break;
                case 3:
                    name = "The_Boss";
                    break;
                case 4:
                    name = "OfficerII";
                    break;
                case 5:
                    name = "Runner";
                    break;
                case 6:
                    name = "Guard";
                    break;
                case 7:
                    name = "QuarterMaster";
                    break;
                case 8:
                    name = "Transport";
                    break;
                case 9:
                    name = "Thug";
                    break;
                case 10:
                    name = "Net_Master";
                    break;
                case 11:
                    name = "Ganger";
                    break;
                case 12:
                    name = "Gladiator";
                    break;
                case 13:
                    name = "Uniwersal_Solider";
                    break;
                case 14:
                    name = "OfficerI";
                    break;
                case 15:
                    name = "Scout";
                    break;
                default:
                    name = "";
                    break;
            }
            UnityEngine.Debug.Log($"Create({name}, {pyth}, {Hegemonia.id[(idHex * 2) + 1]})");
            UnityEngine.Debug.Log($"Delete({idHex})");
            StartCoroutine(Create.Create(name, pyth, Hegemonia.id[(idHex * 2) + 1]));
            Delete.Delete(idHex);
        }
    }

    public void lose()
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python.exe";
        start.Arguments = $"{pathToPython}Learn.py";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.CreateNoWindow = true;
    }

    public void Net()
    {
        foreach (int i in Hegemonia.net)
        {
            Hegemonia.hex[i].setNet(true); 
        }
        Hegemonia.net = new List<int>();
    }

    public void DeleteNet()
    {
        for (int i = 0; i < 19; i++)
        {
            Hegemonia.hex[i].setNet(false);
        }
    }
}
