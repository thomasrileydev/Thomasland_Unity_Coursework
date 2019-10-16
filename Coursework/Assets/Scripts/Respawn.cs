using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        DeathScript.PlayerDie();

    }

}
