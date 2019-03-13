using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar ( hook = "OnChangeHealth")]public int currentHealth = maxHealth;
    public RectTransform healthbar;
    public GameObject playerExplosion;

    
    public void TakeDamage(int amount, Collider other)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            RpcRespawn();

            
        }


    }
    
    void OnChangeHealth(int health)
    {
        healthbar.sizeDelta = new Vector2(health * 2, healthbar.sizeDelta.y);

    }
    [Client]
    void RpcRespawn()
    {
        if (isLocalPlayer)
            transform.position = Vector3.zero;

    }
    
   

   
}