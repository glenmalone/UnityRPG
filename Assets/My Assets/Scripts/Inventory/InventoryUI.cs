using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public RectTransform inventoryPanel;
	public RectTransform scrollViewContent;
	InventoryUIItem itemContainer { get; set; }
	bool menuIsActive { get; set; }
	public bool menuToggle { get; set; }
	Item currentSelectedItem { get; set; }

	void Awake(){
		menuToggle = false;
		menuIsActive = false;
		UIEventHandler.OnItemAddedToInventory += ItemAdded;
		itemContainer = Resources.Load<InventoryUIItem>("UI/Item_Container");
		inventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
	}

	public void ItemAdded(Item item){
		InventoryUIItem emptyItem = Instantiate(itemContainer);
		emptyItem.SetItem(item);
		emptyItem.transform.SetParent(scrollViewContent);
	}

	void Update(){
		if(menuToggle){
			if(Input.GetKeyDown(KeyCode.B)){
				menuIsActive = !menuIsActive;
				if(menuIsActive){
					//GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>().go = false;
					inventoryPanel.GetComponent<CanvasGroup>().alpha = 1;
				}
				else{
					//GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>().go = true;
					inventoryPanel.GetComponent<CanvasGroup>().alpha = 0;
				}
			}
		}
	}
}
