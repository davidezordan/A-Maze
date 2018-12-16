using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingTextAnimation : MonoBehaviour {

	private UnityEngine.UI.Text _text;

	void Start () {
		InvokeRepeating("UpdateLoadingText", 1f, 1f);
		_text = gameObject.GetComponent<UnityEngine.UI.Text>();
	}
	
	void UpdateLoadingText () {
		_text.text += '.';
	}	
}