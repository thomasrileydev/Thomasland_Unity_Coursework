using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

/*This script is called from Save and it deals with saving the game.First it checks for
 * an existing saved game directory and deletes if it found. It then creates a new directory
 * for the two save files.
 * It then collects the various data items to be saved and puts them in two strings to become files.
 * The first file is called Save.txt and contains the name, position
 * and rotation for the three saveable game objects: Player, Boulder and Enemy.
 * The second file is called SaveVariables.txt and this contains Player Health, Battery level, 
 * time of day, camera view plus MiniMap and Rocket collectables.
 * After writing the files, a boolean flag becomes true so it cannot rewrite the file over and 
 * over again. A message is then displayed telling the user the save was successful.
 */

public class SaveTextfile : MonoBehaviour
{
    private string Save_Part_1 = "Save";
    public string Save_Part_2;
    private string Save_Whole;
    public GameObject [] allObjects;
    //public InputField SaveInputField;//These two lines were to allow multiple saves but never used
    //public GameObject SaveInput; //however and not taken any further
    public Text InfoText;
    [HideInInspector] public bool Saved;

    public HealthScript HealthScript;
    public DayNight DayNight;
    public CollectablesScript CollectablesScript;
    public POV POV;
    public RocketParts RocketParts;
    public void Start()
    {
        Saved = false;
    }
    public void WriteString()
    {
        if (Saved == false) 
        {
            if (Directory.Exists(Application.persistentDataPath + "\\" + "ThomasLand"))
            {
                Directory.Delete(Application.persistentDataPath + "\\" + "ThomasLand", true);
                Directory.CreateDirectory(Application.persistentDataPath + "\\" + "ThomasLand");
            } //Deletes the save directory if found and creates a new one
            else
            {
                Directory.CreateDirectory(Application.persistentDataPath + "\\" + "ThomasLand");
            } //Creates a new directory if it didn't find an existing one

            Save_Whole = Save_Part_1 + Save_Part_2; //This is the filename, concatenated.
            //Part 1 is "Save", part2 can be changed in the inspector

            File.WriteAllText(Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + ".txt", "");
            string toSave = ""; //instantiating the variables
            string VariablesToSave = "";

            /*This next part gets the data being saved for each game object in the list and
             * concatenates them into a string with every item on a new line.
             *It also puts the variables to save in a string with every item on a new line.*/

            foreach (GameObject obj in allObjects)
            {
                toSave = obj.name + Environment.NewLine + obj.transform.position.x.ToString() + Environment.NewLine + obj.transform.position.y.ToString() + Environment.NewLine + obj.transform.position.z.ToString() + Environment.NewLine + obj.transform.eulerAngles.x.ToString() + Environment.NewLine + obj.transform.eulerAngles.y.ToString() + Environment.NewLine + obj.transform.eulerAngles.z.ToString();
                
                string path = Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + ".txt";
                StreamWriter writer = new StreamWriter(path, true);

                writer.WriteLine(toSave); 

                writer.Close();

            }
            //This part saves the variables to file
            VariablesToSave = HealthScript.Health.ToString() + Environment.NewLine + HealthScript.Battery.ToString() + Environment.NewLine + DayNight.currentTimeOfDay.ToString() + Environment.NewLine + POV.ThirdP.enabled.ToString() + Environment.NewLine + POV.FirstP.enabled.ToString() + Environment.NewLine + CollectablesScript.AddOn.activeSelf.ToString() + Environment.NewLine + RocketParts.Collected1.ToString() + Environment.NewLine + RocketParts.Collected2.ToString() + Environment.NewLine + RocketParts.Collected3.ToString() + Environment.NewLine + RocketParts.Collected4.ToString();
            string VariablePath = Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + "Variables.txt";
            StreamWriter Variablewriter = new StreamWriter(VariablePath, true);
            Variablewriter.WriteLine(VariablesToSave);
            Variablewriter.Close();
            Saved = true; //This is the flag
            InfoText.text = "Game Saved"; //Successful save message
        }
    }
    //public void input() // This would enable personalised filenames but time constraints
    //mean I can't implement it or the associated load functions at this time
    //{
    //    SaveInput.SetActive(true);
    //    Save_Part_2 = SaveInputField.text;
    //    SaveInput.SetActive(false);
    //    WriteString();

    //}
    /* //An incomplete early version, early development of the method
    Save_Whole = Save_Part_1 + Save_Part_2;

    foreach (GameObject obj in allObjects)
    {
        string path = Save_Location + "\\" + "ThomasLand" + "/" + Save_Whole + ".txt";
        StreamWriter writer = new StreamWriter(path, true);

        writer.Close();
    }
*/
}


