using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour {

	static Animator anim;
	private AnimatorStateInfo info;

	public static InventoryController Instance { get; set; }
	public PlayerWeaponController playerWeaponController;
	public ConsumableController consumableController;
	public InventoryUIDetails inventoryDetailsPanel;
	public List<Item> playerItems = new List<Item>();

	void Awake(){
		if(Instance != null && Instance != this){
			Destroy(gameObject);
		}
		else{
			Instance = this;
		}
		
		anim = GetComponentInParent<Animator>();
		inventoryDetailsPanel = GameObject.Find("Inventory_Panel/Inventory_Details").GetComponent<InventoryUIDetails>();
		playerWeaponController = GetComponent<PlayerWeaponController>();
		consumableController = GetComponent<ConsumableController>();
	}

	void Start(){
		GiveItem("StartSword");
		GiveItem("StartBow");
		GiveItem("StartWand");
		GiveItem("Potion_Health");
		GiveItem("Potion_Health");
		GiveItem("Potion_Health");
	}

	public void GiveItem(string itemSlug){
		Item item = ItemDatabase.Instance.GetItem(itemSlug);
        playerItems.Add(item);
        //Debug.Log(playerItems.Count + " items in inventory. Added: " + item.ItemName);
        UIEventHandler.ItemAddedToInventory(item);
	}

	public void GiveItem(Item item){
		playerItems.Add(item);
        //Debug.Log(playerItems.Count + " items in inventory. Added: " + item.ItemName);
        UIEventHandler.ItemAddedToInventory(item);
	}

	public void SetItemDetails(Item item, Button selectedButton){
		inventoryDetailsPanel.SetItem(item, selectedButton);
	}

	public void EquipItem(Item itemToEquip){
		ResetWeaponType();
		playerWeaponController.EquipWeapon(itemToEquip);
		if (itemToEquip.WeaponType == "Bow"){
			anim.SetBool("bow", true);
		}
		// else if (itemToEquip.WeaponType == "xbow"){
		// 	anim.SetBool("xbow", true);
		// }
		else if (itemToEquip.WeaponType == "Staff" || itemToEquip.WeaponType == "Wand"){
			anim.SetBool("magic", true);
		}
		else if (itemToEquip.WeaponType == "Axe" || itemToEquip.WeaponType == "Sword" || itemToEquip.WeaponType == "Mace" || itemToEquip.WeaponType == "Dagger"){
			anim.SetBool("1h", true);
		}
		else {
			anim.SetBool("2h", true);
		}
	}

	public void ConsumeItem(Item itemToConsume){
		consumableController.ConsumeItem(itemToConsume);
	}


	void Update(){
		info = anim.GetCurrentAnimatorStateInfo (0);
	}

	void ResetWeaponType(){
		anim.SetBool("1h", false);
		anim.SetBool("2h", false);
		anim.SetBool("magic", false);
		anim.SetBool("bow", false);
		anim.SetBool("xbow", true);
	}
}
