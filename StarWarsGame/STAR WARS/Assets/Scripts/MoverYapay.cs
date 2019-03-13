using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoverYapay : MonoBehaviour {

    public Rigidbody player;
    public Rigidbody enemy;
    Vector3 position;
    // Use this for initialization
    void Start()
    {
       // rb.velocity = transform.forward * speed;

    }
    // Update fonksiyonu oyun boyunca sürekli çağrılır (her frame'de)
    /*void Update()
    {
        position = new Vector3(player.position.x, enemy.position.y, enemy.position.z);
        enemy.MovePosition(position);
       
    }*/
}
