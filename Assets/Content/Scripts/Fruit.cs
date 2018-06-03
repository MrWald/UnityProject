
using UnityEngine.UI;

public class Fruit : Collectable
{

	private static int _fruitsTaken;
	private static int _fruitsAll;
	public Text Text;

	void Awake()
	{
		++_fruitsAll;
	}

	void Start()
	{
		Text.text = "0/"+_fruitsAll;
	}
	
	protected override void OnRabitHit(PlayerController rabit)
	{
		Text.text = ++_fruitsTaken + "/" + _fruitsAll;
		CollectedHide ();
	}
}
