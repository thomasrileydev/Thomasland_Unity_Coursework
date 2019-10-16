using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitButton : MonoBehaviour {
    public Button Quit;

	void Update () {
        Quit.onClick.AddListener(Click);
    }
    void Click()
    {
        Application.Quit();
    }
}