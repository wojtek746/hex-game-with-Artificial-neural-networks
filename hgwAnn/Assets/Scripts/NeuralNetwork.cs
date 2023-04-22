using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public struct neuron
{
    public int layer;
    public List<dendrite> dendrites;
    public int bias; 

    public neuron(int layer, int bias)
    {
        this.layer = layer;
        this.bias = bias;
        this.dendrites = new List<dendrite>();
    }
}

public struct dendrite
{
    public int looking;
    public int weight; 

    public dendrite(int looking, int weight)
    {
        this.looking = looking;
        this.weight = weight; 
    }
}

public class NeuralNetwork : MonoBehaviour
{
    public List<neuron> neurons;
    public int lastLayer; 

    public int get(int id)
    {
        if(neurons[id].layer == 0)
        {
            return neurons[id].bias; 
        }
        int result = 0; 
        for(int i = 0; i < neurons[id].dendrites.Count; i++)
        {
            result += get(neurons[id].dendrites[i].looking) * neurons[id].dendrites[i].weight; 
        }
        return result + neurons[id].bias; 
    }

    public void set(string current, string oponnent, string name, List<int> inputs, int lastLayer)
    {
        this.lastLayer = lastLayer; 
        neurons.Clear(); 

        for(int i = 0; i < inputs.Count; i++)
        {
            neurons.Add(new neuron(0, inputs[i]));
        }

        string filePath = Application.persistentDataPath + "/pliki/" + current + "/" + oponnent + ".json";
        string jsonData = File.ReadAllText(filePath);
        Dictionary<string, List<neuron>> data = JsonUtility.FromJson<Dictionary<string, List<neuron>>>(jsonData);
        List<neuron> hqNeurons = data[name];

        for (int i = 0; i < hqNeurons.Count; i++)
        {
            neurons.Add(new neuron(hqNeurons[i].layer, hqNeurons[i].bias));
            for (int j = 0; j < hqNeurons[i].dendrites.Count; j++)
            {
                neurons[neurons.Count - 1].dendrites.Add(new dendrite(hqNeurons[i].dendrites[j].looking, hqNeurons[i].dendrites[j].weight));
            }
        }
    }
}
