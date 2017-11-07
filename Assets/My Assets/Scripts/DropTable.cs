using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTable {
	public List<LootDrop> loot;

	public Item GetDrop(){
		int roll = Random.Range(0, 101);
		int dropSum = 0;
		foreach(LootDrop drop in loot){
			dropSum += drop.DropChance;
			if(roll < dropSum){
				return ItemDatabase.Instance.GetItem(drop.ItemSlug);
			}
		}
		return null;
	}
}

public class LootDrop {
	public string ItemSlug { get; set; }
	public int DropChance { get; set; }

	public LootDrop(string itemSlug, int dropChance){
		ItemSlug = itemSlug;
		DropChance = dropChance;
	}
}