using UnityEngine;

public class Mushroom : Collectable
{
	internal static bool Consumed;
	
	protected override void OnRabitHit (PlayerController rabit) 
	{
		if (!Consumed)
		{
			Consumed = true;
			Vector3 currentSize = rabit.transform.localScale;
			rabit.transform.localScale = new Vector3(currentSize.x*2, currentSize.y*2, 0);
		}
		CollectedHide();
	}
}
