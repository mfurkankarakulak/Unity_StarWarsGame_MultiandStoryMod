using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstreoidControler : MonoBehaviour {

    public Rigidbody rb;
    public Boundar boundar;
    // Update is called once per frame
    void Update () {

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
