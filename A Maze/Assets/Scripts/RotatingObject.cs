using UnityEngine;

public class RotatingObject : MonoBehaviour {

	public float rotateSpeed = 5;

    public Vector3 rotateDirection = Vector3.up;

	void Update () {
		transform.Rotate(rotateDirection, rotateSpeed * 10 * Time.deltaTime);
	}
}
