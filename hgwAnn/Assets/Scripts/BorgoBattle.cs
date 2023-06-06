using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borgoBattle : MonoBehaviour
{
    public GameObject currenthex;
    public Property currentProperty; 
    public void StartGame()
    {

    }

    public void InitiativeBattle(int initiative)
    {
        for(int i = 1; i <= 19; i++)
        {
            currenthex = GameObject.Find("hex " + i);

            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");

                if (hex != null)
                {
                    currentProperty = hex.GetComponent<Property>();

                    if (currentProperty != null)
                    {
                        if(currentProperty.nameSztab == "borgo")
                        {
                            //walcz
                        }
                    }
                }
            }
        }
    }
}
