using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionHealth : MonoBehaviour, IConsumable {
	public Player player;

	public void Consume(){
		player = GameObject.Find("Male").GetComponent<Player>();
		Debug.Log("You drank a health potion");
		player.Heal(5);
		Destroy(gameObject);
	}

	public void Consume(CharacterStats stats){
		player = GameObject.Find("Male").GetComponent<Player>();
		Debug.Log("You consumed a health potion");
		player.Heal(5);
		Destroy(gameObject);
	}
}
