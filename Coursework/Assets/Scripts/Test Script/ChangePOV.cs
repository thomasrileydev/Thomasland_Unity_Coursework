using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangePOV : MonoBehaviour {

    public Camera FirstP;
    public Camera ThirdP;
    public Button POV;
    private int counter = 0;


    public void Update()
    {
        POV.onClick.AddListener(Click);
    }
    private void RemoveAllListeners()

    {
       
        if (counter == 0)
        {
            Debug.Log(counter);
            ThirdP.enabled = true;
            FirstP.enabled = false;
            counter++;

        }
        else
        
        {
            Debug.Log(counter);
            FirstP.enabled = true;
            ThirdP.enabled = false;
            counter=0;
        }
    }
    void Click()
    {

        RemoveAllListeners();

    }
   

}
