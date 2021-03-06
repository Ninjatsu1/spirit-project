﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
[System.Serializable]
public class Character : MonoBehaviour
{
    
    public string CharacterName;
    public int ActionPoints;
    public int MaxHealth;
    public int currentHealth;
    public int baseDamage;
    public int CharacterLevel;
    public int level;
    //public string CharacterAlliance;
    public GameObject Player = null;
    public HealthBar healthBar;

    public bool targeting;
    [SerializeField]
    private BattleHUD BattleHUD = null;
    [SerializeField]
    private GameObject _HUD_object;
    public BattleSystem BattleSystem;
    // Start is called before the first frame update
    void Start()
    {
        BattleHUD.SetHUD(this.gameObject.GetComponent<Character>());
    }

    
    void Update()
    {
    if(currentHealth <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }
 

    
  

    public bool TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
            healthBar.SetHealth(currentHealth);

        }
        else
        {
            currentHealth += heal;
            healthBar.SetHealth(currentHealth);
        }
        healthBar.SetHealth(currentHealth);
    }
   
}
