
using UnityEngine;
using UnityEngine.UI;

public class Crystal : Collectable
{

	public Image CrystalImage;
	
	protected override void OnRabitHit (PlayerController rabit)
	{
		CrystalImage.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
		CollectedHide ();
	}
}
