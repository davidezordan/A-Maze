﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignPost : MonoBehaviour {

	public void ResetScene () {
		var scene = SceneManager.GetActiveScene();
		SceneManager.LoadSceneAsync(scene.name);
	}
}
