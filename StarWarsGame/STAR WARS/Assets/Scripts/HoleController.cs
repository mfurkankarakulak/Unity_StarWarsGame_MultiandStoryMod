using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundar
{
    public float xMi, xMa, zMi, zMa;
}
public class HoleController : MonoBehaviour {
    public Rigidbody rb;
    
    public Boundar boundar;
   
    void FixedUpdate()
    {
        rb.position = new Vector3(0, 0, 5);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundar.xMi, boundar.xMa),
            0.0f,
            Mathf.Clamp(rb.position.z, boundar.zMi, boundar.zMa)
        );

        
    }
}
