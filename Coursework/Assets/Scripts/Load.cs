using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*This script manages the 'Load' button and calls the routines ReadString and
 * Reinstate in the LoadTextfile script when the button is pressed. */

public class Load : MonoBehaviour {
    public Button LoadButton;
    public LoadTextfile LoadTextfile;



    public void Update()
    {
       
        LoadButton.onClick.AddListener(Click);
    }

    private void RemoveAllListeners()
    {
        //Wait();  
        //SceneManager.LoadScene("Final Game", LoadSceneMode.Single);
        StartCoroutine(LoadTextfile.ReadString());
        LoadTextfile.Reinstate();

        //LoadTextfile.Reinstate(); Hashed out so it can only now be called once per load from Loadtextfile
    }

    void Click()
    {
        
        RemoveAllListeners();

    }
   /* void Wait()
    {
       //SceneManager.UnloadSceneAsync("Final Game");
        SceneManager.LoadScene("Final Game", LoadSceneMode.Single);
    }
    */

}
 