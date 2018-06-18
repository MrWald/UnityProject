using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
