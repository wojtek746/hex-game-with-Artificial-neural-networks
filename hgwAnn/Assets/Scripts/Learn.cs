using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : MonoBehaviour
{
    public NeuralNetwork siec;

    void Start()
    {
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

    public void AddRandomNeuron()
    {
        int layer = UnityEngine.Random.Range(0, 10); 

        int neuron = -1;
        for(int i = 0; i < siec.neurons.GetLength(1); i++)
        {
            if(siec.neurons[layer, i] == null)
            {
                neuron = i;
                break; 
            }
        }
        if(neuron == -1)
        {
            neuron = siec.neurons.GetLength(1); 
        }

        int biases = UnityEngine.Random.Range(-10, 10);

        List<List<int>> dendrites = new List<List<int>>();
        dendrites.Add(new List<int>());

        int lookingLayer = UnityEngine.Random.Range(0, layer);
        while (true)
        {
            if(lookingLayer == 0)
            {
                break; 
            }
            if(siec.neurons[lookingLayer, 0] != null)
            {
                break; 
            }
        }
        int maxNeuron = -1; 
        for(int i = 0; i < siec.neurons.GetLength(1); i++)
        {
            if (siec.neurons[layer, i] == null)
            {
                maxNeuron = i;
                break;
            }
        }
        if(maxNeuron == -1)
        {
            maxNeuron = siec.neurons.GetLength(1);
        }
        if(maxNeuron < 1)
        {
            Debug.LogError($"AddRandomNeuron ma błąd, bo wylosował layer: {layer}, neuron: {neuron}, biases: {biases}, lookingLayer: {lookingLayer}, maxNeuron: {maxNeuron}"); 
            return; 
        }
        int lookingNeuron = UnityEngine.Random.Range(0, maxNeuron);
        int weight = UnityEngine.Random.Range(-10, 10);

        dendrites[0].Add(lookingLayer);
        dendrites[0].Add(lookingNeuron);
        dendrites[0].Add(weight);

        siec.neurons[layer, neuron] = new GameObject("Neuron_" + layer + "_" + neuron).AddComponent<Neuron>();
        GameObject I = GameObject.Find("neuralNetwork");
        siec.neurons[layer, neuron].transform.parent = I.transform;
        siec.neurons[layer, neuron].Iniciate(layer, neuron, biases, dendrites);
    }

    public void RemoveRandomNeuron()
    {
        List<int> layersWithNeurons = new List<int>();
        for (int i = 1; i < 10; i++)
        {
            if (siec.neurons[i, 0] != null)
            {
                layersWithNeurons.Add(i);
            }
        }
        int layer = layersWithNeurons[UnityEngine.Random.Range(0, layersWithNeurons.Count)];
        int maxNeuron = -1;
        for (int i = 0; i < siec.neurons.GetLength(1); i++)
        {
            if (siec.neurons[layer, i] == null)
            {
                maxNeuron = i;
                break;
            }
        }
        if (maxNeuron == -1)
        {
            maxNeuron = siec.neurons.GetLength(1);
        }
        int neuron = UnityEngine.Random.Range(0, maxNeuron);
        siec.neurons[layer, neuron].Destroy();
        DestroyImmediate(siec.neurons[layer, neuron].gameObject);
        siec.neurons[layer, neuron] = null;
    }

    public void AddRandomDendrite()
    {
        List<int> layersWithNeurons = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            if (siec.neurons[i, 0] != null)
            {
                layersWithNeurons.Add(i);
            }
        }
        int layer = layersWithNeurons[UnityEngine.Random.Range(0, layersWithNeurons.Count)];

        int maxNeuron = -1;
        for (int i = 0; i < siec.neurons.GetLength(1); i++)
        {
            if (siec.neurons[layer, i] == null)
            {
                maxNeuron = i;
                break;
            }
        }
        if (maxNeuron == -1)
        {
            maxNeuron = siec.neurons.GetLength(1);
        }
        if (maxNeuron < 1)
        {
            Debug.LogError($"AddRandomDendrite ma błąd, bo wylosował layer: {layer}, maxNeuron: {maxNeuron}");
            return;
        }

        int neuron = UnityEngine.Random.Range(0, maxNeuron);

        Array.Resize(ref siec.neurons[layer, neuron].dendrites, siec.neurons[layer, neuron].dendrites.Length + 1);

        siec.neurons[layer, neuron].dendrites[siec.neurons[layer, neuron].dendrites.Length - 1] = new GameObject("Dendrite_" + layer + "_" + neuron + "_" + (siec.neurons[layer, neuron].dendrites.Length - 1)).AddComponent<Dendrite>();
        GameObject I = GameObject.Find("Neuron_" + layer + "_" + neuron);
        siec.neurons[layer, neuron].dendrites[siec.neurons[layer, neuron].dendrites.Length - 1].transform.parent = I.transform;

        int lookingLayer = UnityEngine.Random.Range(0, layer);
        while (lookingLayer > 0 && siec.neurons[lookingLayer, 0] == null)
        {
            lookingLayer = UnityEngine.Random.Range(0, layer);
        }

        maxNeuron = -1;
        for (int i = 0; i < siec.neurons.GetLength(1); i++)
        {
            if (siec.neurons[layer, i] == null)
            {
                maxNeuron = i;
                break;
            }
        }
        if (maxNeuron == -1)
        {
            maxNeuron = siec.neurons.GetLength(1);
        }
        if (maxNeuron < 1)
        {
            Debug.LogError($"AddRandomDendrite ma błąd, bo wylosował layer: {layer}, neuron: {neuron}, lookingLayer: {lookingLayer}, maxNeuron: {maxNeuron}");
            return;
        }

        int lookingNeuron = UnityEngine.Random.Range(0, maxNeuron);
        int weight = UnityEngine.Random.Range(-10, 10);
        siec.neurons[layer, neuron].dendrites[siec.neurons[layer, neuron].dendrites.Length - 1].Iniciate(lookingLayer, lookingNeuron, weight);
    }
}
