using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
 