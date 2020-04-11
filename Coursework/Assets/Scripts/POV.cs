using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*This script changes the point of view between
 * two cameras, one inside the Player and the other behind them.
 * It works when the buttons are pressed in the Menu.*/

public class POV : MonoBehaviour
{
    public Button FirstPerson;
    public Button ThirdPerson;
    public Camera FirstP;
    public Camera ThirdP;

    void Update()
    {
        FirstPerson.onClick.AddListener(First);
        ThirdPerson.onClick.AddListener(Third);

    }
    private void Third() //This selects the third person camera

    {
        ThirdP.enabled = true;
        FirstP.enabled = false;
    }
    private void First() //This selects the first person camera
    {
        FirstP.enabled = true;
        ThirdP.enabled = false;

    }
}
