using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private float timeLeftSeconds;
	private int coinCount;
	public float levelTimeMinutes = 0.5f;
	public string GameOverScene = "GameOver";

	public Text timeRemaining;
	public Text coinCounter;

	void Awake() {
		timeLeftSeconds = levelTimeMinutes * 60;
		ResetCoins();
	}
	
	void Update () {
		timeLeftSeconds -= Time.deltaTime;
		if (timeLeftSeconds < 0) {
			handleGameFinished();
		} else {
			updateGuiTimer();
		}		
	}

	private void updateGuiTimer()
    {
 		var timeSpan = TimeSpan.FromSeconds(timeLeftSeconds);
 		string timeText = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);

		UpdateRemainingTime(timeText);
    }

	private void UpdateRemainingTime(string time) {
		if (timeRemaining)
			timeRemaining.text = String.Format("{0}", time);
	}

	private void handleGameFinished()
    {
        StartCoroutine(LoadSceneAsync());
    }

	IEnumerator LoadSceneAsync() {
		yield return new WaitForSeconds(1);
		
		SceneManager.LoadSceneAsync(GameOverScene);
	}

	public void IncrementCoins() {
		coinCount++;
		UpdateCointText();
	}

	public void ResetCoins() {
		coinCount = 0;
		UpdateCointText();
	}

	private void UpdateCointText() {
		if (coinCounter)
			coinCounter.text = String.Format("{0}", coinCount);
	}
}
