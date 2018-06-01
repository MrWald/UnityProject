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
	
	public static void SetNewParent(Transform obj, Transform newParent) 
	{
		if (obj.transform.parent == newParent) return;
		Vector3 pos = obj.transform.position;
		obj.transform.parent = newParent;
		obj.transform.position = pos;
	}
}
