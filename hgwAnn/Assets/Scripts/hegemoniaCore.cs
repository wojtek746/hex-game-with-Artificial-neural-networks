using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hegemoniaCore : MonoBehaviour
{
    hegemoniaBattle battle;
    hegemoniaCreate create; 
    public void StartGame()
    {
        battle = FindObjectsOfType<hegemoniaBattle>()[0];
        create = FindObjectsOfType<hegemoniaCreate>()[0];

        battle.StartGame();
        create.StartGame(); 
    }
}
