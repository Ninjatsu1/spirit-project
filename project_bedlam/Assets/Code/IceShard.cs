using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShard : Ranged
{

    int baseDamage;
    public Vector3 target;
    // Update is called once per frame
    void Update()
    {
        float step = 10 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Vahingoita hahmoa vasta sitten kun osuu
            // other.gameObject.GetComponent<Character>().TakeDamage(Random.Range(1, 10));
            other.gameObject.GetComponent<Character>().TakeDamage(5);
            Destroy(gameObject, 1f);

        }
        Destroy(gameObject, 1f);

    }

}
  
