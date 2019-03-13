using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleContact : MonoBehaviour {


    [SerializeField]
    Vector3 force;

    void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        rb.AddForce(force, ForceMode.Impulse);
    }
}
