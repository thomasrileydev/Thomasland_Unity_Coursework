using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public void Start()
    {
        Health = MaxHealth;
        StartCoroutine(DepleteBattery());
    }
    public void Update()
    {
        if (Health <1)
        {
            DeathScript.PlayerDie();
        }
        HealthSlider.value = Health;
        BatterySlider.value = Battery;
        
        //FillImageHealth.color = Color.Lerp(DamageColour, FullHealthColour, Health / MaxHealth);
        //FillImageBattery.color = Color.Lerp(DamageColour, FullHealthColour, Battery / MaxBattery);

    }
        IEnumerator DepleteBattery()
    {
        yield return new WaitForSeconds(3);
        Battery = Battery - 1;
        StartCoroutine(DepleteBattery());

    }



}
