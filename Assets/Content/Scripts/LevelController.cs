using UnityEngine;

public class LevelController : MonoBehaviour 
{

	public static LevelController Current;
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
	}
}
