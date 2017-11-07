using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : Interactable {
	public AudioClip pickUpSound;
	AudioSource audioSource;

	public Item ItemDrop { get; set; }

	public void Start(){
		audioSource = GetComponent<AudioSource>();
	}

	public override void Interact(){
		InventoryController.Instance.GiveItem(ItemDrop);
		audioSource.PlayOneShot(pickUpSound, .1f);
		Destroy(gameObject);
	}
}
