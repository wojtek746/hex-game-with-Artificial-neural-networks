using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using static UnityEngine.JsonUtility;
using Newtonsoft.Json;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class SaveJson : MonoBehaviour
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

    public void Save(string my, string versus, string which)
    {
        string jsonFilePath = $"Assets/pliki/{my}/{versus}.json";
        if (!File.Exists(jsonFilePath))
        {
            Debug.LogError($"Plik JSON o nazwie {my}/{versus} nie istnieje");
            return;
        }

        string jsonString = File.ReadAllText(jsonFilePath);
        Dictionary<string, List<Dictionary<string, object>>> jsonData = JsonConvert.DeserializeObject<Dictionary<string, List<Dictionary<string, object>>>>(jsonString);

        if (!jsonData.ContainsKey(which))
        {
            Debug.LogError($"Key '{which}' not found in the dictionary.");
            return;
        }

        List<Dictionary<string, object>> newNetworkData = new List<Dictionary<string, object>>();

        for (int i = 0; i < siec.neurons.GetLength(1); i++)
        {
            Neuron neuron = siec.neurons[10, i];

            Dictionary<string, object> neuronData = new Dictionary<string, object>
            {
                { "layer", neuron.layer },
                { "bias", neuron.bias }
            };

            List<Dictionary<string, object>> dendritesData = new List<Dictionary<string, object>>();

            foreach (var dendrite in neuron.dendrites)
            {
                Dictionary<string, object> dendriteData = new Dictionary<string, object>
                {
                    { "lookingLayer", dendrite.lookingLayer },
                    { "lookingNeuron", dendrite.lookingNeuron },
                    { "weight", dendrite.weight }
                };

                dendritesData.Add(dendriteData);
            }

            neuronData["dendrites"] = dendritesData;
            newNetworkData.Add(neuronData);
        }

        jsonData[which] = newNetworkData;

        string newJsonString = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
        File.WriteAllText(jsonFilePath, newJsonString);

        Debug.Log($"Saved network configuration to {jsonFilePath}");
    }
}
