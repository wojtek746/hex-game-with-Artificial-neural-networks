using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using static UnityEngine.JsonUtility;
using Newtonsoft.Json;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class LoadJson : MonoBehaviour
{
    public NeuralNetwork siec; 
    public void StartGame()
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
                foreach (var item in jsonData[key])
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
                siec.Iniciate(neuronsPerLayer, biases, dendrites);
            }
        }
    }
}
