using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script controls the Save button in the menu which works when the button is clicked. 
 * It calls WriteString which is in SaveTextfile which saves the game. */

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
