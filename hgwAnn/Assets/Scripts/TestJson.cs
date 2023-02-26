using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;
//using Newtonsoft.Json;

public class TestJson : MonoBehaviour
{
    void Start()
    {
        // Serializacja obiektu do formatu JSON
        Dictionary<string, int[,,]> myDictionary = new Dictionary<string, int[,,]>();
        myDictionary["atak"] = new int[,,] { { { 11, 21, 31 }, { 41, 51, 61 } }, { { 71, 81, 91 }, { 101, 111, 121} } };

        //string json = JsonConvert.SerializeObject(myDictionary, Formatting.Indented);

        // Zapisanie JSON na dysk
        //File.WriteAllText(@"C:\wynik.json", json);

        // Deserializacja formatu JSON do obiektu
        string jsonFromFile = File.ReadAllText(@"C:\wynik.json");
        //Dictionary<string, int[,,]> deserializedDictionary = JsonConvert.DeserializeObject<Dictionary<string, int[,,]>>(jsonFromFile);
    }
}
