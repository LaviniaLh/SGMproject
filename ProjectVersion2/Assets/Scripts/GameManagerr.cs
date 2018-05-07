using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerr : MonoBehaviour {

	public GameObject cat;
	public GameObject dog;

	public int catLife;
	public int dogLife;

	public GameObject catWins;
	public GameObject dogwins;

	public GameObject[] catHearts;
	public GameObject[] dogHearts;

	public AudioSource hurtSound;
	public AudioSource background;
	public AudioSource gameover;

	public string mainMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(catLife<= 0)
		{
			cat.SetActive(false);
			dogwins.SetActive(true);
			if(background.isPlaying)
			{
				background.Stop();
				gameover.Play();
			}
		}

		if(dogLife<=0)
		{
			dog.SetActive(false);
			catWins.SetActive(true);
			if(background.isPlaying)
			{
				background.Stop();
				gameover.Play();
			}
		}

		if(Input.GetKeyDown(KeyCode.M))
		{
			SceneManager.LoadScene(mainMenu);
		}

	}

	public void CatHurt()
	{
		catLife -= 1;

		for(int i=0; i< catHearts.Length;i++)
		{
			if(catLife > i)
			{
				catHearts[i].SetActive(true);
			}
			else
			{
				catHearts[i].SetActive(false);
			}
		}

		hurtSound.Play();
	}

	public void DogHurt()
	{
		dogLife -= 1;

		for(int i=0; i< dogHearts.Length;i++)
		{
			if(dogLife > i)
			{
				dogHearts[i].SetActive(true);
			}
			else
			{
				dogHearts[i].SetActive(false);
			}
		}
		hurtSound.Play();
	}
}
