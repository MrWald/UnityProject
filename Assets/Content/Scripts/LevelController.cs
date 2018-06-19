using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour 
{

	public static LevelController Current;
	public Text Points;
	public Image[] Lifes;
	public Sprite EmptyLife;
	public Text Fruits;
	public int Level;
	public Image[] Crystals;
	public Image[] CrystalsLost;
	public GameObject LosePane;
	public AudioClip LoseClip;
	public Button RestartButton;
	public Button MenuButton;
	public Button[] CloseButtons;

	public int FruitsTaken
	{
		set
		{
			if (value > _fruitsAll)
				return;
			_fruitsTaken = value;
			Fruits.text = FruitsTaken + "/" + _fruitsAll;
			if(_fruitsTaken == FruitsAll)
				Stats.HasAllFruits = true;
		}
		get { return _fruitsTaken; }
	}

	public int FruitsAll
	{
		set
		{
			_fruitsAll = value;
			if(Fruits!=null)
				Fruits.text = FruitsTaken + "/" + _fruitsAll;
			if(_fruitsTaken != FruitsAll)
				Stats.HasAllFruits = false;
		}
		get { return _fruitsAll; }
	}

	public int CrystalsTaken
	{
		set
		{
			_crystals = value;
			if(_crystals==3)
				Stats.HasCrystals = true;
		}
		get { return _crystals; }
	}

	public LevelStat Stats;
	private Vector3 _startingPosition;
	private int _points;
	private int _crystals;
	private int _fruitsTaken;
	private int _fruitsAll;
	private int _health = 3;
	
	void Awake() 
	{ 
		Current = this;
		string str = PlayerPrefs.GetString ("stats"+Level, null); 
		Stats = JsonUtility.FromJson<LevelStat> (str) ?? new LevelStat ();
	}

	void Start()
	{
		AddCoins(PlayerPrefs.GetInt ("coins", 0));
		if(MenuButton!=null)
			MenuButton.onClick.AddListener(MenuAction);
		if(RestartButton!=null)
			RestartButton.onClick.AddListener(RestartAction);
		foreach (Button closeButton in CloseButtons)
			closeButton.onClick.AddListener(MenuAction);
	}

	private void OnDestroy()
	{
		PlayerPrefs.SetInt ("coins", _points);
		string str = JsonUtility.ToJson(Stats); 
		PlayerPrefs.SetString ("stats"+Level, str);
		PlayerPrefs.Save ();
	}

	public void SetStartPosition(Vector3 pos) 
	{ 
		_startingPosition = pos;
	}
	
	public void OnRabitDeath(PlayerController rabit)
	{
		rabit.AudioSource.clip = rabit.DeathAudio;
		if(SoundManager.Instance.IsSoundOn)
			rabit.AudioSource.Play();
		if (_health == 1)
		{
			if(SoundManager.Instance.IsSoundOn)
				AudioSource.PlayClipAtPoint(LoseClip, Camera.main.transform.position);
			Time.timeScale = 0;
			for (int i = 0; i < Crystals.Length; ++i)
				CrystalsLost[i].sprite = Crystals[i].sprite;
			LosePane.SetActive(true);
		}

		rabit.transform.position = _startingPosition;
		if (Lifes.Length == 0)
			return;
		Lifes[--_health].GetComponent<Image>().sprite = EmptyLife;
	}
	
	public void AddCoins(int number)
	{
		_points += number;
		Points.text = _points.ToString().PadLeft(4, '0');
	}
	
	public static void SetNewParent(Transform obj, Transform newParent) 
	{
		if (obj.transform.parent == newParent) return;
		Vector3 pos = obj.transform.position;
		obj.transform.parent = newParent;
		obj.transform.position = pos;
	}

	private void RestartAction()
	{
		SceneManager.LoadScene("Level" + Level);
		Time.timeScale = 1;
	}
	
	private void MenuAction()
	{
		SceneManager.LoadScene("Level Chooser");
		Time.timeScale = 1;
	}
}
