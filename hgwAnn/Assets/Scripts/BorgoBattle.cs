using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;
using System;

public class BorgoBattle : MonoBehaviour
{
    public BorgoCore borgo;
    public core Core;
    public BorgoDelete Delete;

    public void StartGame()
    {
        borgo = FindObjectsOfType<BorgoCore>()[0];
        Core = FindObjectsOfType<core>()[0];
        Delete = FindObjectsOfType<BorgoDelete>()[0];
    }

}
