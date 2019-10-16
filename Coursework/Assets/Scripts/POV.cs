using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private void Third()

    {
        ThirdP.enabled = true;
        FirstP.enabled = false;
    }
    private void First()
    {
        FirstP.enabled = true;
        ThirdP.enabled = false;

    }
}
