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
 