using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{

    public GameObject textNextLevel;

    public AudioClip finish;

    public AudioSource audioS;
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Player"))
        {
            textNextLevel.SetActive(true);
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().clip = finish;
            GetComponent<AudioSource>().Play();
            Invoke("NextScenes", 5f);
        }
    }


    void NextScenes()
    {

        SceneManager.LoadScene("Menu");
        textNextLevel.SetActive(false);

        GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
    }
}


