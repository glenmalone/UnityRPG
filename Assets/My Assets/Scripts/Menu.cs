using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public GameObject loading;
	public AudioClip clickSound;
	AudioSource audioSource;

	public void Start(){
		audioSource = GetComponent<AudioSource>();
		loading.SetActive(false);
	}

	public void Play () {
		loading.SetActive(true);
		audioSource.PlayOneShot(clickSound, .1f);
		Invoke("LoadLevel", 3f);
	}

	public void Quit () {
		audioSource.PlayOneShot(clickSound, .1f);
		Application.Quit();
	}

	private void LoadLevel(){
		SceneManager.LoadScene("Village");
	}
}
