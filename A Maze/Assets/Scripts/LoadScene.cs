using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public string SceneToLoad = "_Scenes/Main";

    void Start (){
        StartCoroutine(LoadSceneAsync());
    }
    
    IEnumerator LoadSceneAsync() {
        yield return new WaitForSeconds(4);
        
        SceneManager.LoadSceneAsync(SceneToLoad);
    }
}
