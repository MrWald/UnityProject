using System.Threading;
using UnityEngine;

public class GreenOrc : Orc 
{

	private BoxCollider2D _collider;

	// Use this for initialization
	new void Start () {
		base.Start();
		Animator = GetComponent<Animator>();
		_collider = GetComponent<BoxCollider2D>();
		
		AttackSource = GetComponent<AudioSource> (); 
	}
	
	// Update is called once per frame
	void Update () {
	}

	protected override float AttackBehaviour()
	{
		//Move towards rabit
		Vector3 myPos = transform.position;
		Vector3 rabitPos = PlayerController.LastRabit.transform.position;
		if (_collider.IsTouching(PlayerController.LastRabit.GetComponent<BoxCollider2D>()))
			return 0;
		if(myPos.x < rabitPos.x)
			return 1;
		return -1;
	}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		PlayerController rabit = collider.GetComponent<PlayerController>();
		if (rabit == null) return;
		OnAttack();
		if (rabit.transform.position.y - transform.position.y > DeathHeight)
		{
			Animator.SetBool("death", true);
			StartCoroutine(DestroyLater());
		}
		else 
			PlayerController.LastRabit.GetComponent<Animator>().SetBool("death", true);
	}
}
