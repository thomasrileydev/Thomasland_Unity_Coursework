using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveButton : MonoBehaviour {
    public Button button;
    public SaveTextfile SaveTextfile;

    public void Update()
    {



    }

    protected void ClearSelection()
    {
        SaveTextfile.WriteString();
        Debug.Log("saved");
    }





}
