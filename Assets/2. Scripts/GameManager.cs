using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int area = 0;
    public static int floor = 0;
    public Colleague[] colleagues;
    public Image[] characterImg;
    public static int areaCount { get; private set; }
    private void Awake()
    {
        instance = this;
        areaCount = 2;
        colleagues = FindObjectsOfType<Colleague>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
