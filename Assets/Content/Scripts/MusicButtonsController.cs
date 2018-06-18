using UnityEngine.UI;

public class MusicButtonsController : ButtonController
{

	void Start()
	{
		if(Value == MusicManager.Instance.MusicOn)
			GetComponent<Button>().onClick.Invoke();
	}

	public bool Value;

	protected override void PostClick()
	{
		MusicManager.Instance.MusicOn = Value;
	}
}
