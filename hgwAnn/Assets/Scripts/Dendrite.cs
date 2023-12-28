using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dendrite : MonoBehaviour
{
    public int lookingLayer;
    public int lookingNeuron;
    public int weight;
    private NeuralNetwork siec;

    public void Iniciate(int lookingLayer, int lookingNeuron, int weight)
    {
        this.lookingLayer = lookingLayer;
        this.lookingNeuron = lookingNeuron;
        this.weight = weight;
        GameObject currenthex = GameObject.Find("neuralNetwork");

        if (currenthex != null)
        {
            Transform hex = currenthex.transform;

            if (hex != null)
            {
                NeuralNetwork currentProperty = hex.GetComponent<NeuralNetwork>();

                if (currentProperty != null)
                {
                    siec = currentProperty; 
                }
            }
        }
    }

    public int value()
    {
        return siec.GetNeuron(lookingLayer, lookingNeuron) * weight; 
    }
}
