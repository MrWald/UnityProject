using UnityEngine;

public class Bomb : Collectable 
{

	protected override void OnRabitHit (PlayerController rabit) 
	{
		if (Mushroom.Consumed)
		{
			Mushroom.Consumed = false;
			Vector3 currentSize = rabit.transform.localScale;
			rabit.transform.localScale = new Vector3(currentSize.x/2, currentSize.y/2, 0);
		}
		else
		{
			rabit.GetComponent<Animator>().SetBool("death", true);
		}
		CollectedHide();
	}
}
