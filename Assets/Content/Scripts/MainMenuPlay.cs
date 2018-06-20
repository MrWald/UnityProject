using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlay : ButtonController {

	protected override void PostClick()
	{
		StartCoroutine(StartGame());
	}

	private IEnumerator StartGame()
	{
		yield return new WaitForSeconds (ButtonClick.length); 
		SceneManager.LoadScene("Level Chooser");
	}
}
