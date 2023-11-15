using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dendrite : MonoBehaviour
{
    public int lookingLayer;
    public int lookingNeuron;
    public int weight; 

    public void Iniciate(int lookingLayer, int lookingNeuron, int weight)
    {
        this.lookingLayer = lookingLayer;
        this.lookingNeuron = lookingNeuron;
        this.weight = weight;
    }
}
