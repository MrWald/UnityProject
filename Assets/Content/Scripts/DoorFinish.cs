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
	public Button[] CloseButtons;

	void Start()
	{
		RestartButton.onClick.AddListener(RestartAction);
		NextLevelButton.onClick.AddListener(NextAction);
		foreach (Button closeButton in CloseButtons)
			closeButton.onClick.AddListener(NextAction);
	}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		PlayerController rabit = collider.GetComponent<PlayerController>();
		if (rabit == null) return;
		LevelController.Current.Stats.LevelPassed = true;
		if(SoundManager.Instance.IsSoundOn)
			AudioSource.PlayClipAtPoint(WinClip, Camera.main.transform.position);
		Time.timeScale = 0;
		WinPane.SetActive(true);
		Fruits.text = LevelController.Current.Fruits.text;
		LevelController.Current.AddCoins(10);
		for (int i=0;i<Crystals.Length;++i)
			Crystals[i].sprite = LevelController.Current.Crystals[i].sprite;
	}

	private void RestartAction()
	{
		SceneManager.LoadScene("Level"+LevelController.Current.Level);
		Time.timeScale = 1;
	}
	
	private void NextAction()
	{
		SceneManager.LoadScene("Level Chooser");
		Time.timeScale = 1;
	}
}
