using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float Speed = 1;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
	
	private bool _isGrounded = false;
	private bool _jumpActive = false;
	private float _jumpTime = 0f;
	private Transform _heroParent = null;
	private Rigidbody2D _myBody = null;
	private Animator _animator = null;
	
	// Use this for initialization
	void Start () 
	{
		_myBody = GetComponent<Rigidbody2D>();
		LevelController.Current.SetStartPosition (transform.position);
		//Зберегти стандартний батьківський GameObject
		this._heroParent = this.transform.parent;
		_animator = GetComponent<Animator> ();
	}
	
	static void SetNewParent(Transform obj, Transform new_parent) 
	{
		if (obj.transform.parent == new_parent) return;
//Засікаємо позицію у Глобальних координатах
		Vector3 pos = obj.transform.position;
//Встановлюємо нового батька
		obj.transform.parent = new_parent;
//Після зміни батька координати кролика зміняться
//Оскільки вони тепер відносно іншого об’єкта
//повертаємо кролика в ті самі глобальні координати
		obj.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void FixedUpdate () 
	{
		if (_animator.GetBool("death"))
		{
			if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Die") ||
			    !(_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 2)) return;
			_animator.SetBool("death", false);
			LevelController.Current.onRabitDeath(this);
			return;
		}

		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layerId = 1 << LayerMask.NameToLayer("Ground");
//Перевіряємо чи проходить лінія через Collider з шаром Ground
		RaycastHit2D hit = Physics2D.Linecast(@from, to, layerId);
		if (hit)
		{
			_isGrounded = true;
			//Перевіряємо чи ми опинились на платформі
			if (hit.transform != null && hit.transform.GetComponent<MovingPlatform>() != null)
			{
				//Приліпаємо до платформи
				SetNewParent(transform, hit.transform);
			}
		}
		else
		{
			_isGrounded = false;
			SetNewParent(transform, _heroParent);
		}

//Намалювати лінію (для розробника)
		Debug.DrawLine(@from, to, Color.red);

		if (Input.GetButtonDown("Jump") && _isGrounded)
		{
			_jumpActive = true;
		}

		if (_jumpActive)
		{
//Якщо кнопку ще тримають
			if (Input.GetButton("Jump"))
			{
				_jumpTime += Time.deltaTime;
				if (_jumpTime < MaxJumpTime)
				{
					Vector2 vel = _myBody.velocity;
					vel.y = JumpSpeed * (1.0f - _jumpTime / MaxJumpTime);
					_myBody.velocity = vel;
				}
			}
			else
			{
				_jumpActive = false;
				_jumpTime = 0;
			}
		}

		//[-1, 1]
		float value = Input.GetAxis("Horizontal");
		_animator.SetBool("jump", !_isGrounded);

		if (Mathf.Abs(value) > 0)
		{
			_animator.SetBool("run", true);
			Vector2 vel = _myBody.velocity;
			vel.x = value * Speed;
			_myBody.velocity = vel;
			SpriteRenderer sr = GetComponent<SpriteRenderer>();
			if (value < 0)
			{
				sr.flipX = true;
			}
			else if (value > 0)
			{
				sr.flipX = false;
			}
		}
		else
		{
			_animator.SetBool("run", false);
		}
	}
}
