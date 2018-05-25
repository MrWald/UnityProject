using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public static LevelController current;
	private Vector3 startingPosition;
	
	void Awake() { 
		current = this;
	}
	
	public void setStartPosition(Vector3 pos) 
	{ 
		this.startingPosition = pos;
	}
	public void onRabitDeath(PlayerController rabit) 
	{
//При смерті кролика повертаємо на початкову позицію
		rabit.transform.position = this.startingPosition;
	}
}
