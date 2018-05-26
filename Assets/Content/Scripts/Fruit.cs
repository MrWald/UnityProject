
public class Fruit : Collectable 
{

	protected override void OnRabitHit (PlayerController rabit) 
	{
		LevelController.Current.AddCoins (5);
		this.CollectedHide ();
	}
}
