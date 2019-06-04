using UnityEngine;

public class Door : MonoBehaviour {
	private float timer = 0f;
	private Quaternion leftDoorStartRotation;
	private Quaternion leftDoorEndRotation;
	private Quaternion rightDoorStartRotation;
	private Quaternion rightDoorEndRotation;
	private bool isLocked = true;
	private bool isOpening;
	private AudioSource audioSource;
    private Collider[] colliders;

	public GameObject leftDoor;
	public GameObject rightDoor;
	public float rotationTime = 10f;

	public float openAngle = 100;

	void Start () {
		audioSource = this.GetComponent<AudioSource>();
        colliders = gameObject.GetComponentsInChildren<Collider>();

        if (leftDoor && rightDoor) {
			leftDoorStartRotation = Quaternion.Euler(leftDoor.transform.rotation.eulerAngles);
			rightDoorStartRotation = Quaternion.Euler(rightDoor.transform.rotation.eulerAngles);

			leftDoorEndRotation = Quaternion.Euler(leftDoorStartRotation.eulerAngles.x, leftDoorStartRotation.eulerAngles.y - openAngle, leftDoorStartRotation.eulerAngles.z);
			rightDoorEndRotation = Quaternion.Euler(rightDoorStartRotation.eulerAngles.x, rightDoorStartRotation.eulerAngles.y + openAngle, rightDoorStartRotation.eulerAngles.z);
		}
	}

	void Update () {
		if (isOpening && leftDoor && rightDoor) {
			leftDoor.transform.rotation = Quaternion.Slerp(leftDoorStartRotation, leftDoorEndRotation, timer / rotationTime);
			rightDoor.transform.rotation = Quaternion.Slerp(rightDoorStartRotation, rightDoorEndRotation, timer / rotationTime);

			timer += Time.deltaTime;

			if (timer > rotationTime) {
				isOpening = false;
				timer = 0;
			}
		}
	}

    private void DisableColliders()
    {
		foreach(var collider in this.colliders) {
			collider.enabled = false;
		}
    }

    public void OnDoorClicked () {
		if (!isLocked) {
			isOpening = true;
			DisableColliders();

			PlayAudioClip();

		} else {
			PlayAudioClip("Audio/Door_Locked");
		}
	}

	public void Unlock () {
		isLocked = false;
	}

	private void PlayAudioClip(string audioClip = "") {
		if (!audioSource)
			return;

		if (string.IsNullOrEmpty(audioClip)) {
			audioSource.Play();
		} else {
			var doorLockedAudio = Resources.Load<AudioClip>(audioClip);
			if (doorLockedAudio) {
				audioSource.PlayOneShot(doorLockedAudio);
			}
		}
	}
}
