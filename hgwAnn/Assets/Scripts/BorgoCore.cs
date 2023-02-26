using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class BorgoCore : MonoBehaviour
{
    public struct Hex
    {
        public int health;
        public int whereLook; 
        public List<bool> initiative;
        public List<int> distance;
        public List<int> strength;
        public List<int> functions;
        public bool net;
        public bool isLife;
        public string name;

        public Hex(int health, List<bool> initiative, List<int> distance, List<int> strength, List<int> functions, bool net, bool isLife, string name)
        {
            this.health = health;
            this.whereLook = 0; 
            this.initiative = initiative;
            this.distance = distance;
            this.strength = strength;
            this.functions = functions;
            this.net = net;
            this.isLife = isLife;
            this.name = name;
        }

        public void setHealth(int health)
        {
            this.health = health;
        }

        public void setWhereLook(int whereLook)
        {
            this.whereLook = whereLook;
        }

        public void setInitiative(bool initiative, int where)
        {
            this.initiative[where] = initiative;
        }

        public void setDistance(int distance, int where)
        {
            this.distance[where] = distance;
        }

        public void setStrength(int strength, int where)
        {
            this.strength[where] = strength;
        }

        public void setFunctions(int functions, int where)
        {
            this.functions[where] = functions;
        }

        public void setNet(bool net)
        {
            this.net = net;
        }

        public void setIsLife(bool isLife)
        {
            this.isLife = isLife;
        }

        public void setName(string name)
        {
            this.name = name;
        }
    }

    public int which;
    public string oponent;
    public List<Hex> objects;
    public List<Hex> hex;
    public core Core;

    void Start()
    {
        for (int i = 0; i < 19; i++)
        {
            hex.Add(new Hex(0, new List<bool>() { false, false, false, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, false, ""));
        }
        objects.Add(new Hex(0, new List<bool>() { false, false, false, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, false, ""));
        objects.Add(new Hex(20, new List<bool>() { false, true, false, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, new List<int> { 1, 1, 1, 1, 1, 1 }, false, true, "HQ"));
        objects.Add(new Hex(2, new List<bool>() { false, false, true, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 2, 1, 0, 0, 0, 1 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, true, "Brawler"));
        objects.Add(new Hex(1, new List<bool>() { false, false, false, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, new List<int> { 1, 1, 0, 0, 0, 1 }, false, true, "Medic"));
        objects.Add(new Hex(1, new List<bool>() { false, false, true, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 1, 1, 0, 0, 0, 1 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, true, "Mutant"));
        objects.Add(new Hex(1, new List<bool>() { false, false, true, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 2, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, true, "Super_Mutant"));
        objects.Add(new Hex(1, new List<bool>() { false, false, false, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, new List<int> { 1, 1, 0, 0, 0, 1 }, false, true, "Officer"));
        objects.Add(new Hex(2, new List<bool>() { false, false, false, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, new List<int> { 1, 1, 0, 0, 0, 1 }, false, true, "Super_Officer"));
        objects.Add(new Hex(1, new List<bool>() { false, false, false, true }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 1, 1, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, true, "Butcher"));
        objects.Add(new Hex(1, new List<bool>() { false, false, false, true }, new List<int>() { 1, 0, 0, 0, 0, 0 }, new List<int> { 1, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, true, "Assassin"));
        objects.Add(new Hex(1, new List<bool>() { false, true, false, false }, new List<int>() { 2, 0, 0, 0, 0, 0 }, new List<int> { 3, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, true, "NetFlighter"));
        objects.Add(new Hex(1, new List<bool>() { false, false, false, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, new List<int> { 1, 1, 0, 0, 0, 1 }, false, true, "Scout"));

        Core = FindObjectsOfType<core>()[0];
    }

    public int GetId(string name)
    {
        switch (name)
        {
            case "HQ":
                return 1;
            case "Brawler":
                return 2;
            case "Medic":
                return 3;
            case "Mutant":
                return 4;
            case "Super_Mutant":
                return 5;
            case "Officer":
                return 6;
            case "Super_Officer":
                return 7;
            case "Butcher":
                return 8;
            case "Assassin":
                return 9;
            case "NetFlighter":
                return 10;
            case "Scout":
                return 11;
            default:
                return 0; 
        }
    }
}
