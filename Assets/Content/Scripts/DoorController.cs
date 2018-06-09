using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{

	public int Level;
	public GameObject Crystal;
	public GameObject Fruit;
	public GameObject Lock;
	public Sprite CrystalSprite;
	public Sprite FruitSprite;
	public Sprite LockSprite;

	public bool Locked
	{
		set
		{
			_locked = value;
			
		}
		get { return _locked; }
	}

	private bool _locked;
	
	// Use this for initialization
	void Start () {
		string str = PlayerPrefs.GetString ("stats"+Level, null);
		LevelStat stats = JsonUtility.FromJson<LevelStat>(str);
		if (stats == null)
		{
			_locked = Level!=1;
			if (!_locked)
			{
				Lock.GetComponent<SpriteRenderer>().sprite = null;
				return;
			}
			str = PlayerPrefs.GetString ("stats" + (Level-1), null);
			stats = JsonUtility.FromJson<LevelStat>(str);
			_locked = stats == null || !stats.LevelPassed;
			Lock.GetComponent<SpriteRenderer>().sprite = _locked ? LockSprite : null;
		}
		else
		{
			if (stats.HasCrystals)
				Crystal.GetComponent<SpriteRenderer>().sprite = CrystalSprite;
			if (stats.HasAllFruits)
				Fruit.GetComponent<SpriteRenderer>().sprite = FruitSprite;
			if (!stats.LevelPassed)
				Lock.GetComponent<SpriteRenderer>().sprite = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		PlayerController rabit = collider.GetComponent<PlayerController>(); 
		if(!_locked && rabit != null) 
		{
			SceneManager.LoadScene("Level"+Level);
		}
	}
}
