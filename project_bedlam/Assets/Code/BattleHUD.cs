using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider healthSlider;

    public void SetHUD(Character character)
    {
        
        nameText.text = character.CharacterName;
        levelText.text = "lvl" + character.Characterlevel;
        
        healthSlider.maxValue = character.MaxHealth;
        healthSlider.value = character.currentHealth;
        if (character.tag == "Player")
        {
            nameText.text = "";
            levelText.text = "";
        }
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;

    }
}
