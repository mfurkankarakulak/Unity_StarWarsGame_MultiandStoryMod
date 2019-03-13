using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class Boundaryyy
{
    public float xMinn, xMaxx, zMinn, zMaxx;
}

public class MultiSavasController : NetworkBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundaryyy boundaryyy;

    public GameObject shot;
    public Transform shotSpawn;
   // public float fireRate ;
    public const double fireRate = 0.5 ;
    private float nextFire;
   

  
    void Update()
    {
        if (!isLocalPlayer)
            return;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            CmdFire();
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

       

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundaryyy.xMinn, boundaryyy.xMaxx),
            0.0f,
            Mathf.Clamp(rb.position.z, boundaryyy.zMinn, boundaryyy.zMaxx)
        );

    


    }

    [Command]
    void CmdFire()
    {
        nextFire = Time.time + (float)fireRate;
        GameObject bullet = (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
       
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 3);
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
    void FixedUpdate()
    {

    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
