using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCount : MonoBehaviour {

	public GameManager theGameManager;
	public AudioClip hit;
	private AudioSource audioBlip;

	// Use this for initialization
	void Start () {
		audioBlip = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnTriggerEnter(Collider other)
	{
		print ("score");
		theGameManager.AddScore ();
		audioBlip.PlayOneShot (hit);
	}
}
