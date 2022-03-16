using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private int settings;
    private const int SettingsNumber = 2;
   
    public enum EPairNumber
    {
        NotSet = 0,
        E10Pairs = 10,
        E15Pairs = 15,
        E20Pairs = 20,
    }

    public struct Settings
    {
        public EPairNumber PairNumber;
    }

    private Settings gameSettings;

    public static
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
