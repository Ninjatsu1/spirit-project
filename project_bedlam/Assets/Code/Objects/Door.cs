using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject NavMeshLink;
    public bool DoorIsOpen = false;
    private Animator Anim;
    [SerializeField]
    private float closingTimer;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DoorIsOpen)
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
        if (other.tag == "Player")
        {
            Anim.GetComponent<Animator>().SetBool("DoorIsOpen", true);
            DoorIsOpen = true;
        }
    }
}
