using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : Interactable {

	static Animator anim;
	public bool villager;
	public string[] dialogue;
	public string name;

	void Awake(){
		anim = GetComponentInParent<Animator>();
		if(villager){
			anim.SetBool("idleA", false);
			anim.SetBool("idle", true);
		}
		else{
			anim.SetBool("idleA", true);
			anim.SetBool("idle", false);
		}
	}

	public override void Interact(){
		DialogueSystem.Instance.AddNewDialogue(dialogue, name);
		Debug.Log("Interacting with NPC");
	}
}
