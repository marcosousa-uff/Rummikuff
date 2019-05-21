using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(LoadNewScene());

    }

    IEnumerator LoadNewScene()
    {
        //atrasar em 3 segundos a chamada da proxima tela para agente poder ver a tela de loading
        yield return null;
        AsyncOperation ao = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("TeladoJogo");
        if (ao.isDone)
        {
            //yield return new WaitForSeconds(3);
            UnityEngine.SceneManagement.SceneManager.LoadScene("TeladoJogo");

        }

    }
}
