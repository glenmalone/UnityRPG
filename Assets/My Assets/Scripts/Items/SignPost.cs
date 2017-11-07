using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem {
	public string[] dialogue;
	
	public override void Interact(){
		DialogueSystem.Instance.AddNewDialogue(dialogue, "Welcome Sign");
	}
}
