using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

	public AudioClip ButtonClick;
	public bool Closing;
	
	public void PlayButtonClick()
	{
		if (Closing)
			Time.timeScale = 1;
		if (SoundManager.Instance.IsSoundOn)
			AudioSource.PlayClipAtPoint(ButtonClick, Camera.main.transform.position);
		if (!Closing)
			Time.timeScale = 0;
		PostClick();
	}

	protected virtual void PostClick()
	{
		
	}
}
