using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExecuteRangedSkill : MonoBehaviour
{
    public int damage = 10;
    //public float range = 50f;
    public GameObject Player;
    bool targeting;
    public GameObject targetPosition;
    //public GameObject iceShard;
    public GameObject currentPosition;
    public float speed = 1;
    public GameObject clone;
    private float Timer;
    public bool targetFound = false;
    float step;
    public bool Targeting = false;
    void Start()
    {
        //targeting = Player.GetComponent<Player>().Targeting;

    }
    void Update()
    {


      
        
    }
    public void  DetectClick()
    {
        //Animaatio myöhemmin
        Debug.Log("Targeting");
        Targeting = true;
    }
    public void Shoot(GameObject Spell)
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
                   Instantiate(gameObject, this.gameObject.transform.position, Quaternion.identity);




                float step = speed += Time.deltaTime;
                Debug.Log(step);
                clone.transform.position = Vector3.MoveTowards(transform.position, hit.transform.position, step);
                clone.transform.parent = this.transform;
                targetFound = false;
            }


        }
    }

}
