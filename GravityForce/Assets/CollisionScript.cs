using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public CollisionScript collision;
    // Start is called before the first frame update
    void Start()
    {
        collision = GameObject.FindGameObjectWithTag("collision").GetComponent<CollisionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Console.WriteLine("Collision detected");
    }
}
