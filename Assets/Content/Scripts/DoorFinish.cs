using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorFinish : MonoBehaviour
{
	public GameObject WinPane;
	public Image[] Crystals;
	public Text Fruits;
	public Button RestartButton;
	public Button NextLevelButton;
	public AudioClip WinClip;

	void Start()
	{
		RestartButton.onClick.AddListener(RestartAction);
		NextLevelButton.onClick.AddListener(NextAction);
	}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		PlayerController rabit = collider.GetComponent<PlayerController>();
		if (rabit == null) return;
		LevelController.Current.Stats.LevelPassed = true;
		if(SoundManager.Instance.IsSoundOn)
			AudioSource.PlayClipAtPoint(WinClip, Camera.main.transform.position);
		WinPane.SetActive(true);
		Fruits.text = LevelController.Current.Fruits.text;
		for (int i=0;i<Crystals.Length;++i)
			Crystals[i].sprite = LevelController.Current.Crystals[i].sprite;
	}

	private void RestartAction()
	{
		SceneManager.LoadScene("Level"+LevelController.Current.Level);
	}
	
	private void NextAction()
	{
		SceneManager.LoadScene("Level Chooser");
	}
}
