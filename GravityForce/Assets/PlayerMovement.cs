using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D ship;
    public float fuel = 100;
    public int fuelFactor;
    public Text fuelText;
    public float rotationSpeed;
    public AudioSource audioThrust;

    private float angle;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody2D>();
        audioThrust.volume = 0;
        audioThrust.loop = true;
        audioThrust.Play();
    }
    int frames = 10;
    // Update is called once per frame
    void Update()
    {
        if (frames <= 0)
        { 
            UpdateFuelText();
            frames = 10;
        }else
        {
            frames--;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (fuel > 0)
            {
                Forward();
            }
            else if (fuel < 0)
            {
                fuel = 0;
                audioThrust.volume = 0;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            audioThrust.volume = 0;
        }
        
        if (Input.GetKey(KeyCode.A) && (ship.velocity != Vector2.zero))
        {
            angle += Time.deltaTime * rotationSpeed;
        }
        if (Input.GetKey(KeyCode.D) && (ship.velocity != Vector2.zero))
        {
            angle += -Time.deltaTime * rotationSpeed;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Forward()
    {
        Vector2 fwd = transform.up;
        ship.AddForce(fwd);
        fuel -= Time.deltaTime * fuelFactor;
        audioThrust.volume = 1;
    }

    private void UpdateFuelText()
    {
        fuelText.text = "Fuel: " + (int)fuel;
    }
}
