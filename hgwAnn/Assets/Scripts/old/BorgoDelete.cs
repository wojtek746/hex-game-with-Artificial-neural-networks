using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorgoDelete : MonoBehaviour
{
    public BorgoCore borgo;
    public BorgoConfig Config; 

    public void StartGame()
    {
        borgo = FindObjectsOfType<BorgoCore>()[0];
        Config = FindObjectsOfType<BorgoConfig>()[0];
    }

    public void Delete(int idHex)
    {
        GameObject hex;
        if (idHex > 0 && idHex < 20)
        {
            //usuwanie elementu z planszy
            UnityEngine.Debug.Log($"borgo Delete({idHex})");
            hex = GameObject.Find("hex " + idHex);
            if (borgo.hex[idHex - 1].isLife) 
            {
                //usuwamy elementy funkcyjne
                if (borgo.hex[idHex - 1].name == "HQ" || borgo.hex[idHex - 1].name == "Scout")
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (borgo.hex[idHex - 1].functions[i] > 0) 
                        {
                            int a = borgo.Around(idHex, i, 0);
                            if (a != 0)
                            {
                                if (borgo.hex[a - 1].isLife) 
                                {
                                    borgo.hex[a - 1].setInitiative(borgo.objects[borgo.GetId(borgo.hex[a - 1].name)].initiative[1], 1); 
                                }
                            }
                        }
                    }
                }
                else if (borgo.hex[idHex - 1].name == "Officer" || borgo.hex[idHex - 1].name == "Super_Officer") 
                {
                    for (int i = 0; i < 6; i++)
                    {
                        if (borgo.hex[idHex - 1].functions[i] > 0) 
                        {
                            int a = borgo.Around(idHex, i, 0);
                            if (a != 0)
                            {
                                if (borgo.hex[a - 1].isLife) 
                                {
                                    if (borgo.objects[borgo.GetId(borgo.hex[a - 1].name)].strength[0] < borgo.hex[a - 1].strength[0]) 
                                    {
                                        borgo.hex[a - 1].setStrength(borgo.hex[a - 1].strength[0] - 1, 0); 
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
                borgo.id[idHex * 2] = 0;
                borgo.id[idHex * 2 + 1] = 0;

                //usuwamy element z hex[]
                borgo.hex[idHex - 1].setHealth(0);
                borgo.hex[idHex - 1].setWhereLook(0);
                for(int i = 0; i < 4; i++)
                {
                    borgo.hex[idHex - 1].setInitiative(false, i); 
                }
                for(int i = 0; i < 6; i++)
                {
                    borgo.hex[idHex - 1].setDistance(0, i); 
                }
                for(int i = 0; i < 6; i++)
                {
                    borgo.hex[idHex - 1].setStrength(0, i); 
                }
                for(int i = 0; i < 6; i++)
                {
                    borgo.hex[idHex - 1].setFunctions(0, i);
                }
                borgo.hex[idHex - 1].setNet(false);
                borgo.hex[idHex - 1].setIsLife(false);
                borgo.hex[idHex - 1].setName("");
            }
        }
        else
        {
            //usuwanie ze sklepu
            hex = GameObject.Find("borgo " + (idHex * -1));
            for (int i = 0; i < hex.transform.childCount; i++)
            {
                Destroy(hex.transform.GetChild(i).gameObject);
                Config.shop[idHex * -1] = 0;
            }
        }
    }

    public void DeleteAll()
    {
        //usuwa wszystkie elementy, kt�re maj� 0 lub mniej �ycia, ale istniej�
        UnityEngine.Debug.Log($"borgo DeleteAll()");
        Config.GetId();

        for (int i = 0; i < 19; i++)
        {
            if (borgo.hex[i].isLife)
            {
                if (borgo.hex[i].health <= 0) 
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
