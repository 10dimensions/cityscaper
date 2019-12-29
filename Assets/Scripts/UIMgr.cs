﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{   
    private static UIMgr _instance;
    public static UIMgr Instance{ get {return _instance;}}

    public GameObject MainUIPanel;

    private int _targetCount;
    public int TargetCount  { get{return _targetCount; }
                              set{_targetCount = value;}}

    private void Awake() 
    { 
        if (_instance != null && _instance != this) 
        { 
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    } 

    public void ResetTimerAndCounter()
    {
        
    }

    public void ToggleNight()
    {

    }

    public void ToggleDay()
    {

    }
    
}