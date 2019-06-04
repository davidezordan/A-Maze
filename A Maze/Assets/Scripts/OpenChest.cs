using UnityEngine;

public class OpenChest : MonoBehaviour {

    private Collider[] colliders;
	private bool isOpening;

	Quaternion startRotation;
	Quaternion endRotation;

	float rotationTime = 5f;

	float timer = 0f;

    public GameObject chestTop;

    void Start() {
        colliders = gameObject.GetComponentsInChildren<Collider>();
        startRotation = Quaternion.Euler(chestTop.transform.rotation.eulerAngles);
		endRotation = Quaternion.Euler(0, chestTop.transform.rotation.eulerAngles.y, chestTop.transform.rotation.eulerAngles.z);
	}

	public void OnClick() {
		if (chestTop) {
			isOpening = true;
			DisableColliders();
			GetComponent<AudioSource>().Play();
		}	
	}

	void Update() {
		if (isOpening) {

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
		foreach(var collider in colliders) {
			collider.enabled = false;
		}
    }
}
