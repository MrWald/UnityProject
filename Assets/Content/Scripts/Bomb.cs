using UnityEngine;

public class Bomb : Collectable
{
	public static bool Hit;

	void Start()
	{
		Audio = GetComponent<AudioSource>();
	}

	protected override void OnRabitHit (PlayerController rabit) 
	{
		if (Mushroom.Consumed)
		{
			Mushroom.Consumed = false;
			Hit = true;
			Vector3 currentSize = rabit.transform.localScale;
			rabit.transform.localScale = new Vector3(currentSize.x/2, currentSize.y/2, 0);
			rabit.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.5f);
		}
		else
		{
			if (Hit)
				return;
			rabit.GetComponent<Animator>().SetBool("death", true);
		}
		CollectedHide();
	}
}
