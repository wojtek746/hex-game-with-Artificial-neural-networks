using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borgoCore : MonoBehaviour
{
    borgoBattle battle;
    borgoCreate create; 
    public void StartGame()
    {
        battle = FindObjectsOfType<borgoBattle>()[0];
        create = FindObjectsOfType<borgoCreate>()[0];

        battle.StartGame();
        create.StartGame(); 
    }
}
