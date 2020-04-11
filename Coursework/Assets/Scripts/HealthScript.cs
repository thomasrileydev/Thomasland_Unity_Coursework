using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script controls the Player's health and battery level. It
 * updates the health and battery sliders every frame and 
 * depletes the battery. If health becomes zero it triggers PlayerDie
 * which is in DeathScript. This script is referenced by DeathByEnemy
 * to reduce Player's health when Enemy attacks. */

public class HealthScript : MonoBehaviour {
    public int MaxHealth = 100;
    public int MaxBattery = 200;
    [HideInInspector] public int Health;
    [HideInInspector] public int Battery=100;
    public Slider HealthSlider;
    public Slider BatterySlider;
    //public Image FillImageHealth;   These were for making health and battery bars which change colour and size but were not needed
    //public Image FillImageBattery;
    //public Color FullHealthColour;
    //public Color DamageColour;
    public DeathScript DeathScript;
    public void Start() //Sets Health to maximum at the start and begins the deplete battery routine
    {
        Health = MaxHealth;
        StartCoroutine(DepleteBattery());
    }
    public void Update()
    {
        if (Health <1) //This if statement makes Player die when Health is zero
        {
            DeathScript.PlayerDie();
        }
        //These two lines update the sliders in the HUD
        HealthSlider.value = Health;
        BatterySlider.value = Battery;
        
        //FillImageHealth.color = Color.Lerp(DamageColour, FullHealthColour, Health / MaxHealth);
        //FillImageBattery.color = Color.Lerp(DamageColour, FullHealthColour, Battery / MaxBattery);

    }
        IEnumerator DepleteBattery() //Slowly depletes Player's battery
    {
        yield return new WaitForSeconds(3);
        Battery = Battery - 1;
        StartCoroutine(DepleteBattery());

    }



}
