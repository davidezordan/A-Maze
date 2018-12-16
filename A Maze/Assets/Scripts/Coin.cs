using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public GameObject gameManager;

	private GameManager manager;
	
	void Start () {
		if (gameManager)
			manager = gameManager.GetComponent<GameManager>();
	}
	
	public void onClicked() {
		Debug.Log("Coin clicked");

		if (manager)
			manager.IncrementCoins();
	}
}
