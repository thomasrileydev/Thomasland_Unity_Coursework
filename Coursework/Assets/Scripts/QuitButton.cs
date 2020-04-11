using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script quits the application and is called by the Quit button
 * in the Menu. */

public class QuitButton : MonoBehaviour {
    public Button Quit;

	void Update () {
        Quit.onClick.AddListener(Click);
    }
    void Click()
    {
        Application.Quit(); //The command quits the application
    }
}