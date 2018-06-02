using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeOrc : Orc {

	public GameObject PrefabCarrot;
	
	private float _lastCarrot;
	private BoxCollider2D _collider;
	
	// Use this for initialization
	new void Start () {
		base.Start();
		Animator = GetComponent<Animator>();
		_lastCarrot = Time.time;
		_collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected override float AttackBehaviour()
	{
		Vector3 myPos = transform.position;
		Vector3 rabitPos = PlayerController.LastRabit.transform.position;
		GetComponent<SpriteRenderer>().flipX = PlayerController.LastRabit.GetComponent<SpriteRenderer>().flipX;
		if(Mathf.Abs(rabitPos.x - myPos.x) < 5.0f)
		{
			
			if (_collider.IsTouching(PlayerController.LastRabit.GetComponent<BoxCollider2D>()))
			{
				if (rabitPos.y - myPos.y > DeathHeight)
				{
					Animator.SetBool("death", true);
					StartCoroutine(DestroyLater());
				}
				else 
					PlayerController.LastRabit.GetComponent<Animator>().SetBool("death", true);
				return 0;
			}
			if (!(Time.time - _lastCarrot > 2.0f)) return 0;
			LaunchCarrot(myPos.x < rabitPos.x?1:-1);
			_lastCarrot = Time.time;
			
			return 0;
		}
		if(myPos.x < rabitPos.x)
			return 1;
		return -1;
	}


	void LaunchCarrot(float direction) {
//Створюємо копію Prefab
		GameObject obj = Instantiate(PrefabCarrot);
		obj.transform.position = new Vector2(transform.position.x, transform.position.y+transform.localScale.y);
		obj.GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
//Запускаємо в рух
		Carrot carrot = obj.GetComponent<Carrot> ();
		carrot.Launch (direction); 
	}

}
