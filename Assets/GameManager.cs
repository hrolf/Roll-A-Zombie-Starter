using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private int selectedZombiePosition =0;

	public int health;

	public GameObject selectedZombie;
	public List<GameObject> zombies;
	public Vector3 selectedSize;
	public Vector3 defautSize;

	private int count;
	public Text theText;
	public Meny theMeny;
	public Text gameOverText;

	private bool gameOver =false;


	// Use this for initialization
	void Start () {
		SelectZombie (selectedZombie);
		count = 0;
		theText.text = ("Scores: " + count);
		theMeny = GetComponent<Meny> ();
		health = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("left"))
			{
				GetZombieLeft();
			}
		if(Input.GetKeyDown("right"))
			{
			GetZombieRight ();	
			}
		if(Input.GetKeyDown("up"))
			{
			PushUp ();
			}
		if(Input.GetKeyDown(KeyCode.Return))
			{
				theMeny.NewGame();
			}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			theMeny.Avsluta ();
		}
		
	}
	void GetZombieLeft()
	{
		if (selectedZombiePosition == 0) {
			selectedZombiePosition = 3;
			SelectZombie(zombies[3]);
		} else {
			selectedZombiePosition = selectedZombiePosition - 1;
			SelectZombie(zombies[selectedZombiePosition]);
										}
		}
	void GetZombieRight()
	{
	if (selectedZombiePosition == 3) {
			selectedZombiePosition = 0;
			SelectZombie(zombies [0]);
		} else {
			selectedZombiePosition = selectedZombiePosition + 1;
			SelectZombie(zombies[selectedZombiePosition]);
		}
	}


	void SelectZombie(GameObject newZombie)
	{ 
		selectedZombie.transform.localScale = defautSize;
		selectedZombie = newZombie;
		newZombie.transform.localScale = selectedSize;
	}
	void PushUp ()
	{
		Rigidbody Rb = selectedZombie.GetComponent<Rigidbody>();
		Rb.AddForce (0, 0, 10, ForceMode.Impulse);
	}
	public void AddScore()
	{
		if (!gameOver) {
			count +=1;
		}
		theText.text = ("Scores: " + count);  
	}
	public void Addliv()
	{
		health -= 1;
		if (health <= 0) {
			
			gameOver = true;
			gameOverText.text = ("Game Over");
		} 
	}
}
