using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class SaveTextfile : MonoBehaviour
{
    private string Save_Part_1 = "Save";
    public int Save_Part_2;
    private string Save_Whole;
    public GameObject [] allObjects;

    public HealthScript HealthScript;
    public DayNight DayNight;
    public CollectablesScript CollectablesScript;
    public POV POV;
    public RocketParts RocketParts;

    public void WriteString()
    {
        if (Directory.Exists(Application.persistentDataPath + "\\"+"ThomasLand"))
        {
            Directory.Delete(Application.persistentDataPath + "\\"+"ThomasLand", true);
            Directory.CreateDirectory(Application.persistentDataPath + "\\"+"ThomasLand");

        }
        else
        {
            Directory.CreateDirectory(Application.persistentDataPath + "\\"+"ThomasLand");
        }
        Save_Whole = Save_Part_1 + Save_Part_2;
        File.WriteAllText(Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + ".txt", "");
        string toSave = "";
        string VariablesToSave = "";
        foreach (GameObject obj in allObjects)
        {
            toSave = obj.name + Environment.NewLine + obj.transform.position.x.ToString() + Environment.NewLine + obj.transform.position.y.ToString() + Environment.NewLine + obj.transform.position.z.ToString() + Environment.NewLine + obj.transform.eulerAngles.x.ToString() + Environment.NewLine + obj.transform.eulerAngles.y.ToString() + Environment.NewLine + obj.transform.eulerAngles.z.ToString();
            VariablesToSave = HealthScript.Health.ToString() + Environment.NewLine + HealthScript.Battery.ToString() + Environment.NewLine + DayNight.currentTimeOfDay.ToString() + Environment.NewLine + POV.ThirdP.enabled.ToString() + Environment.NewLine + POV.FirstP.enabled.ToString() + Environment.NewLine + CollectablesScript.AddOn.activeSelf.ToString() + Environment.NewLine + RocketParts.Collected1.ToString() + Environment.NewLine + RocketParts.Collected2.ToString() + Environment.NewLine + RocketParts.Collected3.ToString() + Environment.NewLine + RocketParts.Collected4.ToString();
            string path = Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + ".txt";
            StreamWriter writer = new StreamWriter(path, true);
            
             writer.WriteLine(toSave);
             
             writer.Close();
            
        }
        string VariablePath = Application.persistentDataPath + "\\" + "ThomasLand" + "/" + Save_Whole + "Variables.txt";
        StreamWriter Variablewriter = new StreamWriter(VariablePath, true);
        Variablewriter.WriteLine(VariablesToSave);
        Variablewriter.Close();
    }
}
