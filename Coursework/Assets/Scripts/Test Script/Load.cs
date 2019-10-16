using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Load : MonoBehaviour {
    public Button LoadButton;
    public LoadTextfile LoadTextfile;



    public void Update()
    {
       
        LoadButton.onClick.AddListener(Click);
    }

    private void RemoveAllListeners()
    {
        
        StartCoroutine(LoadTextfile.ReadString());
        LoadTextfile.Reinstate();
    }

    void Click()
    {
        
        RemoveAllListeners();

    }

}
 