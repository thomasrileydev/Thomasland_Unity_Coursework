using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;//This allows to read the text file.


/*This script loads the textfiles and reinstates the variables and data. It is called by
 * Load. When a game is loaded, the two files are read by ReadString and turned into strings
 * and Reinstate then assigns the saved variables to their correct places.
 */

public class LoadTextfile : MonoBehaviour
{
    public Text InfoText;
    private string Save_Part_1 = "Save";
    public string Save_Part_2;
    private string Save_Whole;
    private int counter = 0;
    private int counter_one = 0;
    [HideInInspector] public float tempx,tempy,tempz,temprx,tempry,temprz;  
    public Transform[] allObjects;
    [HideInInspector] public string[] LoadedList = new string[21];
    [HideInInspector] public string[] LoadedVariableList = new string[10];
    [HideInInspector] public bool Loaded;
    [HideInInspector] public bool Reinstated;

    public HealthScript HealthScript;
    public DayNight DayNight;
    public CollectablesScript CollectablesScript;
    public POV POV;
    public RocketParts RocketParts;
   
        public void Start() //Flags set to allow a game to load
    {
        Loaded = false;
        Reinstated = false;
    }

    public IEnumerator ReadString()
    {
        if (Loaded == false) 
        {
            Save_Whole = Save_Part_1 + Save_Part_2;
            //Checks directory exists. If so it reads back the text file to a string
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
            else
            {
                //If there's no file to load it produces a message and throws an exception which gets logged
                InfoText.text = "No Saved Game Found";
                throw new FileNotFoundException();
            }
            counter = 0;

            //This section reads back the variables file and puts in a string
            string VariablePath = Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + "Variables.txt";
            StreamReader Variablereader = new StreamReader(VariablePath);

            while (counter < 10)
            {
                LoadedVariableList[counter] = Variablereader.ReadLine();

                counter += 1;
            }
            Variablereader.Close();
            counter = 0;
            Loaded = true; //Flag shows files loaded


            yield return (LoadedList);
            yield return (LoadedVariableList);
        }

    }
    public void Reinstate() //Follows ReadString. Reinstates the variables to their game objects
    {
        if (Reinstated == false) //Checks flag
        {
            //I initally used the following line but it was highly inefficient, going through
            //every object in the scene! I added a list of the game objects I needed to save and 
            //just saved and loaded those. 
            // UnityEngine.Object[] allObjects = FindObjectsOfType(typeof(Transform));
            foreach (Transform obj in allObjects) //for each game object in the list
            {
                //This section reinstates the position and roatation variables to each game object
                //for (counter_one = 0; counter_one < 21; counter_one++)
                for (counter_one = 0; counter_one <= 3; counter_one++)
                {
                    Debug.Log(counter_one);
                    if (obj.name == LoadedList[counter_one])
                    {

                        float tempx = float.Parse(LoadedList[counter_one + 1]);//parse takes one data type and attempts to convert it to another
                        float tempy = float.Parse(LoadedList[counter_one + 2]);//in this case from string to float
                        float tempz = float.Parse(LoadedList[counter_one + 3]);
                        float temprx = float.Parse(LoadedList[counter_one + 4]);
                        float tempry = float.Parse(LoadedList[counter_one + 5]);
                        float temprz = float.Parse(LoadedList[counter_one + 6]);
                        obj.position = new Vector3(tempx, tempy, tempz); //assigns position to game object
                        obj.rotation = Quaternion.Euler(temprx, tempry, temprz); //assigns rotation to each game object
                        //counter_one = counter_one + 7;




                    }
                }



            }
            //Reinstates the loaded variables for Health, Battery, Time of Day and Rocket parts,
            //and uses the Rocket Parts values to update the other variables affected by it
            //including the Rocket progress bar and Rocket collectables, rather than saving all
            //of these as seperate variables. This saves duplication and reduces the file size.

            HealthScript.Health = int.Parse(LoadedVariableList[0]);//uses Parse to change string to int
            HealthScript.Battery = int.Parse(LoadedVariableList[1]);
            DayNight.currentTimeOfDay = float.Parse(LoadedVariableList[2]);
            POV.ThirdP.enabled = bool.Parse(LoadedVariableList[3]);//uses Parse to change string to bool
            POV.FirstP.enabled = bool.Parse(LoadedVariableList[4]);

            CollectablesScript.AddOn.SetActive(bool.Parse(LoadedVariableList[5]));
            if (CollectablesScript.AddOn.activeSelf == true)
            {
                CollectablesScript.Collectable.SetActive(false);//this is minimap. Done to save on file size
            }

            /*The following section reinstates the Rocket progress by taking four values from the variables 
             * text file and updating the collectable crates, the value RocketProgress.value which updates the
             * rocket progress bar and the state of Rocket that is active. 
             */
            RocketParts.RocketPart1.SetActive(false); RocketParts.RocketPart2.SetActive(false); RocketParts.RocketPart3.SetActive(false); RocketParts.Rocket.SetActive(false);
            RocketParts.Collected1 = (bool.Parse(LoadedVariableList[6]));
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

            InfoText.text = "Game Loaded"; //Completion message to user
            Reinstated = true; //Sets flag to show reinstated
        }
    }

}