using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadTextfile : MonoBehaviour
{
    private string Save_Part_1 = "Save";
    public int Save_Part_2;
    private string Save_Whole;
    private int counter = 0;
    private int counter_one = 0;
    public float tempx,tempy,tempz,temprx,tempry,temprz; //[HideInInspector] 
    public Transform[] allObjects;
    public string[] LoadedList = new string[21]; //[HideInInspector] 
    public string[] LoadedVariableList = new string[10]; //[HideInInspector] 

    public HealthScript HealthScript;
    public DayNight DayNight;
    public CollectablesScript CollectablesScript;
    public POV POV;
    public RocketParts RocketParts;
    // HEYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY Remember this! The file reads Player back TWICE for some reason. Reinstate is isolated so we can see the values loaded.
    // Plan: make it read back the values ONCE for player. Might be some weird thing we've done in Load or Loadtextfile. Then reinstate Reinstate when they load correctly.
    // fixed turns out that the load routine was highly ineficiant and was causing it to repeat
   
    public IEnumerator ReadString()
    {
        
        Save_Whole = Save_Part_1 + Save_Part_2;
        if (Directory.Exists(Application.persistentDataPath + "\\" + "ThomasLand"))
        {
            string path = Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + ".txt";
            StreamReader reader = new StreamReader(path);
            
                while (counter < 21)
                {

                LoadedList[counter] = reader.ReadLine();
                //Debug.Log(counter);
                counter += 1;
                }
                //string LoadedData= reader.ReadToEnd();
                reader.Close(); 
            

        }
        counter = 0;

        //load variables goes here
        string VariablePath = Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + "Variables.txt";
        StreamReader Variablereader = new StreamReader(VariablePath);

        while (counter < 10)
        {
            LoadedVariableList[counter] = Variablereader.ReadLine();

            counter += 1;
        }
        Variablereader.Close();
        counter = 0;
       
       
        yield return (LoadedList);
        yield return (LoadedVariableList);

    }
    public void Reinstate()
    {
       
        // UnityEngine.Object[] allObjects = FindObjectsOfType(typeof(Transform));
        foreach (Transform obj in allObjects)
        {
            //for (counter_one = 0; counter_one < 21; counter_one++)
            for (counter_one=0; counter_one<=3; counter_one++)
            {
                Debug.Log(counter_one);
                if (obj.name == LoadedList[counter_one])
               {

                    float tempx = float.Parse(LoadedList[counter_one + 1]);
                    float tempy = float.Parse(LoadedList[counter_one + 2]);
                    float tempz = float.Parse(LoadedList[counter_one + 3]);
                    float temprx = float.Parse(LoadedList[counter_one + 4]);
                    float tempry = float.Parse(LoadedList[counter_one + 5]);
                    float temprz = float.Parse(LoadedList[counter_one + 6]);
                    obj.position = new Vector3(tempx, tempy, tempz);
                    obj.rotation = Quaternion.Euler(temprx, tempry, temprz);
                    //counter_one = counter_one + 7;




                }
            }



        }
        //reinstate variables goes here

        HealthScript.Health = int.Parse(LoadedVariableList[0]);
        HealthScript.Battery = int.Parse(LoadedVariableList[1]);
        DayNight.currentTimeOfDay = float.Parse(LoadedVariableList[2]);
        POV.ThirdP.enabled = bool.Parse(LoadedVariableList[3]);
        POV.FirstP.enabled = bool.Parse(LoadedVariableList[4]);
        
        CollectablesScript.AddOn.SetActive( bool.Parse(LoadedVariableList[5]));
        if (CollectablesScript.AddOn.activeSelf == true)
        {
            CollectablesScript.Collectable.SetActive(false);
        }

        RocketParts.RocketPart1.SetActive (false); RocketParts.RocketPart2.SetActive(false); RocketParts.RocketPart3.SetActive(false); RocketParts.Rocket.SetActive(false);
        RocketParts.Collected1=(bool.Parse(LoadedVariableList[6]));
        if (RocketParts.Collected1 == true)
        {
            RocketParts.Crate1.SetActive(false);
            RocketParts.RocketPart1.SetActive(true);
            RocketParts.RocketProgress.value = 1;
        }

        RocketParts.Collected2 = (bool.Parse(LoadedVariableList[7]));
        if (RocketParts.Collected2 == true)
        {
            RocketParts.Crate2.SetActive(false);
            RocketParts.RocketPart1.SetActive(false);
            RocketParts.RocketPart2.SetActive(true);
            RocketParts.RocketProgress.value = 2;
        }

        RocketParts.Collected3 = (bool.Parse(LoadedVariableList[8]));
        if (RocketParts.Collected3 == true)
        {
            RocketParts.Crate3.SetActive(false);
            RocketParts.RocketPart2.SetActive(false);
            RocketParts.RocketPart3.SetActive(true);
            RocketParts.RocketProgress.value = 3;
        }

        RocketParts.Collected4 = (bool.Parse(LoadedVariableList[9]));
        if (RocketParts.Collected4 == true)
        {
            RocketParts.Crate4.SetActive(false);
            RocketParts.RocketPart3.SetActive(false);
            RocketParts.Rocket.SetActive(true);
            RocketParts.RocketProgress.value = 4;
        }


    }
    /*
        Save_Whole = Save_Part_1 + Save_Part_2;

        foreach (GameObject obj in allObjects)
        {
            string path = Save_Location + "\\" + "ThomasLand" + "/" + Save_Whole + ".txt";
            StreamWriter writer = new StreamWriter(path, true);

            writer.Close();
        }
    */
}