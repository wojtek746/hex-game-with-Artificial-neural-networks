using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour
{
    public Core core; 
    public int health;
    public string name;
    public int id;
    public string nameSztab;
    public int whereLook;
    public int whereIs;
    public List<bool> initiative;
    public List<int> distance;
    public List<int> strength;
    public List<int> functions;
    public bool net;
    public bool isLife;
    public int previousHealth;
    public List<bool> defultInitiative;
    public List<int> defultDistance;
    public List<int> defultStrength;
    public List<int> defultFunctions;
    public int virtualHealth; 
    public List<bool> virtualInitiative;
    public List<int> virtualDistance;
    public List<int> virtualStrength;
    public List<int> virtualFunctions;
    public bool virtualNet;
    public bool virtualIsLife;

    public bool isMedyk; //do zrobienia
    public bool isOficer;
    public bool isMove; //do zrobienia
    public bool isTransport; //do zrobienia
    public bool isZwiadowca;
    public bool isKwatermistrz;

    public void copyToVirtual()
    {
        virtualInitiative = initiative;
        virtualDistance = distance;
        virtualStrength = strength;
        virtualFunctions = functions;
        virtualNet = net;
        virtualIsLife = isLife;
    }

    public void afterBattle()
    {
        initiative = defultInitiative;
        distance = defultDistance;
        strength = defultStrength;
        functions = defultFunctions;
        net = false;
        UnityEngine.Debug.Log("afterBattle()");
        if (health < previousHealth)
        {
            int medic = core.isMedic(whereIs);
            health += medic;
        }
        previousHealth = health;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        core = FindObjectsOfType<Core>()[0]; 
        isLife = true; 
        previousHealth = health;
        defultInitiative = initiative;
        defultDistance = distance;
        defultStrength = strength;
        defultFunctions = functions;
    }
}
