using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D ship;

    private Vector2 fwdSpeed = new Vector2(0, 8);

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
            forward();
        }

    }

    private void forward()
    {
        Vector2 fwd = transform.up;
        ship.AddForce(fwd);
    }
}
