using UnityEngine;

public class Fruit : Collectable
{
	
	private int _id;

	void Start()
	{
		_id = ++LevelController.Current.FruitsAll;
		Audio = GetComponent<AudioSource>();
		if (!LevelController.Current.Stats.CollectedFruits.Contains(_id)) return;
		++LevelController.Current.FruitsTaken;
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a/2);
	}
	
	protected override void OnRabitHit(PlayerController rabit)
	{
		++LevelController.Current.FruitsTaken;
		if(!LevelController.Current.Stats.CollectedFruits.Contains(_id))
			LevelController.Current.Stats.CollectedFruits.Add(_id);
		CollectedHide ();
	}
}
