using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFinish : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) 
	{
		PlayerController rabit = collider.GetComponent<PlayerController>(); 
		if(rabit != null)
		{
			LevelController.Current.Stats.LevelPassed = true;
			SceneManager.LoadScene("Level Chooser");
		}
	}
}
