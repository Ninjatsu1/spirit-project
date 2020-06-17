using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public int damage = 10;
    //public float range = 50f;
    public GameObject Player;
    public Camera cam;
    public Vector3 test;
    public Vector3 worldPosition;
    public GameObject selectedObject;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Player.GetComponent<Player>().Targeting == true)
        {
         

            Debug.Log("Ready to shoot");
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    
                    worldPosition = hit.point;
                   // Debug.Log("World position:" + worldPosition);
                    Shoot(worldPosition);

                }
                
            }
        }
    }
    
    void Shoot(Vector3 target)
    {
        RaycastHit hit = new RaycastHit();
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        Vector3 mouseposition = Input.mousePosition;
        Debug.DrawRay(this.transform.position, target, Color.green, 1000);
      //  Debug.Log(Input.mousePosition);
        if (Physics.Raycast(this.transform.position, target, out hit, 1000))
        {
            Debug.Log("Pew!");
            
            Debug.Log(hit.transform.name);
        }
    }
}
