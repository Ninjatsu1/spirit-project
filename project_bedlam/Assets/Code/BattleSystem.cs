using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattleSystem : MonoBehaviour
{
    public enum BattleState
    {
        OFFCOMBAT,
        START,
        PLAYERTURN,
        ENEMYTURN,
        WON,
        LOST
    }
    public BattleState state;
    public GameObject player;
    public GameObject enemy;

    public BattleHUD enemyHUD;
    public GameObject HUD_object;
    public BattleHUD playerHUD;
    Character playerCharacter;
    Character enemyCharacter;
    public TMP_Text infoDialogue;
    public Ranged ranged;
    bool hit;
   public IEnumerator SetupBattle()
    {
        
        enemy.GetComponent<AI_Move>().isMoving = false;
        HUD_object.SetActive(true);
        //Get characters into battle
        playerCharacter = player.GetComponent<Character>();
        enemyCharacter = enemy.GetComponent<Character>();
        
        enemyHUD.SetHUD(enemyCharacter);
        playerHUD.SetHUD(playerCharacter);
        state = BattleState.PLAYERTURN;
        yield return new WaitForSeconds(1f);
        PlayerTurn();
    }
    
   public IEnumerator PlayerAttack()
    {
        //Damage the enemy
        //Use skills
        enemyHUD.SetHealth(enemyCharacter.currentHealth);

        enemyCharacter.TakeDamage(playerCharacter.baseDamage);

        if (enemyCharacter.currentHealth <= 0)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
            //End battle
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        yield return new WaitForSeconds(5f);
    }
    public IEnumerator PlayerHeal()
    {
        playerCharacter.Heal(Random.Range(1, 10));
        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemyTurn());

    }
    IEnumerator EnemyTurn()
    {
        enemyHUD.SetHealth(enemyCharacter.currentHealth);

        infoDialogue.text = "Enemy turn";
        yield return new WaitForSeconds(1f);
        bool isDead = playerCharacter.TakeDamage(enemyCharacter.baseDamage);
        playerHUD.SetHealth(playerCharacter.currentHealth);
        yield return new WaitForSeconds(1f);
        if (isDead == true)
        {
            Debug.Log("ded");
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    IEnumerator EndBattle()
    {
        if (state == BattleState.WON)
        {
            Debug.Log("Won");
            //Battle won
            HUD_object.SetActive(false);
            infoDialogue.text = "";
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("Display game over");
        }
        
        yield return new WaitForSeconds(2f);
    }
    void PlayerTurn()
    {
        infoDialogue.text = "Player turn";

    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
            
        }
        StartCoroutine(PlayerAttack());

    }
    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerHeal());

    }

}
