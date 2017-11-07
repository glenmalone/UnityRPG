using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable {
	
	public void Consume(){
		Debug.Log("You drank a log potion");
		Destroy(gameObject);
	}

	public void Consume(CharacterStats stats){
		Debug.Log("You consumed a log potion");
		Destroy(gameObject);
	}
}
