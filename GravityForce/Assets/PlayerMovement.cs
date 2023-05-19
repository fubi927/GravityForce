using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D ship;

    private Vector2 fwdSpeed = new Vector2(0, 8);
    private float angle;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Forward();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("collision"))
        {
            Debug.Log("Collision detected");
        }
    }

}
