using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByYapay : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;


    public int scoreValue;
    private YapayContoller yapayController;
    

    void Start()
    {
        GameObject yapayControllerObject = GameObject.FindWithTag("YapayContoller");
        if (yapayControllerObject != null)
        {
            yapayController = yapayControllerObject.GetComponent<YapayContoller>();
        }
        if (yapayController == null)
        {
            Debug.Log("Cannot find 'YapayContoller' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.CompareTag("Enemy"))
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            yapayController.GameOver();
        }
        yapayController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
