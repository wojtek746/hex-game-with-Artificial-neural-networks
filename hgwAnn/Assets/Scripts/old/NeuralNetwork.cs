using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System; 

public struct neuron
{
    public int layer;
    public List<dendrite> dendrites;
    public float bias; 

    public neuron(int layer, float bias)
    {
        this.layer = layer;
        this.bias = bias;
        this.dendrites = new List<dendrite>();
    }
}

public struct dendrite
{
    public int looking;
    public float weight; 

    public dendrite(int looking, float weight)
    {
        this.looking = looking;
        this.weight = weight; 
    }
}

public class NeuralNetwork : MonoBehaviour
{
    public List<neuron> neurons;
    public int lastLayer; 

    public float get(int id)
    {
        if(neurons[id].layer == 0)
        {
            return neurons[id].bias; 
        }
        float result = 0; 
        for(int i = 0; i < neurons[id].dendrites.Count; i++)
        {
            result += get(neurons[id].dendrites[i].looking) * neurons[id].dendrites[i].weight; 
        }
        return result + neurons[id].bias; 
    }

    public void set(string current, string oponnent, string name, List<int> inputs, int lastLayer = 10)
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

    public void learn(string current, string oponnent, int inputs, int speed = 5)
    {
        string filePath = Application.persistentDataPath + "/pliki/" + current + "/" + oponnent + ".json";
        string jsonData = File.ReadAllText(filePath);
        Dictionary<string, List<neuron>> data = JsonUtility.FromJson<Dictionary<string, List<neuron>>>(jsonData);
        foreach(string key in data.Keys)
        {
            set(current, oponnent, key, new List<int>());
            for (int i = 0; i < speed; i++)
            {
                int randomChoice = UnityEngine.Random.Range(0, 10);
                if (randomChoice < 3)
                {
                    int randomNeuron = UnityEngine.Random.Range(0, neurons.Count + 1);
                    if(randomNeuron == neurons.Count)
                    {
                        int randomLayer = UnityEngine.Random.Range(1, lastLayer);
                        float randomBias = UnityEngine.Random.Range(-10f, 10f);
                        neurons.Add(new neuron(randomLayer, randomBias)); 
                    }
                    int randomLooking = UnityEngine.Random.Range(0, neurons.Count) + inputs;
                    float randomWeight = UnityEngine.Random.Range(-10f, 10f);
                    neurons[randomNeuron].dendrites.Add(new dendrite(randomLooking, randomWeight)); 
                }
                else if(randomChoice < 9)
                {
                    int randomNeuron = UnityEngine.Random.Range(0, neurons.Count);
                    int randomDendrite = UnityEngine.Random.Range(0, neurons[randomNeuron].dendrites.Count + 1);
                    int randomAdd = UnityEngine.Random.Range(0, 2); 
                    if (randomDendrite == neurons[randomNeuron].dendrites.Count)
                    {
                        if (randomAdd == 1)
                        {
                            neuron updatedNeuron = neurons[randomNeuron];
                            updatedNeuron.bias += 0.1f;
                            neurons[randomNeuron] = updatedNeuron;
                        }
                        else
                        {
                            neuron updatedNeuron = neurons[randomNeuron];
                            updatedNeuron.bias -= 0.1f;
                            neurons[randomNeuron] = updatedNeuron;
                        }
                    }
                }
                else
                {
                    int randomNeuron = UnityEngine.Random.Range(0, neurons.Count);
                    if((neurons[randomNeuron].layer == lastLayer && neurons[randomNeuron].dendrites.Count > 1) || neurons[randomNeuron].layer < lastLayer)
                    {
                        int randomDendrite = UnityEngine.Random.Range(0, neurons[randomNeuron].dendrites.Count);
                        neurons[randomNeuron].dendrites.RemoveAt(randomDendrite); 
                        if(neurons[randomNeuron].dendrites.Count == 0)
                        {
                            neurons.RemoveAt(randomNeuron); 
                        }
                    }
                }
            }
        }
    }
}
