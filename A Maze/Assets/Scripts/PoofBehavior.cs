using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoofBehavior : MonoBehaviour {
	public GameObject poofPrefab;

	public void OnClicked () {
		if (poofPrefab)
		{
			var poof = Object.Instantiate(poofPrefab);
			poof.GetComponent<Transform>().position = this.GetComponent<Transform>().position;
		}
	}
}
