using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerScript : MonoBehaviour {
    public GameObject Menu;
    //public GameObject Options;
    public HealthScript HealthScript;
    private int RegenerationHealth=1;
    public int RegenTimer;
    private int counter = 0;
    public Text InfoText;
    public SaveTextfile SaveTextfile;
    public LoadTextfile LoadTextfile;
    public GameObject FPSCounter;

    public void Start()
    {
        Menu.SetActive(false);
        //Options.SetActive(false);
        Physics.IgnoreLayerCollision(4, 8);
        Physics.IgnoreLayerCollision(4, 12);
        Physics.IgnoreLayerCollision(4, 9);
        InfoText.text = "Esc or Menu for instructions and game menu";
        StartCoroutine(InfoBoxUpdate());
    }
    public void Update()
    {


        bool MenuActive = Input.GetButtonDown("Menu");

        if (MenuActive==true)
        {
            counter++;
            if (counter==1)
            {
                Menu.SetActive(true);
                if (Input.GetButtonDown("Debug"))
                {
                    FPSCounter.SetActive(true);
                }
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else if (counter == 2)
            {
                Menu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                SaveTextfile.Saved = false;
                LoadTextfile.Loaded = false;
                LoadTextfile.Reinstated = false;
                InfoText.text = "";
                counter = 0;
            }
            /*if (Options.activeSelf == true)
            {
                if (Menu == true)
                {
                    Options.SetActive(false);
                    Menu.SetActive(false);
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    counter = 0;
                }
            }*/

        }

    }
    public IEnumerator RegenHealth() //for wrench script called when spanners collected to regenerate health
    {
        if (HealthScript.Health < 100)
        {
            HealthScript.Health += RegenerationHealth;
            Debug.Log(HealthScript.Health);
            yield return new WaitForSeconds(RegenTimer);
            StartCoroutine(RegenHealth());
        }
        else
        {
            StopCoroutine("RegenHealth");
        }
    }
    public void InitializeRegen() 
    {
        StartCoroutine(RegenHealth());
    }

    public IEnumerator InfoBoxUpdate()
    {
        yield return new WaitForSeconds(5);
        InfoText.text = "";
        StartCoroutine(InfoBoxUpdate());
    }

}
