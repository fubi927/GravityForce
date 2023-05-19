using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D ship;
    public float fuel;

    private float angle;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody2D>();
        fuel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (fuel > 0)
            {
                Forward();
                fuel -= 0.01f;
            }
            if (fuel < 0)
            {
                fuel = 0;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            angle += Time.deltaTime * rotationSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle += -Time.deltaTime * rotationSpeed;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Forward()
    {
            Vector2 fwd = transform.up;
            ship.AddForce(fwd);
    }
}
