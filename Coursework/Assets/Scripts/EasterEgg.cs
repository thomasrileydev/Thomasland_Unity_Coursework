using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EasterEgg : MonoBehaviour {
	public Button Save;
	public Button Load;
	public Button FirstPerson;
	public Button ThirdPerson;
	public Button Respawn;

	public void LoadScene()
	{
		SceneManager.LoadScene("Cube", LoadSceneMode.Single);

	}

	public void Activate()
	{
		Save.interactable = false;
		Load.interactable = false;
		FirstPerson.interactable = false;
		ThirdPerson.interactable = false;
		Respawn.interactable = false;
	}
	public void Update()
	{
		Scene current = SceneManager.GetActiveScene();
		if (current.name == "Cube")
		{
			Activate();
		}
	}
	
	
}
