using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

	public AudioClip ButtonClick;
	
	public void PlayButtonClick()
	{
		if(SoundManager.Instance.IsSoundOn)
			AudioSource.PlayClipAtPoint(ButtonClick, Camera.main.transform.position);
		PostClick();
	}

	protected virtual void PostClick()
	{
		
	}
}
