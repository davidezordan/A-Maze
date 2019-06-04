using UnityEngine;

public class LoadingTextAnimation : MonoBehaviour {

	private UnityEngine.UI.Text _text;
    private string delimiter = ".";

	void Start () {
		InvokeRepeating("UpdateLoadingText", 1f, 1f);
		_text = gameObject.GetComponent<UnityEngine.UI.Text>();
	}
	
	void UpdateLoadingText () {
		_text.text += delimiter;
	}	
}