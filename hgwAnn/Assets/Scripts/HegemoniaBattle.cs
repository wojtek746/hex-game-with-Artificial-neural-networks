using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class HegemoniaBattle : MonoBehaviour
{
    public HegemoniaCore hegemonia;
    public core Core;
    public HegemoniaDelete Delete; 

    public void StartGame()
    {
        hegemonia = FindObjectsOfType<HegemoniaCore>()[0];
        Core = FindObjectsOfType<core>()[0];
        Delete = FindObjectsOfType<HegemoniaDelete>()[0];
    }
}
