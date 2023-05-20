using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFuelDisplay : MonoBehaviour
{
    public Text fuelText;
    public PlayerMovement playermovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fuelText.text = "Fuel: " + (int)playermovement.fuel;
    }
}
