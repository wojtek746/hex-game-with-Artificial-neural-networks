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
    public List<int> id;
    public List<int> net; 
    public core Core;

    public void StartGame()
    {
        hex = new List<Hex>();
        for (int i = 0; i < 40; i++)
        {
            id.Add(0);
        }
        for (int i = 0; i < 19; i++)
        {
            hex.Add(new Hex(0, new List<bool>() { false, false, false, false }, new List<int>() { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, new List<int> { 0, 0, 0, 0, 0, 0 }, false, false, ""));
        }
        objects = new List<Hex>();
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
            case "Battle":
                return 12;
            case "Move":
                return 13;
            case "Grenade":
                return 14; 
            default:
                return 0; 
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
                if (hex[a - 1].name == name)
                {
                    int j = (i + 3) % 6;
                    return new ArrayList() { true, a, j }; //0 - czy si� patrzy, 1 - gdzie jest patrz�cy, 2 - w kt�r� stron� musi patrze�, �eby widzie�
                }
            }
        }
        return new ArrayList() { false };
    }
}
