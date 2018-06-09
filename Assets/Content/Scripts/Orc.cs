using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public abstract class Orc : MovingObj {

	public float Speed = 1;
	public float DeathHeight = 0.5f;
	protected Animator Animator;
	protected Mode _mode;
	protected AudioSource AttackSource;
	
	protected enum Mode { 
		GoToA,
		GoToB, 
		Attack 
		//...
    }
	
	// Use this for initialization
	new void Start ()
	{
		base.Start();
		_mode = Mode.GoToA;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
		if (Animator.GetBool("death"))
			return;
		
		float value = GetDirection ();

		if (Mathf.Abs(value) > 0)
		{
			Animator.SetBool("walk", _mode!=Mode.Attack);
			Animator.SetBool("run", _mode==Mode.Attack);
			Vector2 vel = MyBody.velocity;
			vel.x = value * Speed;
			MyBody.velocity = vel;
			SpriteRenderer sr = GetComponent<SpriteRenderer>();
			if (value < 0)
				sr.flipX = false;
			else if (value > 0)
				sr.flipX = true;
		}
		else
		{
			Animator.SetBool("walk", false);
			Animator.SetBool("run", false);
			if(_mode==Mode.Attack)
				Animator.SetTrigger("attack");
		}
	}

	protected abstract float AttackBehaviour();
	
	protected void OnAttack() {
		if(SoundManager.Instance.IsSoundOn)
			AttackSource.Play();
	}
	
	private float GetDirection()
	{
		
		Vector3 myPos = transform.position;
		if(_mode == Mode.GoToA) 
		{ 
			if(IsArrived(myPos, PointA)) 
			{
				_mode = Mode.GoToB; 
			}
		} 
		else if(_mode == Mode.GoToB) 
		{ 
			if(IsArrived(myPos, PointB)) 
			{
				_mode = Mode.GoToA; 
			}
		}
		Vector3 rabitPos = PlayerController.LastRabit.transform.position;
		if (_mode != Mode.Attack && rabitPos.x > Mathf.Min (PointA.x, PointB.x)
		                       && rabitPos.x < Mathf.Max (PointA.x, PointB.x) && Math.Abs(rabitPos.y-myPos.y)<DeathHeight*4)
		{
			_mode = Mode.Attack;
			Speed *= 1.5f;
		}
		else if (_mode == Mode.Attack && (rabitPos.x < Mathf.Min (PointA.x, PointB.x)
		                             || rabitPos.x > Mathf.Max (PointA.x, PointB.x)))
		{
			Speed /= 1.5f;
			_mode = Mode.GoToA;
		}
		switch (_mode)
		{
			case Mode.Attack:
				return AttackBehaviour();
			case Mode.GoToA:
				//Direction depending on target
				if (myPos.x < PointA.x)
				{
					return 1;
				}
				return -1;
			case Mode.GoToB:
				if (myPos.x < PointB.x)
				{
					return 1;
				}
				return -1;
			default:
				throw new NotImplementedException();
		}
	}
	
	protected IEnumerator DestroyLater() {
		yield return new WaitForSeconds (Animator.GetCurrentAnimatorStateInfo(0).length); 
		Destroy (gameObject);
	}
}
