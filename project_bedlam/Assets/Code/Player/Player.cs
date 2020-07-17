using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public LayerMask clickMask;
    public Button[] AllCurrentSkills;
    private Animator Anim;
    public NavMeshAgent agent; //Player
    public bool Targeting = false;
    public bool isRunning = false;
    public GameObject MagicSpawn;
    private Character playerCharacter;
    public GameObject GameOverPanel;
    public bool dialogOn = false;

    public InventoryObject Inventory;
    public GameObject InventoryUI;
    private bool inventoryOn = false;
    void Start()
    {
        playerCharacter = GetComponentInChildren<Character>();
        agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
       
        RaycastHit hit;
        //NavMeshHit nav_hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) )
        {
            if (dialogOn == false && Targeting == false)
            {
                //Debug.Log(dialogOn);
                if (EventSystem.current.IsPointerOverGameObject()) //Blocks raycast click over UI
                {
                    return;
                }
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
              
            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            if (EventSystem.current.IsPointerOverGameObject()) //Blocks raycast click over UI
            {
                return;
            }
            Debug.Log("Targeting canceled");
            Targeting = false; //Cancel target
        }
      
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            isRunning = false;
            //animaatio vaihtuu

            this.GetComponent<Animator>().SetBool("isRunning", false);
        }
        else
        {
            isRunning = true;
              this.GetComponent<Animator>().SetBool("isRunning", true);

        }
        if (playerCharacter.currentHealth <= 0)
        {
            //Debug.Log("Dead");
            //Death animation
            GameOverPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryOn = !inventoryOn;
            if (inventoryOn)
            {
                Inventory.Load();
                InventoryUI.SetActive(true);
            }
            else
            {
                InventoryUI.SetActive(false);
            }
        }
        
        /*if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Inventory.Load();
        }*/
   
    }

    public void OnTriggerEnter(Collider other) //Make it clickable later
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            Inventory.AddItem(item.item, 1);
            Inventory.Save();
            Destroy(other.gameObject, 0.5f);
        }
    }
    private void OnApplicationQuit()
    {
        Inventory.Container.Clear(); //Clears inventory
    }

}
