using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour {
    public Button SaveButton;
    public SaveTextfile SaveTextfile;
    public void Update()
    {
        SaveButton.onClick.AddListener(Click);


    }
    private void RemoveAllListeners()
    {
        
            SaveTextfile.WriteString();
            
    }

    void Click()
    {
       
        RemoveAllListeners();

    }

}
