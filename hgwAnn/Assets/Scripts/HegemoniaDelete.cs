using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HegemoniaDelete : MonoBehaviour
{
    public HegemoniaCore hegemonia;
    public HegemoniaConfig Config; 

    private void Start()
    {
        hegemonia = FindObjectsOfType<HegemoniaCore>()[0];
        Config = FindObjectsOfType<HegemoniaConfig>()[0];
    }

    public void Delete(int idHex)
    {
        GameObject hex;
        if (idHex > 0 && idHex < 20)
        {
            //usuwanie elementu z planszy
            UnityEngine.Debug.Log($"hegemonia Delete({idHex})");
            hex = GameObject.Find("hex " + idHex);
            if (hegemonia.hex[idHex - 1].isLife) 
            {
                //usuwamy elementy funkcyjne
                if (hegemonia.hex[idHex - 1].name == "HQ" || hegemonia.hex[idHex - 1].name == "Scout")
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (hegemonia.hex[idHex - 1].functions[i] > 0) 
                        {
                            int a = hegemonia.Around(idHex, i, 0);
                            if (a != 0)
                            {
                                if (hegemonia.hex[a - 1].isLife) 
                                {
                                    hegemonia.hex[a - 1].setInitiative(hegemonia.objects[hegemonia.GetId(hegemonia.hex[a - 1].name)].initiative[1], 1); 
                                }
                            }
                        }
                    }
                }
                else if (hegemonia.hex[idHex - 1].name == "Officer" || hegemonia.hex[idHex - 1].name == "Super_Officer") 
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (hegemonia.hex[idHex - 1].functions[i] > 0) 
                        {
                            int a = hegemonia.Around(idHex, i, 0);
                            if (a != 0)
                            {
                                if (hegemonia.hex[a - 1].isLife) 
                                {
                                    if (hegemonia.objects[hegemonia.GetId(hegemonia.hex[a - 1].name)].strength[0] < hegemonia.hex[a - 1].strength[0]) 
                                    {
                                        hegemonia.hex[a - 1].setStrength(hegemonia.hex[a - 1].strength[0] - 1, 0); 
                                    }
                                }
                            }
                        }
                    }
                }
                //usuwamy objekt ze sceny
                for (int i = 0; i < hex.transform.childCount; i++)
                {
                    Destroy(hex.transform.GetChild(i).gameObject);
                }

                //usuwamy objekt z id[]
                hegemonia.id[idHex * 2] = 0;
                hegemonia.id[idHex * 2 + 1] = 0;

                //usuwamy element z hex[]
                hegemonia.hex[idHex - 1].setHealth(0);
                hegemonia.hex[idHex - 1].setWhereLook(0);
                for(int i = 0; i < 4; i++)
                {
                    hegemonia.hex[idHex - 1].setInitiative(false, i); 
                }
                for(int i = 0; i < 6; i++)
                {
                    hegemonia.hex[idHex - 1].setDistance(0, i); 
                }
                for(int i = 0; i < 6; i++)
                {
                    hegemonia.hex[idHex - 1].setStrength(0, i); 
                }
                for(int i = 0; i < 6; i++)
                {
                    hegemonia.hex[idHex - 1].setFunctions(0, i);
                }
                hegemonia.hex[idHex - 1].setNet(false);
                hegemonia.hex[idHex - 1].setIsLife(false);
                hegemonia.hex[idHex - 1].setName("");
            }
        }
        else
        {
            //usuwanie ze sklepu
            hex = GameObject.Find("hegemonia " + (idHex * -1));
            for (int i = 0; i < hex.transform.childCount; i++)
            {
                Destroy(hex.transform.GetChild(i).gameObject);
                Config.shop[idHex * -1] = 0;
            }
        }
    }

    public void DeleteAll()
    {
        //usuwa wszystkie elementy, które maj¹ 0 lub mniej ¿ycia, ale istniej¹
        UnityEngine.Debug.Log($"borgo DeleteAll()");
        Config.GetId();

        for (int i = 0; i < 19; i++)
        {
            if (hegemonia.hex[i].isLife)
            {
                if (hegemonia.hex[i].health <= 0)
                {
                    Delete(i + 1);
                }
            }
        }

        if (!Config.isHQLife(true))
        {
            Config.isLife = false;
        }
    }
}
