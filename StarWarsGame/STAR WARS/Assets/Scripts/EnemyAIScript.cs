using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour {

    public Transform player;
    public float playerDistance;
    Vector3 position;
    public Transform bullet;
    

    public int scoreValue;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerDistance = Vector3.Distance(player.position, transform.position);
        if ((bullet.position.x) == transform.position.x )
        {
            position = new Vector3(player.position.x+1, 0, 13);
            transform.position = position;
        }
        if (playerDistance < 10.0)
        {
            position = new Vector3(player.position.x + 2, 0, player.position.z + 3);
            transform.position = position;

        }

        if (player.position.x != transform.position.x)
        {
            position = new Vector3(player.position.x,0,13);
            transform.position = position;

            
        }
	}
  
}
