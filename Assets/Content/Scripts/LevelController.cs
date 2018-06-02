using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour 
{

	public static LevelController Current;
	public Text Text;
	private Vector3 _startingPosition;
	private int _points = 0;

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
		rabit.transform.position = _startingPosition;
	}
	
	public void AddCoins(int number)
	{
		_points += number;
		Text.text = _points.ToString();
	}
	
	public static void SetNewParent(Transform obj, Transform newParent) 
	{
		if (obj.transform.parent == newParent) return;
		Vector3 pos = obj.transform.position;
		obj.transform.parent = newParent;
		obj.transform.position = pos;
	}
}
