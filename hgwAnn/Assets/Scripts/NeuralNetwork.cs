using System.Collections.Generic;
using UnityEngine;

public class NeuralNetwork : MonoBehaviour
{
    public Neuron[,] neurons = new Neuron[0, 0];
    public int[] inputs;
    public LoadJson load;
    public SaveJson save; 

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
        //neurons = new Neuron[neuronsPerLayer.Length, 114];

        for (int layer = 0; layer < neuronsPerLayer.Length; layer++)
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

    public int GetNeuron(int layer, int neuron)
    {
        if(layer == 0)
        {
            return inputs[neuron]; 
        }
        if(neurons[layer, neuron] != null)
        {
            if(neurons[layer, neuron].isCalculated)
            {
                return neurons[layer, neuron].value; 
            }
            return neurons[layer, neuron].Calculate(); 
        }
        Debug.LogError($"nie znaleziono neuronu o współżędnych {layer}, {neuron}"); 
        return 0; 
    }

    void Start()
    {
        GameObject currenthex = GameObject.Find("neuralNetwork");
        if (currenthex != null)
        {
            Transform hex = currenthex.transform;

            if (hex != null)
            {
                LoadJson currentProperty = hex.GetComponent<LoadJson>();

                if (currentProperty != null)
                {
                    load = currentProperty;
                    load.StartGame();
                }

                SaveJson currentProperty2 = hex.GetComponent<SaveJson>();

                if (currentProperty2 != null)
                {
                    save = currentProperty2;
                    save.StartGame();
                }
            }
        }

        inputs = new int[19]; 
        Generate("borgo", "hegemonia", "HQ");
        GetInputs("borgo");
        /*for (int i = 3; i < 114; i++)
        {
            neurons[10, i] = new GameObject($"Neuron_10_{i}").AddComponent<Neuron>();
            neurons[10, i].Iniciate(10, i, neurons[10, 1].bias, new List<List<int>> { new List<int> { 0, 2, 1 }, new List<int> { 0, 5, 2 } });
        }*/
        Save("hegemonia", "borgo", "HQ");
        Save("hegemonia", "borgo", "biegacz");
        Save("hegemonia", "borgo", "boss");
        Save("hegemonia", "borgo", "bydlak");
        Save("hegemonia", "borgo", "ganger");
        Save("hegemonia", "borgo", "gladiator");
        Save("hegemonia", "borgo", "kwatermistrz");
        Save("hegemonia", "borgo", "oficer");
        Save("hegemonia", "borgo", "oficer2");
        Save("hegemonia", "borgo", "sieciarz");
        Save("hegemonia", "borgo", "straznik");
        Save("hegemonia", "borgo", "supersieciarz");
        Save("hegemonia", "borgo", "transport");
        Save("hegemonia", "borgo", "uniwersalnyzolnierz");
        Save("hegemonia", "borgo", "zwiadowca");
        Save("hegemonia", "borgo", "Move");
        Save("hegemonia", "borgo", "Push");
        for (int i = 19; i < 114; i++)
        {
            neurons[10, i].Destroy();
            neurons[10, i] = null;
        }
        Save("hegemonia", "borgo", "Sniper");
        for (int i = 2; i < 19; i++)
        {
            neurons[10, i].Destroy();
            neurons[10, i] = null;
        }
        Save("hegemonia", "borgo", "Battle");

        /*Save("borgo", "hegemonia", "HQ");
        Save("borgo", "hegemonia", "medyk");
        Save("borgo", "hegemonia", "mutek");
        Save("borgo", "hegemonia", "nozownik");
        Save("borgo", "hegemonia", "oficer");
        Save("borgo", "hegemonia", "sieciarz");
        Save("borgo", "hegemonia", "silacz");
        Save("borgo", "hegemonia", "supermutant");
        Save("borgo", "hegemonia", "superoficer");
        Save("borgo", "hegemonia", "zabojca");
        Save("borgo", "hegemonia", "zwiadowca");
        Save("borgo", "hegemonia", "Move");
        for (int i = 19; i < 114; i++)
        {
            neurons[10, i].Destroy();
            neurons[10, i] = null;
        }
        Save("borgo", "hegemonia", "Grenade");
        for (int i = 2; i < 19; i++)
        {
            neurons[10, i].Destroy();
            neurons[10, i] = null;
        }
        Save("borgo", "hegemonia", "Battle");*/
        //Debug.Log(GetNeuron(10, 100)); 
        Reset(); 
    }

    public void Generate(string my, string versus, string which)
    {
        load.Generate(my, versus, which); 
    }

    public void Save(string my, string versus, string which)
    {
        save.Save(my, versus, which);
    }

    public void Reset()
    {
        for (int i = 0; i < 19; i++)
        {
            inputs[i] = 0;
        }
        for (int layer = 0; layer < neurons.GetLength(0); layer++)
        {
            for (int neuron = 0; neuron < neurons.GetLength(1); neuron++)
            {
                if (neurons[layer, neuron] != null)
                {
                    neurons[layer, neuron].Reset();
                }
            }
        }
    }

    public void Destroy()
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
                    neurons[layer, neuron].Destroy();
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
