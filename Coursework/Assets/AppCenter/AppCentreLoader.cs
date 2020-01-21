using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppCentreLoader : MonoBehaviour {
    public GameObject AppCentre;

	void Start ()
    {
        Instantiate(AppCentre);	
	}
	
	
}
