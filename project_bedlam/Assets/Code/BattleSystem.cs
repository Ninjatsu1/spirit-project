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
        bool isDead = enemyCharacter.TakeDamage(playerCharacter.baseDamage);
        enemyHUD.SetHealth(enemyCharacter.currentHealth);
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
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
            //Battle won
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
