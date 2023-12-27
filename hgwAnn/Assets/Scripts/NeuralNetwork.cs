using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using static UnityEngine.JsonUtility;
using Newtonsoft.Json;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class NeuralNetwork : MonoBehaviour
{
    public Neuron[,] neurons = new Neuron[0, 0];
    public int[] inputs;

    public void Iniciate(int[] neuronsPerLayer, List<List<int>> biases, List<List<List<List<int>>>> dendrites)
    {
        if(neuronsPerLayer.Length != biases.Count || neuronsPerLayer.Length != dendrites.Count)
        {
            Debug.LogError("Invalid network configuration.");
            return; 
        }
        for(int layer = 0; layer < neuronsPerLayer.Length; layer++)
        {
            if(neuronsPerLayer[layer] != biases[layer].Count || neuronsPerLayer[layer] != dendrites[layer].Count)
            {
                Debug.LogError("Invalid network configuration.");
                return;
            }
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
        /*int[] neuronsPerLayer = new int[3] { 1, 2, 3 };
        List<List<int>> biases = new List<List<int>>();
        biases.Add(new List<int> { 1 });
        biases.Add(new List<int> { 2, 3 });
        biases.Add(new List<int> { 4, 5, 6 });
        List<List<List<List<int>>>> dendrites = new List<List<List<List<int>>>>();
        dendrites.Add(new List<List<List<int>>> {
            new List<List<int>>
            {
                new List<int> {0, 0, 1}, new List<int> {0, 1, 1}, new List<int> {0, 1, 1}, new List<int> {0, 1, 1}, new List<int> {0, 1, 1}
            }
        });
        dendrites.Add(new List<List<List<int>>> {
            new List<List<int>>
            {
                new List<int> {0, 0, 2}
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
                new List<int> {0, 2, 3}, new List<int> {0, 3, 3}, new List<int> {0, 3, 3}
            }, new List<List<int>>
            {
                new List<int> {0, 4, 3}, new List<int> {0, 5, 3}
            }
        });

        Iniciate(neuronsPerLayer, biases, dendrites); */
        inputs = new int[19]; 
        Generate("borgo", "hegemonia", "HQ");
        GetInputs("borgo");
        Reset(); 
    }

    public void Generate(string my, string versus, string which)
    {
        string jsonFilePath = $"Assets/pliki/{my}/{versus}.json";
        if (!File.Exists(jsonFilePath))
        {
            Debug.LogError($"Plik JSON o nazwie {my}/{versus} nie istnieje");
            return;
        }
        string jsonString = File.ReadAllText(jsonFilePath);

        Dictionary<string, List<Dictionary<string, object>>> jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonString);

        foreach (var key in jsonData.Keys)
        {
            if (key == which)
            {
                //Debug.Log($"Key: {key}");
                int maxLayer = 0; 
                foreach(var item in jsonData[key])
                {
                    int layer = Convert.ToInt32(item["layer"]);
                    maxLayer = Math.Max(maxLayer, layer);
                }

                int[] neuronsPerLayer = new int[maxLayer + 1];
                List<List<int>> biases = new List<List<int>>(maxLayer + 1);
                List<List<List<List<int>>>> dendrites = new List<List<List<List<int>>>>(maxLayer + 1);

                for (int i = 0; i <= maxLayer; i++)
                {
                    biases.Add(new List<int>());
                    dendrites.Add(new List<List<List<int>>>());
                }

                foreach (var item in jsonData[key])
                {
                    int layer = Convert.ToInt32(item["layer"]);
                    int bias = Convert.ToInt32(item["bias"]);
                    biases[layer].Add(bias);

                    foreach (var neuronKey in item.Keys)
                    {
                        //Debug.Log($"{neuronKey}: {item[neuronKey]}");
                        if (neuronKey == "dendrites")
                        {
                            //Debug.Log("neuronKey == 'dendrites'");
                            if (item[neuronKey] is JArray dendritesArray)
                            {
                                //Debug.Log($"{dendritesArray}");
                                List<List<int>> layerDendrites = new List<List<int>>();

                                foreach (var dendrite in dendritesArray)
                                {
                                    //Debug.Log("Dendrite:");
                                    if (dendrite is JObject dendriteObject)
                                    {
                                        int lookingLayer = Convert.ToInt32(dendriteObject["lookingLayer"]);
                                        int lookingNeuron = Convert.ToInt32(dendriteObject["lookingNeuron"]);
                                        int weight = Convert.ToInt32(dendriteObject["weight"]);

                                        layerDendrites.Add(new List<int> { lookingLayer, lookingNeuron, weight });
                                    }
                                }
                                dendrites[layer].Add(layerDendrites);
                            }
                            neuronsPerLayer[layer]++;
                        }
                    }
                }
                Iniciate(neuronsPerLayer, biases, dendrites);
            }
        }
    }

    public void Reset()
    {
        for(int i = 0; i < 19; i++)
        {
            inputs[i] = 0; 
        }
        for (int layer = 0; layer < neurons.GetLength(0); layer++)
        {
            for (int neuron = 0; neuron < neurons.GetLength(1); neuron++)
            {
                if (neurons[layer, neuron] != null)
                {
                    Debug.Log($"usuwam neurons[{layer}, {neuron}]: {neurons[layer, neuron]}"); 
                    neurons[layer, neuron].Reset();
                    Destroy(neurons[layer, neuron].gameObject);
                    neurons[layer, neuron] = null;
                }
            }
        }
        neurons = new Neuron[0, 0]; 
    }

    public void GetInputs(string nameSztab)
    {
        for (int i = 1; i <= 19; i++)
        {
            inputs[i - 1] = 0;
            GameObject currenthex = GameObject.Find("hex " + i);

            if (currenthex != null)
            {
                Transform hex = currenthex.transform.Find("hex");

                if (hex != null)
                {
                    Property currentProperty = hex.GetComponent<Property>();

                    if (currentProperty != null)
                    {
                        if(currentProperty.nameSztab == nameSztab)
                        {
                            inputs[i - 1] = currentProperty.id; 
                        }
                        else
                        {
                            inputs[i - 1] = currentProperty.id * -1; 
                        }
                    }
                }
            }
        }
        //UnityEngine.Debug.Log($"{inputs[0]}, {inputs[1]}, {inputs[2]}, {inputs[3]}, {inputs[4]}, {inputs[5]}, {inputs[6]}, {inputs[7]}, {inputs[8]}, {inputs[9]}, {inputs[10]}, {inputs[11]}, {inputs[12]}, {inputs[13]}, {inputs[14]}, {inputs[15]}, {inputs[16]}, {inputs[17]}, {inputs[18]}");
    }
}
