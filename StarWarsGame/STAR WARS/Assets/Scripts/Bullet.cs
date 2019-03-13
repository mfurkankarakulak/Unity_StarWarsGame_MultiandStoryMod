using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {
    public GameObject playerExplosion;

  
    void OnTriggerEnter(Collider other)
    {
        
        GameObject hit = other.gameObject;
         Health health = hit.GetComponent<Health>();

        // Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
         //Destroy(other.gameObject);


        if (health != null)
         {
             health.TakeDamage(10,other);


         }
         
        Destroy(gameObject,2);
    }
 

}
