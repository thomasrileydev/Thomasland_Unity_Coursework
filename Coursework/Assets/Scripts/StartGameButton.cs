using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {
    public Button StartGame;
    public void Update()
    {
        StartGame.onClick.AddListener(Click);


    }
    private void RemoveAllListeners()
    {

        SceneManager.LoadScene("Final Game", LoadSceneMode.Single);

    }

    void Click()
    {

        RemoveAllListeners();

    }

}
