using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerScriptwip : MonoBehaviour {
    public GameObject Menu;
    private int counter = 0;
    public Button Save;
    public Button Load;
    public Button Options;
    public Button Quit;

    public void Update()
    {
        bool MenuActive = Input.GetButtonDown("Menu");
        if (MenuActive==true)
        {
            counter++;
            if (counter==1)
            {
                Menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else if (counter == 2)
            {
                Menu.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                counter = 0;

                if (Input.GetKeyDown("Submit"))
                {
                    //if(Save.IsHighlighted)
                }
            }
        }
    }

}
