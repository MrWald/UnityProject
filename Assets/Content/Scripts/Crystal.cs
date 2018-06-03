
using UnityEngine;
using UnityEngine.UI;

public class Crystal : Collectable
{

	public Image CrystalImage;
	public Sprite Sprite;
	
	protected override void OnRabitHit (PlayerController rabit)
	{
		CrystalImage.GetComponent<Image>().sprite = Sprite;
		CollectedHide ();
	}
}
