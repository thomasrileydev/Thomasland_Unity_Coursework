using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*ControllerScript primarily manages the menu system. It calls the menu when the menu button
 * is pressed and at the same time pauses the game and brings back the cursor. It does the reverse when the menu is closed.
 * It also handles extra features including the FPS counter, health regeneration when spanners are collected,
 * resetting the information box and displaying the initial start message*/

public class ControllerScript : MonoBehaviour {
    public GameObject Menu; //The menu canvas
    //public GameObject Options;
    public HealthScript HealthScript;
    private int RegenerationHealth=1; //These two lines affect the rate of health regeneration
    public int RegenTimer;
    private int counter = 0;
    public Text InfoText; //This is the text box text which displays messages to the user
    public SaveTextfile SaveTextfile; 
    public LoadTextfile LoadTextfile;
    public EasterEgg EasterEgg;
    public GameObject FPSCounter;

    public void Start() //On game start, sets menu to false, ignore layer collisions, sets info text to start message
        //then starts the coroutine infobox update which clears it every 5 seconds which recurs during game play
    {
        Menu.SetActive(false);
        //Options.SetActive(false);
        Physics.IgnoreLayerCollision(4, 8); //Ignores collisions beteen water and Plyer so player can pass through
        Physics.IgnoreLayerCollision(4, 12); //As above but for "objects" layer which is Boulder
        Physics.IgnoreLayerCollision(4, 9); //As above, for collectables which is RocketParts and any other collectables
        InfoText.text = "Esc or Menu for instructions and game menu";
        StartCoroutine(InfoBoxUpdate());
    }
    public void Update()
    {


        bool MenuActive = Input.GetButtonDown("Menu");
        //Counter deals with the Menu button being pressed one to call menu then again to close it
        if (MenuActive==true)
        {
            counter++;
            if (counter==1) //Menu called, cursor unlocked and visible
            {
                Menu.SetActive(true);
                if (Input.GetButtonDown("Debug")) //Calls FPS counter if "F" key also pressed
                {
                    FPSCounter.SetActive(true);
                }
                else if (Input.GetButtonDown("EasterEgg")) 
                {
                    EasterEgg.LoadScene();
                }
                Cursor.visible = true; //This is for Linux as the next line doesn't work on Linux
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0; //Pauses time
            }
            else if (counter == 2) //Menu closed, cursor locked and hidden
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
    public void InitializeRegen() //starts the coroutine that replenishes player health
    {
        StartCoroutine(RegenHealth());
    }

    public IEnumerator InfoBoxUpdate() //Clears the text in infobox every 5 seconds
    {
        yield return new WaitForSeconds(5);
        InfoText.text = "";
        StartCoroutine(InfoBoxUpdate());
    }

}
