using System.Collections;
using UnityEngine;

public class DieAfterSeconds : MonoBehaviour {

	IEnumerator Start () {
		yield return new WaitForSeconds (2.0f);
		Destroy (gameObject);
	}
}
