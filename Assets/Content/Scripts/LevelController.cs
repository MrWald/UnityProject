using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour 
{

	public static LevelController Current;
	public Text Points;
	public Image[] Lifes;
	public Sprite EmptyLife;
	private Vector3 _startingPosition;
	private int _points = 0;
	private int _health = 3;

	void Awake() 
	{ 
		Current = this;
	}
	
	public void SetStartPosition(Vector3 pos) 
	{ 
		_startingPosition = pos;
	}
	
	public void OnRabitDeath(PlayerController rabit) 
	{
		if(_health==0)
			SceneManager.LoadScene("Level Chooser");
		rabit.transform.position = _startingPosition;
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
}
