using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionButton : MonoBehaviour {
    public Button Options;
    public GameObject OptionsMenu;
    public GameObject Menu;
        

    void Update()
    {
        Options.onClick.AddListener(Click);
    }
    void Click()
    {
        OptionsMenu.SetActive(true);
        Menu.SetActive(false);
    }


    }
