using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    public Neuron[,] neurons;
    public int[] inputs;

    public void Iniciate(int[] neuronsPerLayer, List<List<int>> biases, List<List<List<List<int>>>> dendrites)
    {
        if(neuronsPerLayer.Length != biases.Count || neuronsPerLayer.Length != dendrites.Count)
        {
            Debug.LogError("Invalid network configuration.");
            return; 
        }
        neurons = new Neuron[neuronsPerLayer.Length, Mathf.Max(neuronsPerLayer)]; 

        for(int layer = 0; layer < neuronsPerLayer.Length; layer++)
        {
            for(int neuron = 0; neuron < neuronsPerLayer[layer]; neuron++)
            {
                if(layer >= neurons.GetLength(0) || neuron >= neurons.GetLength(1))
                {
                    Debug.LogError($"Index out of range on {layer}, {neuron}");
                }
                else
                {
                    neurons[layer, neuron] = new GameObject("Neuron_" + layer + "_" + neuron).AddComponent<Neuron>();
                    neurons[layer, neuron].Iniciate(layer, neuron, biases[layer][neuron], dendrites[layer][neuron]);
                }
            }
        }
    }

    private void Start()
    {
        int[] neuronsPerLayer = new int[3] { 1, 2, 3 };
        List<List<int>> biases = new List<List<int>>();
        biases.Add(new List<int> { 1 });
        biases.Add(new List<int> { 2, 3 });
        biases.Add(new List<int> { 4, 5, 6 });
        List<List<List<List<int>>>> dendrites = new List<List<List<List<int>>>>();
        dendrites.Add(new List<List<List<int>>> {
            new List<List<int>>
            {
                new List<int> {0, 0, 1}, new List<int> {0, 1, 1}
            }
        });
        dendrites.Add(new List<List<List<int>>> {
            new List<List<int>>
            {
                new List<int> {0, 0, 2}, new List<int> {0, 1, 2}
            }, new List<List<int>>
            {
                new List<int> {0, 2, 2}, new List<int> {0, 3, 2}
            }
        });
        dendrites.Add(new List<List<List<int>>> {
            new List<List<int>>
            {
                new List<int> {0, 0, 3}, new List<int> {0, 1, 3}
            }, new List<List<int>>
            {
                new List<int> {0, 2, 3}, new List<int> {0, 3, 3}
            }, new List<List<int>>
            {
                new List<int> {0, 4, 3}, new List<int> {0, 5, 3}
            }
        });

        Iniciate(neuronsPerLayer, biases, dendrites); 
    }
}
