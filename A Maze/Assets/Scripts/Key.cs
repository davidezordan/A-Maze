using UnityEngine;

[RequireComponent(typeof(Door))]
public class Key : MonoBehaviour {
	private Door _doorComponent;
	public GameObject door;

	void Start() {
		_doorComponent = door.GetComponent<Door>();
    }

	public void OnKeyClicked () {
		_doorComponent.Unlock();
	}
}
