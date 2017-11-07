using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ItemDatabase : MonoBehaviour {
	public static ItemDatabase Instance { get; set; }
	public List<Item> Items { get; set; }

	void Awake () {
		if (Instance != null && Instance != this){
			Destroy(gameObject);
		}
		else{
			Instance = this;
		}
		BuildDatabase();
	}
	
	private void BuildDatabase(){
		Items = JsonConvert.DeserializeObject<List<Item>>(Resources.Load<TextAsset>("JSON/Items").ToString());
		//Debug.Log(Items[0].Stats[0].StatName + " level is " + Items[1].Stats[0].GetCalculatedStatValue());
		//Debug.Log(Items[0].ItemName);
	}

	public Item GetItem(string itemSlug){
		foreach (Item item in Items){
			if(item.ObjectSlug == itemSlug){
				return item;
			}
		}
		//Debug.LogWarning("Couldn't find item: " + itemSlug);
		return null;
	}
}
