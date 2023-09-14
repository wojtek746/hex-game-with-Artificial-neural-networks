using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class hegemonia : MonoBehaviour
{
    public int which, timer;
    public string oponent;

    public ArrayList id = new ArrayList() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public ArrayList shop = new ArrayList() { 0, 0, 0, 0 };
    public Dictionary<string, ArrayList> objects = new Dictionary<string, ArrayList>();
    public ArrayList idObjects = new ArrayList()
    {
        new ArrayList()
        {
            0, //�ycie
            new ArrayList() //w kt�rej fali atakuje
            {
                false,
                false,
                false,
                false
            },
            new ArrayList() //czy atakuje na odleg�o��(0 - blisko, 1 - daleko, 2 - sie�, 3 - mo�e sobie wybra�: 0 lub 1(zale�nie od sytuacji))
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //w kt�r� stron� atakuje i za ile
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //funkcje
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false, //czy zablokowany przez sie�
            false, //czy �yje
            "" //nazwa
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0, //�ycie
            new ArrayList() //w kt�rej fali atakuje
            {
                false,
                false,
                false,
                false
            },
            new ArrayList() //czy atakuje na odleg�o��(0 - blisko, 1 - daleko, 2 - sie�)
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //w kt�r� stron� atakuje i za ile
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //funkcje
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false, //czy zablokowany przez sie�
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0, //�ycie
            new ArrayList() //w kt�rej fali atakuje
            {
                false,
                false,
                false,
                false
            },
            new ArrayList() //czy atakuje na odleg�o��(0 - blisko, 1 - daleko, 2 - sie�)
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //w kt�r� stron� atakuje i za ile
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //funkcje
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0, //�ycie
            new ArrayList() //w kt�rej fali atakuje
            {
                false,
                false,
                false,
                false
            },
            new ArrayList() //czy atakuje na odleg�o��(0 - blisko, 1 - daleko, 2 - sie�)
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //w kt�r� stron� atakuje i za ile
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //funkcje
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0, //�ycie
            new ArrayList() //w kt�rej fali atakuje
            {
                false,
                false,
                false,
                false
            },
            new ArrayList() //czy atakuje na odleg�o��(0 - blisko, 1 - daleko, 2 - sie�)
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //w kt�r� stron� atakuje i za ile
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //funkcje
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0, //�ycie
            new ArrayList() //w kt�rej fali atakuje
            {
                false,
                false,
                false,
                false
            },
            new ArrayList() //czy atakuje na odleg�o��(0 - blisko, 1 - daleko, 2 - sie�)
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //w kt�r� stron� atakuje i za ile
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //funkcje
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0, //�ycie
            new ArrayList() //w kt�rej fali atakuje
            {
                false,
                false,
                false,
                false
            },
            new ArrayList() //czy atakuje na odleg�o��(0 - blisko, 1 - daleko, 2 - sie�)
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //w kt�r� stron� atakuje i za ile
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //funkcje
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        },
        new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false,
            ""
        }
    };
    public bool isLife = false;

    public ArrayList net = new ArrayList();

    public GameObject HQ;
    public const int hQ = 1;
    public GameObject NetFlighter;
    public const int netFlighter = 2;
    public GameObject TheBoss;
    public const int theBoss = 3;
    public GameObject OfficerI;
    public const int officerI = 4;
    public GameObject OfficerII;
    public const int officerII = 5;
    public GameObject Runner;
    public const int runner = 6;
    public GameObject Guard;
    public const int guard = 7;
    public GameObject Quartermaster;
    public const int quartermaster = 8;
    public GameObject Transport;
    public const int transport = 9;
    public GameObject Thug;
    public const int thug = 10;
    public GameObject NetMaster;
    public const int netMaster = 11;
    public GameObject Ganger;
    public const int ganger = 12;
    public GameObject Gladiator;
    public const int gladiator = 13;
    public GameObject UniversalSoldier;
    public const int universalSoldier = 14;
    public GameObject Scout;
    public const int scout = 15;
    public GameObject Battle;
    public const int battle = 16;
    public GameObject Move;
    public const int move = 17;
    public GameObject PushBack;
    public const int pushBack = 18;
    public GameObject Sniper;
    public const int sniper = 19;

    core Core;

    public void StartGame()
    {
        //uzupe�niamy elementy odpowiednimi warto�ciami
        objects["HQ"] = new ArrayList()
        {
            20, //�ycie
            new ArrayList() //w kt�rej fali atakuje
            {
                false,
                true,
                false,
                false
            },
            new ArrayList() //czy atakuje na odleg�o��(0 - blisko, 1 - daleko, 2 - sie�)
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //w kt�r� stron� atakuje i za ile
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList() //funkcje
            {
                1,
                1,
                1,
                1,
                1,
                1
            },
            false, //czy zablokowany przez sie�
            true, //czy �yje
            "HQ"
        };
        objects["Empty"] = new ArrayList()
        {
            0,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            false, 
            ""
        };
        objects["NetFlighter"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                true,
                false,
                false,
                false
            },
            new ArrayList()
            {
                2,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "NetFlighter"
        };
        objects["TheBoss"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                1,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "TheBoss"
        };
        objects["OfficerI"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                1,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "OfficerI"
        };
        objects["OfficerII"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                1,
                0,
                0,
                0,
                1
            },
            false,
            true,
            "OfficerII"
        };
        objects["Runner"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                true,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "Runner"
        };
        objects["Guard"] = new ArrayList()
        {
            2,
            new ArrayList()
            {
                false,
                false,
                true,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                1,
                0,
                0,
                0,
                1
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "Guard"
        };
        objects["Quartermaster"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "Quartermaster"
        };
        objects["Transport"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                1,
                1,
                1,
                1,
                1
            },
            false,
            true,
            "Transport"
        };
        objects["Thug"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                true,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                2,
                1,
                0,
                0,
                0,
                1
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "Thug"
        };
        objects["NetMaster"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                true,
                false
            },
            new ArrayList()
            {
                0,
                2,
                0,
                0,
                0,
                2
            },
            new ArrayList()
            {
                1,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "NetMaster"
        };
        objects["Ganger"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                false,
                true
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "Ganger"
        };
        objects["Gladiator"] = new ArrayList()
        {
            2,
            new ArrayList()
            {
                false,
                true,
                false,
                false
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                2,
                2,
                0,
                0,
                0,
                2
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "Gladiator"
        };
        objects["UniversalSoldier"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                false,
                true
            },
            new ArrayList()
            {
                1,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                2,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            false,
            true,
            "UniversalSoldier"
        };
        objects["Scout"] = new ArrayList()
        {
            1,
            new ArrayList()
            {
                false,
                false,
                false,
                true
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                0,
                0,
                0,
                0,
                0,
                0
            },
            new ArrayList()
            {
                1,
                1,
                0,
                0,
                0,
                1
            },
            false,
            true,
            "Scout"
        };

        //standardowe na start
        Core = FindObjectsOfType<core>()[0];
        GameObject hegemonia = GameObject.Find("hegemonia");
        int pyth;

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
        GameObject gameObject = HQ;
        GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
        newObject.transform.parent = hex.transform;
        newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
        shop[1] = hQ;

        //uruchomienie pythona
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python.exe";
        UnityEngine.Debug.Log($"hegemonia StartGame(): {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]} hq");
        start.Arguments = $"C:/wojtek746/hegemonia/{oponent.ToLower()}.py {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]} hq";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.CreateNoWindow = true;

        //pobranie print�w z pythona
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
        StartCoroutine(Create("HQ", pyth, 0));
        Delete(-1);
    }

    public void InitiativeBattle(int initiative)
    {
        for (int i = 0; i < 19; i++)
        {
            if (!(bool)((ArrayList)idObjects[i])[5])
            {
                if ((bool)((ArrayList)((ArrayList)idObjects[i])[1])[initiative])
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (Int32.Parse(((ArrayList)((ArrayList)idObjects[i])[3])[j].ToString()) > 0)
                        {
                            //atak na blisko
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[i])[2])[j].ToString()) == 0)
                            {
                                int a = Around(i, j, 0);
                                if (a != 0)
                                {
                                    Core.Attack("Hegemonia", a, Int32.Parse(((ArrayList)((ArrayList)idObjects[i])[3])[j].ToString()), false);
                                }
                            }
                            //atak na daleko
                            else if (Int32.Parse(((ArrayList)((ArrayList)idObjects[i])[2])[j].ToString()) == 1)
                            {
                                int k = 1;
                                while (true)
                                {
                                    int a = Around(i, j, k);
                                    if (a == 0)
                                    {
                                        break;
                                    }
                                    Core.Attack("Hegemonia", a, Int32.Parse(((ArrayList)((ArrayList)idObjects[i])[3])[j].ToString()), false);
                                    k++;
                                }
                            }
                            //sie�
                            else if (Int32.Parse(((ArrayList)((ArrayList)idObjects[i])[2])[j].ToString()) == 2)
                            {
                                int a = Around(i, j, 0);
                                if (a != 0)
                                {
                                    Core.Attack("Hegemonia", a, Int32.Parse(((ArrayList)((ArrayList)idObjects[i])[3])[j].ToString()), true);
                                }
                            }
                            //mo�e wybra�, czy na blisko, czy na daleko
                            else
                            {
                                //kod do zrobienia; tymczasowo:
                                int k = 1;
                                while (true)
                                {
                                    int a = Around(i, j, k);
                                    if (a == 0)
                                    {
                                        break;
                                    }
                                    Core.Attack("Hegemonia", a, Int32.Parse(((ArrayList)((ArrayList)idObjects[i])[3])[j].ToString()), false);
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
        idHex++; 
        //sprawdzamy, czy mo�emy zaatakowa�
        UnityEngine.Debug.Log($"{Int32.Parse(id[idHex * 2].ToString())}"); 
        if (Int32.Parse(id[idHex * 2].ToString()) > 0)
        {
            if (health > 0)
            {
                //obni�enie zdrowia atakowanego (nie jest on na razie usuwany, poniewa� nawet, je�eli b�dzie mia� -100 �ycia, to i tak mo�e atakowa� w tej inicjatywie)
                ((ArrayList)idObjects[idHex - 1])[0] = Convert.ToInt32(((ArrayList)idObjects[idHex - 1])[0]) - health;
            }
            else if (isNet)
            {
                net.Add(idHex - 1);
            }
        }
    }

    public void Movement()
    {
        GameObject gameObject;
        string name, fullName;

        GetId();

        //wylosowanie warto�ci do sklepu
        for (int i = 1; i < 4; i++)
        {
            int random = 6;
            while (random != 6 && random != 9)
            {
                random = UnityEngine.Random.Range(2, 20);
            }

            GameObject hex = GameObject.Find("hegemonia " + i); 
            switch (random)
            {
                case netFlighter:
                    gameObject = NetFlighter;
                    name = "netFlighter";
                    fullName = "NetFlighter";
                    break;
                case theBoss:
                    gameObject = TheBoss;
                    name = "theBoss";
                    fullName = "TheBoss";
                    break;
                case officerI:
                    gameObject = OfficerI;
                    name = "officerI";
                    fullName = "OfficerI";
                    break;
                case officerII:
                    gameObject = OfficerII;
                    name = "officerII";
                    fullName = "OfficerII";
                    break;
                case runner:
                    gameObject = Runner;
                    name = "runner";
                    fullName = "Runner";
                    break;
                case guard:
                    gameObject = Guard;
                    name = "guard";
                    fullName = "Guard";
                    break;
                case quartermaster:
                    gameObject = Quartermaster;
                    name = "quartermaster";
                    fullName = "Quartermaster";
                    break;
                case transport:
                    gameObject = Transport;
                    name = "transport";
                    fullName = "Transport";
                    break;
                case thug:
                    gameObject = Thug;
                    name = "thug";
                    fullName = "Thug";
                    break;
                case netMaster:
                    gameObject = NetMaster;
                    name = "netMaster";
                    fullName = "NetMaster";
                    break;
                case ganger:
                    gameObject = Ganger;
                    name = "ganger";
                    fullName = "Ganger";
                    break;
                case gladiator:
                    gameObject = Gladiator;
                    name = "gladiator";
                    fullName = "Gladiator";
                    break;
                case universalSoldier:
                    gameObject = UniversalSoldier;
                    name = "universalSoldier";
                    fullName = "UniversalSoldier";
                    break;
                case scout:
                    gameObject = Scout;
                    name = "scout";
                    fullName = "Scout";
                    break;
                case battle:
                    gameObject = Battle;
                    name = "battle";
                    fullName = "Battle";
                    break;
                case move:
                    gameObject = Move;
                    name = "move";
                    fullName = "Move";
                    break;
                case pushBack:
                    gameObject = PushBack;
                    name = "pushBack";
                    fullName = "PushBack";
                    break;
                case sniper:
                    gameObject = Sniper;
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

        //uruchomienie wszystkich element�w ze sklepu
        for (int i = 1; i < 4; i++)
        {
            switch (shop[i])
            {
                case netFlighter:
                    gameObject = NetFlighter;
                    name = "netFlighter";
                    fullName = "NetFlighter";
                    break;
                case theBoss:
                    gameObject = TheBoss;
                    name = "theBoss";
                    fullName = "TheBoss";
                    break;
                case officerI:
                    gameObject = OfficerI;
                    name = "officerI";
                    fullName = "OfficerI";
                    break;
                case officerII:
                    gameObject = OfficerII;
                    name = "officerII";
                    fullName = "OfficerII";
                    break;
                case runner:
                    gameObject = Runner;
                    name = "runner";
                    fullName = "Runner";
                    break;
                case guard:
                    gameObject = Guard;
                    name = "guard";
                    fullName = "Guard";
                    break;
                case quartermaster:
                    gameObject = Quartermaster;
                    name = "quartermaster";
                    fullName = "Quartermaster";
                    break;
                case transport:
                    gameObject = Transport;
                    name = "transport";
                    fullName = "Transport";
                    break;
                case thug:
                    gameObject = Thug;
                    name = "thug";
                    fullName = "Thug";
                    break;
                case netMaster:
                    gameObject = NetMaster;
                    name = "netMaster";
                    fullName = "NetMaster";
                    break;
                case ganger:
                    gameObject = Ganger;
                    name = "ganger";
                    fullName = "Ganger";
                    break;
                case gladiator:
                    gameObject = Gladiator;
                    name = "gladiator";
                    fullName = "Gladiator";
                    break;
                case universalSoldier:
                    gameObject = UniversalSoldier;
                    name = "universalSoldier";
                    fullName = "UniversalSoldier";
                    break;
                case scout:
                    gameObject = Scout;
                    name = "scout";
                    fullName = "Scout";
                    break;
                case battle:
                    gameObject = Battle;
                    name = "battle";
                    fullName = "Battle";
                    break;
                case move:
                    gameObject = Move;
                    name = "move";
                    fullName = "Move";
                    break;
                case pushBack:
                    gameObject = PushBack;
                    name = "pushBack";
                    fullName = "PushBack";
                    break;
                case sniper:
                    gameObject = Sniper;
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
            UnityEngine.Debug.Log($"hegemonia Movement(): {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]} {name}");
            start.Arguments = $"C:/wojtek746/hegemonia/{oponent.ToLower()}.py {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]} {name}";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;

            //pobranie print�w z pythona
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
            if (name == "pushBack")
            {
                if (pyth != 0)
                {
                    Core.Pushing("hegemonia", pyth);
                }
            }
            else if(name == "move")
            {
                Pushing(pyth); 
            }
            else
            {
                //je�eli nie jest funkcyjny, to go ustawia na planszy
                int where, rotation;
                if (pyth != 114)
                {
                    rotation = pyth % 6;
                    where = (int)Math.Floor((double)pyth / 6) + 1;
                    StartCoroutine(Create(fullName, where, rotation));
                }
            }
            if (name == "battle")
            {
                if (pyth == 1)
                {
                    Core.Battle();
                }
            }
            Delete(i * -1);
        }
    }

    public void DeleteAll()
    {
        //usuwa wszystkie elementy, kt�re maj� 0 lub mniej �ycia, ale istniej�

        GetId();

        for (int i = 0; i < 19; i++)
        {
            if ((bool)((ArrayList)idObjects[i])[6])
            {
                if (int.Parse(((ArrayList)idObjects[i])[0].ToString()) <= 0)
                {
                    Delete(i + 1);
                }
            }
        }

        if (!isHQLife(true))
        {
            isLife = false;
        }
    }

    public bool isHQLife(bool isFromHere)
    {
        if (!isFromHere)
        {
            GetId();
        }

        bool ishqLife = false;
        for (int i = 0; i < 19; i++)
        {
            if (((ArrayList)idObjects[i])[7].ToString() == "HQ")
            {
                ishqLife = true;
            }
        }
        return ishqLife;
    }

    public void GetId()
    {
        //pobranie tablicy id z rdzenia (nie wa�ne jak dzia�a, wa�ne, �e dzia�a xd)
        if (which == 1)
        {
            for (int i = 0; i < 40; i++)
            {
                id[i] = Core.id[i];
            }
        }
        else
        {
            for (int i = 0; i < 40; i++)
            {
                if (i % 2 == 0)
                {
                    id[i] = Int32.Parse(Core.id[i].ToString()) * -1;
                }
                else
                {
                    id[i] = Core.id[i];
                }
            }
        }
    }

    public int Around(int idHex, int looks, int far)
    {
        //zwraca id elementu, na kt�ry si� patrzy
        switch (idHex)
        {
            case 1:
                switch (looks)
                {
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 2;
                            case 1:
                                return 4;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 10;
                            case 2:
                                return 15;
                            case 3:
                                return 19;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 3;
                            case 1:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 2:
                switch (looks)
                {
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 4;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 12;
                            case 2:
                                return 17;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 8;
                            case 2:
                                return 11;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 1;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 3:
                switch (looks)
                {
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 1;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 7;
                            case 2:
                                return 9;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 13;
                            case 2:
                                return 18;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 4:
                switch (looks)
                {
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 9;
                            case 1:
                                return 14;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 10;
                            case 2:
                                return 13;
                            case 3:
                                return 16;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 2;
                            case 1:
                                return 1;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 5:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 1;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 2;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 9;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 15;
                            case 2:
                                return 19;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 11;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 3;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 6:
                switch (looks)
                {
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 3;
                            case 1:
                                return 1;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 10;
                            case 2:
                                return 12;
                            case 3:
                                return 14;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 11;
                            case 1:
                                return 16;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 7:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 2;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 4;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 9;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 17;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 13;
                            case 2:
                                return 16;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 3;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 8:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 3;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 2;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 12;
                            case 2:
                                return 14;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 18;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 11;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 9:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 4;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 14;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 15;
                            case 2:
                                return 18;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 5;
                            case 2:
                                return 3;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 10:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 5;
                            case 1:
                                return 1;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 4;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 14;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 19;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 16;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 11:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 6;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 5;
                            case 2:
                                return 2;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 15;
                            case 2:
                                return 17;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 16;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 12:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 7;
                            case 1:
                                return 2;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 9;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 14;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 17;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 18;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 8;
                            case 2:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 13:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 8;
                            case 1:
                                return 3;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 7;
                            case 2:
                                return 4;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 17;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 18;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 16;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 11;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 14:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 9;
                            case 1:
                                return 4;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 17;
                            case 1:
                                return 19;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 10;
                            case 2:
                                return 8;
                            case 3:
                                return 6;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 15:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 10;
                            case 1:
                                return 5;
                            case 2:
                                return 1;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 9;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 17;
                            default:
                                return 0;
                        }
                    case 3:
                        switch (far)
                        {
                            case 0:
                                return 19;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 18;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 11;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 16:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 11;
                            case 1:
                                return 6;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 10;
                            case 2:
                                return 7;
                            case 3:
                                return 4;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 18;
                            case 1:
                                return 19;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 17:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 12;
                            case 1:
                                return 7;
                            case 2:
                                return 2;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 14;
                            default:
                                return 0;
                        }
                    case 4:
                        switch (far)
                        {
                            case 0:
                                return 19;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 13;
                            case 2:
                                return 11;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 18:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 13;
                            case 1:
                                return 8;
                            case 2:
                                return 3;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 12;
                            case 2:
                                return 9;
                            default:
                                return 0;
                        }
                    case 2:
                        switch (far)
                        {
                            case 0:
                                return 19;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 16;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            case 19:
                switch (looks)
                {
                    case 0:
                        switch (far)
                        {
                            case 0:
                                return 15;
                            case 1:
                                return 10;
                            case 2:
                                return 5;
                            case 3:
                                return 1;
                            default:
                                return 0;
                        }
                    case 1:
                        switch (far)
                        {
                            case 0:
                                return 17;
                            case 1:
                                return 14;
                            default:
                                return 0;
                        }
                    case 5:
                        switch (far)
                        {
                            case 0:
                                return 18;
                            case 1:
                                return 16;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            default:
                return 0;
        }
    }

    public ArrayList isLooking(int idHex, string name)
    {
        for (int i = 0; i < 6; i++)
        {
            int a = Around(idHex, i, 0);
            if (a != 0)
            {
                if (((ArrayList)idObjects[a])[7].ToString() == name)
                {
                    int j = (i + 3) % 6;
                    return new ArrayList() { true, a, j };
                }
            }
        }
        return new ArrayList() { false };
    }

    public void GrenadeF(int idHex)
    {
        //rdze� wysy�a informacj�, �e przeciwnik wys�a� na nasz� jednostk� granat
        GetId();
        if (Int32.Parse(id[idHex * 2].ToString()) > 1)
        {
            Delete(idHex);
        }
    }

    public void Pushing(int idHex)
    {
        UnityEngine.Debug.Log($"hegemonia Pushing({idHex})");
        //sprawdzanie, cze mo�na przepchn��
        if (Int32.Parse(id[idHex * 2].ToString()) > 0)
        {
            //uruchomienie pythona
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            UnityEngine.Debug.Log($"hegemonia Pushing({idHex}): {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]}");
            start.Arguments = $"C:/wojtek746/hegemonia/{oponent.ToLower()}.py {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]} pushing {idHex}";
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;

            //pobranie print�w z pythona
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

            //przesuni�cie odpowiedniego elementu do wybranego miejsca
            string name = ""; 
            switch (id[idHex * 2])
            {
                case netFlighter:
                    name = "netFlighter";
                    break;
                case theBoss:
                    name = "theBoss";
                    break;
                case officerI:
                    name = "officerI";
                    break;
                case officerII:
                    name = "officerII";
                    break;
                case runner:
                    name = "runner";
                    break;
                case guard:
                    name = "guard";
                    break;
                case quartermaster:
                    name = "quartermaster";
                    break;
                case transport:
                    name = "transport";
                    break;
                case thug:
                    name = "thug";
                    break;
                case netMaster:
                    name = "netMaster";
                    break;
                case ganger:
                    name = "ganger";
                    break;
                case gladiator:
                    name = "gladiator";
                    break;
                case universalSoldier:
                    name = "universalSoldier";
                    break;
                case scout:
                    name = "scout";
                    break;
                default:
                    name = "";
                    break;
            }
            UnityEngine.Debug.Log($"Create({name}, {pyth}, {Int32.Parse(id[(idHex * 2) + 1].ToString())}");
            UnityEngine.Debug.Log($"Delete({idHex}");
            StartCoroutine(Create(name, pyth, Int32.Parse(id[(idHex * 2) + 1].ToString())));
            Delete(idHex);
        }
    }

    public IEnumerator Create(string name, int idHex, int rotation)
    {
        //je�eli two�ymy na planszy
        if (idHex > 0 && idHex < 20)
        {
            while (true)
            {
                //sprawdzanie, czy mo�na stworzy� w danym miejscu element
                if (Int32.Parse(id[idHex * 2].ToString()) == 0)
                {
                    GameObject gameObject;
                    int idObject;

                    switch (name)
                {
                    case "HQ":
                        gameObject = HQ;
                        idObject = hQ;
                        break;
                    case "NetFlighter":
                        gameObject = NetFlighter;
                        idObject = netFlighter;
                        break;
                    case "TheBoss":
                        gameObject = TheBoss;
                        idObject = theBoss;
                        break;
                    case "OfficerI":
                        gameObject = OfficerI;
                        idObject = officerI;
                        break;
                    case "OfficerII":
                        gameObject = OfficerII;
                        idObject = officerII;
                        break;
                    case "Runner":
                        gameObject = Runner;
                        idObject = runner;
                        break;
                    case "Guard":
                        gameObject = Guard;
                        idObject = guard;
                        break;
                    case "Quartermaster":
                        gameObject = Quartermaster;
                        idObject = quartermaster;
                        break;
                    case "Transport":
                        gameObject = Transport;
                        idObject = transport;
                        break;
                    case "Thug":
                        gameObject = Thug;
                        idObject = thug;
                        break;
                    case "NetMaster":
                        gameObject = NetMaster;
                        idObject = netMaster;
                        break;
                    case "Ganger":
                        gameObject = Ganger;
                        idObject = ganger;
                        break;
                    case "Gladiator":
                        gameObject = Gladiator;
                        idObject = gladiator;
                        break;
                    case "UniversalSoldier":
                        gameObject = UniversalSoldier;
                        idObject = universalSoldier;
                        break;
                    case "Scout":
                        gameObject = Scout;
                        idObject = scout;
                        break;
                    default:
                        gameObject = null;
                        idObject = 0;
                        break;
                }

                    if (gameObject == null)
                    {
                        StopCoroutine("Create");
                        break;
                    }

                    GameObject hex;

                    //tworzy element w id[]
                    hex = GameObject.Find("hex " + idHex);
                    id[idHex * 2] = idObject;
                    id[idHex * 2 + 1] = rotation;

                    //tworzy element w idObject[]
                    for (int i = 0; i <= 7; i++)
                    {
                        ((ArrayList)idObjects[idHex - 1])[i] = objects[name][i];
                    }

                    //tworzymy element na scenie
                    GameObject newObject = Instantiate(gameObject, hex.transform.position, hex.transform.rotation);
                    newObject.transform.parent = hex.transform;
                    newObject.transform.position = new Vector3(hex.transform.position.x, hex.transform.position.y, -1);
                    newObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation * 60));
                    UnityEngine.Debug.Log($"hegemonia Create(name: {name}, idHex: {idHex}({idObject}), rotation: {rotation}): {id[2]} {id[3]} {id[4]} {id[5]} {id[6]} {id[7]} {id[8]} {id[9]} {id[10]} {id[11]} {id[12]} {id[13]} {id[14]} {id[15]} {id[16]} {id[17]} {id[18]} {id[19]} {id[20]} {id[21]} {id[22]} {id[23]} {id[24]} {id[25]} {id[26]} {id[27]} {id[28]} {id[29]} {id[30]} {id[31]} {id[32]} {id[33]} {id[34]} {id[35]} {id[36]} {id[37]} {id[38]} {id[39]}");

                    //sprawdzamy elementy funkcyjne
                    if (name == "HQ" || name == "Scout" || name == "TheBoss")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[4])[i].ToString()) > 0)
                            {
                                int a = Around(idHex, i, 0); 
                                if (a != 0)
                                {
                                    if (((bool)((ArrayList)idObjects[a - 1])[6]))
                                    {
                                        ((ArrayList)((ArrayList)idObjects[a - 1])[1])[1] = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = isLooking(idHex, "HQ");
                        if ((bool)n[0])
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                            {
                                ((ArrayList)((ArrayList)idObjects[idHex - 1])[1])[1] = true;
                            }
                        }
                        else
                        {
                            n = isLooking(idHex, "Scout");
                            if ((bool)n[0])
                            {
                                if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                                {
                                    ((ArrayList)((ArrayList)idObjects[idHex - 1])[1])[1] = true;
                                }
                            }
                            else
                            {
                                n = isLooking(idHex, "TheBoss");
                                if ((bool)n[0])
                                {
                                    if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                                    {
                                        ((ArrayList)((ArrayList)idObjects[idHex - 1])[1])[1] = true;
                                    }
                                }
                            }
                        }
                    }
                    if (name == "OfficerI" || name == "OfficerII" || name == "TheBoss")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[4])[i].ToString()) > 0)
                            {
                                int a = Around(idHex, i, 0); 
                                if (a != 0)
                                {
                                    if (((bool)((ArrayList)idObjects[a - 1])[6]))
                                    {
                                        ((ArrayList)((ArrayList)idObjects[a - 1])[3])[0] = Int32.Parse(((ArrayList)((ArrayList)idObjects[a - 1])[3])[0].ToString());
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = isLooking(idHex, "OfficerI");
                        if ((bool)n[0])
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                            {
                                ((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0] = Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0].ToString());
                            }
                        }
                        else
                        {
                            n = isLooking(idHex, "OfficerII");
                            if ((bool)n[0])
                            {
                                if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                                {
                                    ((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0] = Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0].ToString());
                                }
                            }
                            else
                            {
                                n = isLooking(idHex, "TheBoss");
                                if ((bool)n[0])
                                {
                                    if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                                    {
                                        ((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0] = Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[3])[0].ToString());
                                    }
                                }
                            }
                        }
                    }
                    if (name == "Quartermaster")
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[4])[i].ToString()) > 0)
                            {
                                int a = Around(idHex, i, 0); 
                                if (a != 0)
                                {
                                    if (((bool)((ArrayList)idObjects[a - 1])[6]))
                                    {
                                        for (int j = 0; j < 6; j++)
                                        {
                                            if(Int32.Parse(((ArrayList)((ArrayList)objects[((ArrayList)idObjects[idHex - 1])[7].ToString()])[2])[j].ToString()) != 2)
                                            {
                                                ((ArrayList)((ArrayList)idObjects[idHex - 1])[2])[j] = 3;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ArrayList n = isLooking(idHex, "Quartermaster");
                        if ((bool)n[0])
                        {
                            if (Int32.Parse(((ArrayList)((ArrayList)idObjects[Int32.Parse(n[1].ToString()) - 1])[4])[Int32.Parse(n[2].ToString())].ToString()) > 0)
                            {
                                for (int j = 0; j < 6; j++)
                                {
                                    if (Int32.Parse(((ArrayList)((ArrayList)objects[((ArrayList)idObjects[idHex - 1])[7].ToString()])[2])[j].ToString()) != 2)
                                    {
                                        ((ArrayList)((ArrayList)idObjects[idHex - 1])[2])[j] = 3;
                                    }
                                }
                            }
                        }
                    }
                    StopCoroutine("Create");
                    break;
                }

                //sztab musi zosta� postawiony
                else if (name == "HQ")
                {
                    idHex = UnityEngine.Random.Range(0, 20);
                }
                else
                {
                    StopCoroutine("Create");
                    break; 
                }
            }
        }
        StopCoroutine("Create");
        yield return null;
    }

    public void Delete(int idHex)
    {
        GameObject hex;
        if (idHex > 0 && idHex < 20)
        {
            //usuwanie elementu z planszy
            UnityEngine.Debug.Log($"hegemonia Delete({idHex})");
            hex = GameObject.Find("hex " + idHex);
            if (Int32.Parse(id[idHex * 2].ToString()) > 0)
            {
                //usuwamy elementy funkcyjne
                if (((ArrayList)idObjects[idHex - 1])[7].ToString() == "HQ" || ((ArrayList)idObjects[idHex - 1])[7].ToString() == "Scout" || ((ArrayList)idObjects[idHex - 1])[7].ToString() == "TheBoss")
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[4])[i].ToString()) > 0)
                        {
                            int a = Around(idHex, i, 0); 
                            if (a != 0)
                            {
                                if (((bool)((ArrayList)idObjects[a - 1])[6]))
                                {
                                    ((ArrayList)((ArrayList)idObjects[a - 1])[1])[1] = ((ArrayList)((ArrayList)objects[((ArrayList)idObjects[a - 1])[7].ToString()])[1])[1];
                                }
                            }
                        }
                    }
                }
                if (((ArrayList)idObjects[idHex - 1])[7].ToString() == "Officer" || ((ArrayList)idObjects[idHex - 1])[7].ToString() == "Super_Officer" || ((ArrayList)idObjects[idHex - 1])[7].ToString() == "TheBoss")
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[4])[i].ToString()) > 0)
                        {
                            int a = Around(idHex, i, 0); 
                            if (a != 0)
                            {
                                if (((bool)((ArrayList)idObjects[a - 1])[6]))
                                {
                                    if (Int32.Parse(((ArrayList)((ArrayList)objects[((ArrayList)idObjects[a - 1])[7].ToString()])[3])[0].ToString()) < Int32.Parse(((ArrayList)((ArrayList)idObjects[a - 1])[3])[0].ToString()))
                                    {
                                        ((ArrayList)((ArrayList)idObjects[a - 1])[3])[0] = Int32.Parse(((ArrayList)((ArrayList)idObjects[a - 1])[3])[0].ToString()) - 1;
                                    }
                                }
                            }
                        }
                    }
                }
                if (((ArrayList)idObjects[idHex - 1])[7].ToString() == "Quartermaster")
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (Int32.Parse(((ArrayList)((ArrayList)idObjects[idHex - 1])[4])[i].ToString()) > 0)
                        {
                            int a = Around(idHex, i, 0); 
                            if (a != 0)
                            {
                                if (((bool)((ArrayList)idObjects[a - 1])[6]))
                                {
                                    if (Int32.Parse(((ArrayList)((ArrayList)objects[((ArrayList)idObjects[a - 1])[7].ToString()])[3])[0].ToString()) < Int32.Parse(((ArrayList)((ArrayList)idObjects[a - 1])[3])[0].ToString()))
                                    {
                                        for (int j = 0; j < 6; j++)
                                        {
                                            ((ArrayList)((ArrayList)idObjects[a - 1])[2])[j] = ((ArrayList)((ArrayList)objects[((ArrayList)idObjects[a - 1])[7].ToString()])[2])[j];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                //usuwamy element ze sceny
                for (int i = 0; i < hex.transform.childCount; i++)
                {
                    Destroy(hex.transform.GetChild(i).gameObject);
                }

                //usuwamy element z id[]
                id[idHex * 2] = 0;
                id[idHex * 2 + 1] = 0;

                //usuwamy element z idObjects[]
                for(int i = 0; i <= 7; i++)
                {
                    ((ArrayList)idObjects[idHex - 1])[i] = objects["Empty"][i];
                }
            }
        }
        else
        {
            //usuwanie ze sklepu
            hex = GameObject.Find("hegemonia " + (idHex * -1));
            for (int i = 0; i < hex.transform.childCount; i++)
            {
                Destroy(hex.transform.GetChild(i).gameObject);
                shop[idHex * -1] = 0;
            }
        }
    }

    public void lose()
    {
        ProcessStartInfo start = new ProcessStartInfo();
        start.FileName = "python.exe";
        start.Arguments = $"C:/wojtek746/hegemonia/{oponent.ToLower()}Learn.py";
        start.UseShellExecute = false;
        start.RedirectStandardOutput = true;
        start.CreateNoWindow = true;
    }

    public void Net()
    {
        foreach (int i in net)
        {
            ((ArrayList)idObjects[i])[5] = true;
        }
        net = new ArrayList();
    }

    public void DeleteNet()
    {
        for (int i = 0; i < 19; i++)
        {
            ((ArrayList)idObjects[i])[5] = false;
        }
    }
}
