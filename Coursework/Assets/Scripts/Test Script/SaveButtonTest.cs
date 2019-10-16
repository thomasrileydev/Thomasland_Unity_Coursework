using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveButtonTest : MonoBehaviour {
    public Button button;
    public SaveTextfile SaveTextfile;
   
    public void Update()
    {
        button.onClick.AddListener(Reset);
            
        

    }
    
   public void Reset()
    {
        SaveTextfile.WriteString();
        Debug.Log("saved");
    }
   
   
    


}
