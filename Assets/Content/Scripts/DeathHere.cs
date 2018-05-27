using UnityEngine;

public class DeathHere : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D collider)
	{
		PlayerController rabit = collider.GetComponent<PlayerController>();
		if (rabit != null)
		{
			LevelController.Current.OnRabitDeath (rabit);
		}
	}
}
