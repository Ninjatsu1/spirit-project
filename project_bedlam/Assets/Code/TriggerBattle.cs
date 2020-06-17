﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBattle : MonoBehaviour
{

    public BattleSystem BattleSystem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Battle started");
            BattleSystem.StartCoroutine(BattleSystem.SetupBattle());
        }
    }
}
