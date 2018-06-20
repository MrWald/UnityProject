using UnityEngine;
using UnityEngine.UI;

public class Crystal : Collectable
{

	public Image CrystalImage;
	
	void Start()
	{
		Audio = GetComponent<AudioSource>();
	}
	
	protected override void OnRabitHit (PlayerController rabit)
	{
		CrystalImage.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
		++LevelController.Current.CrystalsTaken;
		CollectedHide ();
	}
}
