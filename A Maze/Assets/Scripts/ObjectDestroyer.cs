using System.Collections;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

	public float timeSeconds = 0.5f;

    public void WaitAndDestroyGameObject(GameObject gameObject) {
        if (gameObject) {
			StartCoroutine(WaitAndDestroy(gameObject));
		}
    }

	IEnumerator WaitAndDestroy(GameObject gameObject) {
		yield return new WaitForSeconds(timeSeconds);
		
		Object.Destroy(gameObject);
	}

	public void OnClicked () {
		WaitAndDestroyGameObject(this.gameObject);
	}
}
