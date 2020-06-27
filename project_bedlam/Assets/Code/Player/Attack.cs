using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject targetPosition;
    private Vector3 hit_position;
    public GameObject iceShard;
    private GameObject currentPosition;
    public float speed = 1;
    public bool targetFound = false;
    public GameObject player;
    public LayerMask clickMask;
    float step;
  
    // Update is called once per frame
    void Update()
    {
       
        if (player.GetComponent<Player>().Targeting == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Click");
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f, clickMask))
                {

                    targetPosition = hit.transform.gameObject;
                    hit_position = hit.point;
                    Debug.Log(hit.point);
                    targetFound = true;
                    
                    GameObject clone =
                    Instantiate(iceShard, this.gameObject.transform.position, Quaternion.identity);
                    iceShard.GetComponent<IceShard>().target = hit.transform.position;
                    clone.transform.parent = this.transform;
                    targetFound = false;
                    player.GetComponent<Player>().Targeting = false;

                }
                }
        }
       
        
     

    }
    public void SetTarget()
    {
        player.GetComponent<Player>().Targeting = true;


    }
}
   

