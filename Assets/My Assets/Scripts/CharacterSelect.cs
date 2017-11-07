using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public enum MyGenders{
	Male, Female
};

public class CharacterSelect : MonoBehaviour {

	public GameObject Male, Female;
	public GameObject CSCamera, PlayerCamera, characterSelectPanel;
	public Text GenderText;
	public PlayerMovement moveScript;
	InventoryController inventoryController;
	public MyGenders Gender;
	public GameObject Player;
	bool isSpawned, canPlay;

	void Awake () {
		GenderText.text = "" + Gender;
		CharacterSelection();
		canPlay = true;
		inventoryController = Player.GetComponent<InventoryController>();
		moveScript = Player.GetComponent<PlayerMovement>();
	}

	void Start(){
		//Disabling movement until character is chosen
		//GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>().go = false;
		GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>().go = true;
		PlayerCamera.SetActive(false);
	}

	void Update () {
		CharacterSelection();
		Play();
		GenderText.text = "" + Gender;
	}
	
	public void Melee(){
		canPlay = true;
		inventoryController.EquipItem(GameObject.Find("Inventory").GetComponent<ItemDatabase>().Items[0]);
	}

	public void Ranged(){
		canPlay = true;
		inventoryController.EquipItem(GameObject.Find("Inventory").GetComponent<ItemDatabase>().Items[1]);
	}

	public void Magic(){
		canPlay = true;
		inventoryController.EquipItem(GameObject.Find("Inventory").GetComponent<ItemDatabase>().Items[2]);
	}

	public void GenderUp(){
		canPlay = false;
		if(Gender == MyGenders.Male){
			Gender = MyGenders.Female;
			isSpawned = !isSpawned;
		}
		else if(Gender == MyGenders.Female){
			Gender = MyGenders.Male;
			isSpawned = !isSpawned;
		}
	}

	public void GenderDown(){
		canPlay = false;
		if(Gender == MyGenders.Male){
			Gender = MyGenders.Female;
			isSpawned = !isSpawned;
		}
		else if(Gender == MyGenders.Female){
			Gender = MyGenders.Male;
			isSpawned = !isSpawned;
		}
	}

	public void Play(){
		if(canPlay == true){
			characterSelectPanel.SetActive(false);
			CSCamera.SetActive(false);
			PlayerCamera.SetActive(true);
			GameObject.Find("Inventory").GetComponent<InventoryUI>().menuToggle = true;
		}
	}

	void CharacterSelection(){
		if(!isSpawned){
			//Male
			if(Gender == MyGenders.Male){
				//Destroy(Player);
				//Player = (GameObject)Instantiate(Male);
				inventoryController = Player.GetComponent<InventoryController>();
				moveScript = Player.GetComponent<PlayerMovement>();
				moveScript.go = false; 
				isSpawned = !isSpawned;
			}

			//Female
			if(Gender == MyGenders.Female){
				//Destroy(Player);
				//Player = (GameObject)Instantiate(Female);
				inventoryController = Player.GetComponent<InventoryController>();
				moveScript = Player.GetComponent<PlayerMovement>();
				moveScript.go = false; 
				isSpawned = !isSpawned;
			}
		}
	}
}
