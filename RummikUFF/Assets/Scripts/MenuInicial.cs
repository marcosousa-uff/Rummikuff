using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInicial : MonoBehaviour {

    public void ChamaTelaInfo()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TelaInfo");

    }
    public void ChamaTelaRegras()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TelaDeRegras");

    }
    public void ChamaTelaDeLoading()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TelaLoading");

    }
    public void ChamaTelaInicial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TelaInicial");

    }
    public void ChamaTelaJogo()
    {
        System.Threading.Thread.Sleep(3000);
        UnityEngine.SceneManagement.SceneManager.LoadScene("TelaInicial");

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

}
