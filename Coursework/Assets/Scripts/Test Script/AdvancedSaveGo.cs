/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdvancedSaveGo : MonoBehaviour {
    public Button Save,Load,Exit;
    public Transform SaveObjectTransform;
    public int cSlot = 1;
    private void Update()
    {
        Save.onClick.AddListener(Click);

        
    }
    void Click()
    {
        {
            SaveObjectTransform.GetComponent<AdvancedSaveSystem_SaveGO>().SaveGameObjects(cSlot);

        }
    }
}
*/