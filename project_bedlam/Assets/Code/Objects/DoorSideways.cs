using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSideways : MonoBehaviour
{
    
    protected bool DoorIsOpen = false;
    private Animator Anim;
    [SerializeField]
    private float closingTimer;
    protected bool DoorIsLocked = true;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (DoorIsOpen)
        {
            closingTimer += Time.deltaTime;
            Debug.Log(closingTimer);
        }
        if (closingTimer >= 5)
        {
            Anim.GetComponent<Animator>().SetBool("DoorIsOpen", false);
            DoorIsOpen = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && DoorIsLocked == false)
        {
            Anim.GetComponent<Animator>().SetBool("DoorIsOpen", true);
            DoorIsOpen = true;

        }
    }
}
