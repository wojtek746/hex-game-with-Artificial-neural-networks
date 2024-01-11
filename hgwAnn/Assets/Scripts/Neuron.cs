using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron : MonoBehaviour
{
    public int layer;
    public int neuron;
    public int bias;
    public bool isCalculated;
    public int value; 
    public Dendrite[] dendrites;

    public void Iniciate(int layer, int neuron, int bias, List<List<int>> dendrites)
    {
        this.isCalculated = false;
        this.value = 0; 
        this.layer = layer;
        this.neuron = neuron;
        this.bias = bias;
        this.dendrites = new Dendrite[dendrites.Count];

        for(int i = 0; i < dendrites.Count; i++)
        {
            if(layer == 0 && (dendrites[i][0] >= 10 || dendrites[i][0] < 0))
            {
                Debug.LogError("Invalid neuron configuration.");
                return;
            }
            if(layer != 0 && (dendrites[i][0] >= layer || dendrites[i][0] < 0))
            {
                Debug.LogError("Invalid neuron configuration.");
                return;
            }
            this.dendrites[i] = new GameObject("Dendrite_" + layer + "_" + neuron + "_" + i).AddComponent<Dendrite>();
            GameObject I = GameObject.Find("Neuron_" + layer + "_" + neuron);
            this.dendrites[i].transform.parent = I.transform; 
            this.dendrites[i].Iniciate(dendrites[i][0], dendrites[i][1], dendrites[i][2]);
        }
    }

    public int Calculate()
    {
        int value = this.bias; 
        foreach(Dendrite dendrite in dendrites)
        {
            value += dendrite.value(); 
        }
        this.value = value;
        this.isCalculated = true; 
        return value; 
    }

    public void Destroy()
    {
        for (int dendrite = 0; dendrite < dendrites.GetLength(0); dendrite++)
        {
            DestroyImmediate(dendrites[dendrite].gameObject);
        }
    }

    public void Reset()
    {
        value = 0;
        isCalculated = false; 
    }
}
