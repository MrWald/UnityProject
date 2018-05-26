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
	public void onRabitDeath(PlayerController rabit) 
	{
//При смерті кролика повертаємо на початкову позицію
		rabit.transform.position = Current._startingPosition;
	}
	
	public void AddCoins(int number)
	{
		_points += number;
	}
}
