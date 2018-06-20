using UnityEngine;

public class Life : Collectable
{
	
	void Start()
	{
		Audio = GetComponent<AudioSource>();
	}
	
	protected override void OnRabitHit(PlayerController rabit)
	{
		int health = LevelController.Current.Health;
		if (health < 3)
		{
			++LevelController.Current.Health;
			LevelController.Current.Lifes[health].sprite = LevelController.Current.Lifes[health - 1].sprite;
		}
		CollectedHide ();
	}
}
