using UnityEngine;

public class MusicManager : MonoBehaviour
{

	public bool MusicOn
	{
		set { _musicSource.mute = !value; }
		get { return !_musicSource.mute; }
	}
	
	public bool SoundOn
	{
		set { SoundManager.Instance.IsSoundOn = value; }
		get { return SoundManager.Instance.IsSoundOn; }
	}
	
	private AudioSource _musicSource;

	public static MusicManager Instance;

	// Use this for initialization
	void Awake ()
	{
		Instance = this;
		DontDestroyOnLoad (gameObject);
	}

	void Start()
	{
		_musicSource = GetComponent<AudioSource>();
		MusicOn = PlayerPrefs.GetInt("music", 1)==1;
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt("sound", SoundManager.Instance.IsSoundOn ? 1 : 0);
		PlayerPrefs.SetInt("music", MusicOn ? 1 : 0);
		PlayerPrefs.Save();
	}
}
