using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{
    public int damage = 10;
    //public float range = 50f;
    public GameObject Player;
    bool targeting;
    public GameObject targetPosition;
    public GameObject iceShard;
    public GameObject currentPosition;
    public float speed = 1;
    public GameObject clone;
    private float Timer;
    public bool targetFound = false;
    float step;
    // Start is called before the first frame update
    void Start()
    {
        targeting = Player.GetComponent<Player>().Targeting;
    }

    // Update is called once per frame
    void Update()
    {
  
    }
   public void Setup()
    {
       
        if (Player.GetComponent<Player>().Targeting == true)
        {
            Debug.Log("BHIFDWlberghyulkgbrel");
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform != null && hit.transform.gameObject.tag == "Enemy")
                    {
                        targetPosition = hit.transform.gameObject;
                        targetFound = true;
                        GameObject clone =
                        Instantiate(iceShard, this.gameObject.transform.position, Quaternion.identity);




                        float step = speed += Time.deltaTime;
                        Debug.Log(step);
                        clone.transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, step);
                        clone.transform.parent = this.transform;
                        targetFound = false;
                    }


                }

            }
        }
    }
    public virtual void Shoot(GameObject target)
    {

        GameObject clone =
        Instantiate(iceShard, this.gameObject.transform.position, Quaternion.identity);
        float step = speed * Time.deltaTime;
        /*clone.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Timer);
        clone.transform.parent = this.transform;*/
    }

}

