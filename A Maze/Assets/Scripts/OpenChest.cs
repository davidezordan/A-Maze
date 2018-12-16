using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

	private bool isOpening;
	public GameObject chestTop;

	Quaternion startRotation;
	Quaternion endRotation;

	float rotationTime = 5f;

	float timer = 0f;

	void Start() {
		startRotation = Quaternion.Euler(chestTop.transform.rotation.eulerAngles);
		endRotation = Quaternion.Euler(0, chestTop.transform.rotation.eulerAngles.y, chestTop.transform.rotation.eulerAngles.z);
	}

	public void OnClick() {
		Debug.Log("Chest clicked");

		if (chestTop) {
			isOpening = true;
			DisableColliders();
			GetComponent<AudioSource>().Play();
		}	
	}

	void Update() {
		if (isOpening) {
			Debug.Log("Callig Slerp");

			chestTop.transform.rotation = Quaternion.Slerp(startRotation, endRotation, timer / rotationTime);

			timer += Time.deltaTime;
			if (timer > rotationTime) {
				isOpening = false;
				timer = 0;
			}
		}
	}

	private void DisableColliders()
    {
		var colliders = gameObject.GetComponentsInChildren<Collider>();
		foreach(var collider in colliders) {
			collider.enabled = false;
		}
    }
}
