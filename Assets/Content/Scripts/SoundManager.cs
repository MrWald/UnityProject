using UnityEngine;

public class SoundManager
{
	public static readonly SoundManager Instance = new SoundManager();

	public bool IsSoundOn { set; get; }

	private SoundManager()
	{
		IsSoundOn = PlayerPrefs.GetInt("sound", 1) == 1;
	}

}