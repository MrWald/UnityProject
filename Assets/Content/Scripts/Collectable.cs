using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{

	protected AudioSource Audio;
	
	protected virtual void OnRabitHit(PlayerController rabit) 
	{}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		PlayerController rabit = collider.GetComponent<PlayerController>();
		if (rabit == null) return;
		OnRabitHit (rabit);
	}
	
	public void CollectedHide()
	{
		GetComponent<SpriteRenderer>().sprite = null;
		if(SoundManager.Instance.IsSoundOn && Audio!=null)
			Audio.Play();
		StartCoroutine(Hide());
	}

	private IEnumerator Hide()
	{
		yield return new WaitForSeconds(Audio!=null?Audio.clip.length:0); 
		Destroy(gameObject);
	}
}
