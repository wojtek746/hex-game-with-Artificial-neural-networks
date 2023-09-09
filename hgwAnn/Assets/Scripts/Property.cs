using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour
{
    public int health;
    public string name;
    public int id;
    public string nameSztab; 
    public int whereLook;
    public List<bool> initiative;
    public List<int> distance;
    public List<int> strength;
    public List<int> functions;
    public bool net;
    public bool isLife;
    public int defultHealth;
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

    public bool isMedyk;
    public bool isOficer;
    public bool isMove;
    public bool isTransport;
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

    public void Start()
    {
        isLife = true; 
        defultHealth = health;
        defultInitiative = initiative;
        defultDistance = distance;
        defultStrength = strength;
        defultFunctions = functions;
    }
}
