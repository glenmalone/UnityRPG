using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public GameObject dialoguePanel;
	public static DialogueSystem Instance { get; set; }
	public List<string> dialogueLines = new List<string>();
	public string npcName;
	Button continueButton;
	Text dialogueText, nameText;
	int dialogueIndex;
	public bool go;

	void Awake(){
		continueButton = dialoguePanel.transform.Find("Continue").GetComponent<Button>();
		dialogueText = dialoguePanel.transform.Find("DialogueText").GetComponent<Text>();
		nameText = dialoguePanel.transform.Find("NPCName").GetComponentInChildren<Text>();

		continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

		dialoguePanel.SetActive(false);
		if (Instance != null && Instance != this){
			Destroy(gameObject);
		}
		else{
			Instance = this;
		}
	}

	public void AddNewDialogue(string[] lines, string npcName){
		dialogueIndex = 0;
		this.npcName = npcName;
		dialogueLines = new List<string>(lines.Length);
		dialogueLines.AddRange(lines);
		CreateDialogue();
	}

	public void CreateDialogue(){
		dialogueText.text = dialogueLines[dialogueIndex];
		nameText.text = npcName;
		dialoguePanel.SetActive(true);
		go = false;
		Cursor.visible = true;
	}

	public void ContinueDialogue(){
		if(dialogueIndex < dialogueLines.Count - 1){
			dialogueIndex++;
			dialogueText.text = dialogueLines[dialogueIndex];
		}
		else{
			dialoguePanel.SetActive(false);
			go =  true;
		}
	}
}
