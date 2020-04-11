using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script controls the Respawn button on the menu. When the button is clicked 
 *PlayerDie in DeathScript is called which kills Player, followed by respawning. */

public class Respawn : MonoBehaviour {
    public DeathScript DeathScript;
    public Button RespawnButton;
    public GameObject Menu;
    public void Update()
    {
        RespawnButton.onClick.AddListener(Click);
        }
    void Click()
    {
        Menu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; //for Linux
        DeathScript.PlayerDie();

    }

}
