/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SaveRoutine : MonoBehaviour {
    private int Counter = 0;
    private int Slot;
    private string SlotString;

	public void Save()
    {
        UnityEngine.Object[] allObjects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject obj in allObjects)
        {
            string toSave = "";
            toSave = obj.transform.position.x.ToString() + Environment.NewLine + obj.transform.position.y.ToString() + Environment.NewLine + obj.transform.position.z.ToString() + Environment.NewLine + obj.transform.rotation.x.ToString() + Environment.NewLine + obj.transform.rotation.y.ToString() + Environment.NewLine + obj.transform.rotation.z.ToString() + Environment.NewLine + obj.transform.rotation.w.ToString() + Environment.NewLine + obj.transform.localScale.x.ToString() + Environment.NewLine + obj.transform.localScale.y.ToString() + Environment.NewLine + obj.transform.localScale.z.ToString();
            if (Counter > 9)
            {
                Slot++;
            }
            SlotString = Slot.ToString();
            PlayerPrefs.SetString(SlotString,toSave);
            Counter++;
        }
        PlayerPrefs.Save();
    }
}*/
