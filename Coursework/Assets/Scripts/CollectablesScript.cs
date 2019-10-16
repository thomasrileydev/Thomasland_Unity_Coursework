using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour {

    public string Tag="Player";
    public GameObject Collectable;
    public GameObject AddOn;

    void Start()
    {
        AddOn.SetActive(false);
    }

void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tag))
        {
            Collectable.SetActive (false);
            AddOn.SetActive(true);

        }
    }
}
