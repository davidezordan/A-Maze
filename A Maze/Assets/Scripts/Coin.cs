using UnityEngine;

public class Coin : MonoBehaviour {

	public GameObject gameManager;

	private GameManager manager;
	
	void Start () {
		if (gameManager)
			manager = gameManager.GetComponent<GameManager>();
	}
	
	public void onClicked() {
		if (manager)
			manager.IncrementCoins();
	}
}
