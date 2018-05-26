using UnityEngine;

public class ParallaxLayer : MonoBehaviour {

	//[0, 1] - 0-фон стоїть на місці як платформи
	//1 - фон рухається так само як кролик
	public float Slowdown = 0.5f;
	
	private Vector3 _lastPosition;
	
	void Awake() 
	{
		_lastPosition = Camera.main.transform.position;
	}
	
	void LateUpdate() 
	{
		Vector3 newPosition = Camera.main.transform.position; 
		Vector3 diff = newPosition - _lastPosition; 
		_lastPosition = newPosition;
		Vector3 myPos = this.transform.position; //Рухаємо фон в туж сторону що й камера але з іншою швидкістю
		myPos += Slowdown * diff;
		this.transform.position = myPos;
	}
}
