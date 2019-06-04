using UnityEngine;

public class Key : MonoBehaviour {
	public GameObject door;

	public void OnKeyClicked () {
		if (door) {
			door.GetComponent<Door>().Unlock();
		}
	}
}
