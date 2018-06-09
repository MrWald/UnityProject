
public class Fruit : Collectable
{
	
	private int _id;

	void Start()
	{
		_id = ++LevelController.Current.FruitsAll;
		if (!LevelController.Current.Stats.CollectedFruits.Contains(_id)) return;
		++LevelController.Current.FruitsTaken;
		CollectedHide();
	}
	
	protected override void OnRabitHit(PlayerController rabit)
	{
		++LevelController.Current.FruitsTaken;
		LevelController.Current.Stats.CollectedFruits.Add(_id);
		CollectedHide ();
	}
}
