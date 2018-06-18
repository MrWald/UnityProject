using UnityEngine;

public class SoundManager
{
	public static SoundManager Instance = new SoundManager();
	
	private bool _isSoundOn;

	public bool IsSoundOn
	{
		set
		{
			_isSoundOn = value;
		}
		get { return _isSoundOn; }
	}

	private SoundManager()
	{
		_isSoundOn = PlayerPrefs.GetInt("sound", 1) == 1;
	}

}