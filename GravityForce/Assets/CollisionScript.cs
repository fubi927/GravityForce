using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public PlayerMovement playermovement;

    // Start is called before the first frame update
    void Start()
    {
        playermovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("collision"))
        {
            Debug.Log("Typ: " + collision.otherCollider.GetType().ToString());
            if (collision.otherCollider.GetType().ToString() == "UnityEngine.BoxCollider2D")
            {
                Debug.Log("normale Landung");
            }
            else
            {
                Debug.Log("Kaputt");
            }
        }
        if (collision.gameObject.CompareTag("item"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Item collected");
        }
        if (collision.gameObject.CompareTag("fuel"))
        {
            if (playermovement.fuel < 50)
            {
                playermovement.fuel += 50;
            }
            else
            {
                playermovement.fuel = 100;
            }
            
            Debug.Log("Fuel collected");
            Destroy(collision.gameObject);
        }
        // WaitForEndOfFrame notwendig, da das Objekt erst beim nächsten Frame destroyed wird und das Objekt somit mehrfach eingesammelt werden kann
        new WaitForEndOfFrame();
    }
}
