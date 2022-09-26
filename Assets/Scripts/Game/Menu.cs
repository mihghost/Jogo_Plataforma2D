using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene(cena);
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = true;
    }


    public void ButtonReturn(string cena)
    {
        SceneManager.LoadScene(cena);
        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
    }
    public void Quit()
    {
        Application.Quit();
    }


}
