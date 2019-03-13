using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Boundaryy
{
    public float Xmin, Xmax, Zmin, Zmax;
}

public class Controler : NetworkBehaviour {
    public Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundaryy boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    //AudioClip sound;
    void Update()
    {
        if (!isLocalPlayer)
            return;
      
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            CmdFire();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        


        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.Xmin, boundary.Xmax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.Zmin, boundary.Zmax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    [Command]
    void CmdFire()
    {
        nextFire = Time.time + fireRate;
        GameObject bullet =  (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        NetworkServer.Spawn(bullet);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
   

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
    