using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StartForce : MonoBehaviour {
   // public float mesafe;
    //public Transform hedef;
   

    [SerializeField]
    Vector3 force;
    
    // Use this for initialization
    void Start()
    {
       // mesafe = Vector3.Distance(transform.position, hedef.position);
       // hedef = transform.Find("Planet");
       // if (mesafe < 3)
        //{

            Rigidbody rb = GetComponent<Rigidbody>();

            rb.AddForce(force, ForceMode.Impulse);
        //}
    }

    
}
