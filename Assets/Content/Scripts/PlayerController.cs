using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float Speed = 1;
	public float MaxJumpTime = 2f;
	public float JumpSpeed = 2f;
	public static PlayerController LastRabit;
	public AudioClip WalkingAudio;
	public AudioClip JumpingAudio;
	public AudioClip DeathAudio;
	public AudioSource AudioSource;
	
	private bool _isGrounded;
	private bool _jumpActive;
	private float _jumpTime;
	private float _timePassed;
	private static float _effectDuration = 4;
	private Transform _heroParent;
	private Rigidbody2D _myBody;
	private Animator _animator;
	private bool _wait;
	
	
	void Awake() {
		LastRabit = this;
	}
	
	// Use this for initialization
	void Start () 
	{
		_myBody = GetComponent<Rigidbody2D>();
		LevelController.Current.SetStartPosition(transform.position);
		_heroParent = transform.parent;
		_animator = GetComponent<Animator>();
		AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_wait) return;

		if (!_animator.GetBool("death")) return;
		AudioSource.clip = DeathAudio;
		if(SoundManager.Instance.IsSoundOn)
			AudioSource.Play();
		_wait = true;
		StartCoroutine(PostDeath());
	}

	void FixedUpdate ()
	{
		if (_wait) return;

		CheckForBombHit();

		CheckIfGrounded();

		CheckForJump();

		CheckForMovement();
	}

	private void CheckForMovement()
	{
		
		float value = Input.GetAxis("Horizontal");
		_animator.SetBool("jump", !_isGrounded);

		if (Mathf.Abs(value) > 0)
		{
			if (AudioSource.clip == null)
			{
				AudioSource.clip = WalkingAudio;
				AudioSource.loop = true;
				if(SoundManager.Instance.IsSoundOn)
					AudioSource.Play();
			}
			_animator.SetBool("run", true);
			Vector2 vel = _myBody.velocity;
			vel.x = value * Speed;
			_myBody.velocity = vel;
			SpriteRenderer sr = GetComponent<SpriteRenderer>();
			if (value < 0)
				sr.flipX = true;
			else if (value > 0)
				sr.flipX = false;
		}
		else
		{
			AudioSource.Stop();
			AudioSource.clip = null;
			_animator.SetBool("run", false);
		}
	}

	private void CheckIfGrounded()
	{
		Vector3 from = transform.position + Vector3.up * 0.3f;
		Vector3 to = transform.position + Vector3.down * 0.1f;
		int layerId = 1 << LayerMask.NameToLayer("Ground");
		
		RaycastHit2D hit = Physics2D.Linecast(@from, to, layerId);
		if (hit)
		{
			_isGrounded = true;
			
			if (hit.transform != null && hit.transform.GetComponent<MovingPlatform>() != null)
			{
				//Приліпаємо до платформи
				LevelController.SetNewParent(transform, hit.transform);
			}
		}
		else
		{
			AudioSource.Stop();
			AudioSource.clip = null;
			_isGrounded = false;
			LevelController.SetNewParent(transform, _heroParent);
		}

		Debug.DrawLine(@from, to, Color.red);
	}
	
	private void CheckForJump()
	{
		if (Input.GetButtonDown("Jump") && _isGrounded)
		{
			_jumpActive = true;
		}

		if (!_jumpActive) return;
//Якщо кнопку ще тримають
		if (Input.GetButton("Jump"))
		{
			_jumpTime += Time.deltaTime;
			if (!(_jumpTime < MaxJumpTime)) return;
			Vector2 vel = _myBody.velocity;
			vel.y = JumpSpeed * (1.0f - _jumpTime / MaxJumpTime);
			_myBody.velocity = vel;
		}
		else
		{
			_jumpActive = false;
			_jumpTime = 0;
		}
	}

	private void CheckForBombHit()
	{
		if (!Bomb.Hit) return;
		_timePassed += Time.deltaTime;
		if (!(_timePassed >= _effectDuration)) return;
		_timePassed = 0f;
		GetComponent<SpriteRenderer>().color = Color.white;
		Bomb.Hit = false;
	}

	private IEnumerator PostDeath()
	{
		yield return new WaitForSeconds (AudioSource.clip.length); 
		_animator.SetBool("death", false);
		LevelController.Current.OnRabitDeath(this);
		_wait = false;
		AudioSource.clip = null;
	}
}
