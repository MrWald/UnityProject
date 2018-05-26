using UnityEngine;

public class Collectable : MonoBehaviour 
{

	protected virtual void OnRabitHit(PlayerController rabit) 
	{}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		PlayerController rabit = collider.GetComponent<PlayerController>(); 
		if(rabit != null) 
		{
			OnRabitHit (rabit);
		}
	}
	public void CollectedHide() 
	{ 
		Destroy(gameObject);
	}
}
