using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static event Action LandSeededEvent;

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SeedLand() 
    {
        LandSeededEvent?.Invoke();
    }
}
