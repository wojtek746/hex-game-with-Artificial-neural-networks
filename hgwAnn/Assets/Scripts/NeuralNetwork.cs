using System.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using static UnityEngine.JsonUtility; 
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
        Generate("hegemonia", "HQ");
        GetInputs("borgo"); 
    }

    public void Generate(string versus, string which)
    {
        string jsonFilePath = $"Assets/pliki/borgo/{versus}.json";
        if (!File.Exists(jsonFilePath))
        {
            Debug.LogError($"Plik JSON o nazwie {versus} nie istnieje");
            return;
        }
        string jsonString = File.ReadAllText(jsonFilePath);

        Dictionary<string, List<Dictionary<string, object>>> networkData = JsonUtility.FromJson<Dictionary<string, List<Dictionary<string, object>>>>(jsonString);
        Debug.Log($"Key in networkData: {networkData}");
        if (networkData.ContainsKey(which))
        {
            int maxLayer = 0; 
            for (int i = 0; i < networkData[which].Count; i++)
            {
                if(Convert.ToInt32(networkData[which][i]["layer"]) > maxLayer)
                {
                    maxLayer = Convert.ToInt32(networkData[which][i]["layer"]); 
                }
            }
            int[] neuronsPerLayer = new int[maxLayer + 1];
            for (int i = 0; i < networkData[which].Count; i++)
            {
                neuronsPerLayer[Convert.ToInt32(networkData[which][i]["layer"])]++;
            }
            List<List<int>> biases = new List<List<int>>();
            for (int i = 0; i <= maxLayer; i++)
            {
                List<int> layerBiases = new List<int>(neuronsPerLayer[i]);
                biases.Add(layerBiases);
            }
            int[] biasPerLayer = new int[maxLayer + 1];
            for(int i = 0; i < biasPerLayer.Length; i++)
            {
                biasPerLayer[i]++; 
            }
            for (int i = 0; i < networkData[which].Count; i++)
            {
                int layer = Convert.ToInt32(networkData[which][i]["layer"]);
                biases[layer][biasPerLayer[layer]] = Convert.ToInt32(networkData[which][i]["bias"]);
                biasPerLayer[layer]++; 
            }
            List<List<List<List<int>>>> dendrites = new List<List<List<List<int>>>>();
            for (int i = 0; i <= maxLayer; i++)
            {
                List<List<List<int>>> layerDendrites = new List<List<List<int>>>(neuronsPerLayer[i]);
                dendrites.Add(layerDendrites);
            }

            int[] dendritePerLayer = new int[maxLayer + 1];
            for (int i = 0; i < networkData[which].Count; i++)
            {
                int layer = Convert.ToInt32(networkData[which][i]["layer"]);
                List<List<int>> dendrite = new List<List<int>> {
                    new List<int> { Convert.ToInt32(((List<Dictionary<string, object>>)networkData[which][i]["dendrites"])[0]["lookingLayer"]), Convert.ToInt32(((List<Dictionary<string, object>>)networkData[which][i]["dendrites"])[0]["lookingNeuron"]), Convert.ToInt32(((List<Dictionary<string, object>>)networkData[which][i]["dendrites"])[0]["weight"]) }
                };
                dendrites[layer][dendritePerLayer[layer]] = dendrite;
                dendritePerLayer[layer]++;
            }
            Iniciate(neuronsPerLayer, biases, dendrites); 
        }
        else
        {
            Debug.LogError($"Brak danych dla {which} w pliku JSON");
        }
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
                        if (currentProperty.nameSztab == nameSztab)
                        {

                        }
                    }
                }
            }
        }
    }
}
