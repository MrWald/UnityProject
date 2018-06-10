using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {

	void Start()
	{
		Audio = GetComponent<AudioSource>();
	}
	protected override void OnRabitHit (PlayerController rabit) {
		LevelController.Current.AddCoins (1);
		CollectedHide ();
	}
}
