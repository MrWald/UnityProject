using UnityEngine.UI;

public class SoundButtonController : ButtonController {

	void Start()
	{
		if(Value == MusicManager.Instance.SoundOn)
			GetComponent<Button>().onClick.Invoke();
	}

	public bool Value;

	protected override void PostClick()
	{
		MusicManager.Instance.SoundOn = Value;
	}
}
