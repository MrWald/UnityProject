
public class Crystal : Collectable 
{

	protected override void OnRabitHit (PlayerController rabit) 
	{
		LevelController.Current.AddCoins (10);
		this.CollectedHide ();
	}
}
