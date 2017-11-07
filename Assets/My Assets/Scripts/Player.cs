using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	public CharacterStats characterStats;
	public int currentHealth, maxHealth, power, defence;
	static Animator anim;
	private AnimatorStateInfo info;
	public GameObject player;
	public PlayerMovement moveScript;

	void Awake() {
		player = this.gameObject;
		anim = GetComponent<Animator>();
		currentHealth = maxHealth;
		characterStats = new CharacterStats(power, defence);
	}

	void Update(){
		UIEventHandler.HealthChanged(currentHealth, maxHealth);
		info = anim.GetCurrentAnimatorStateInfo (0);

		anim.SetBool("tookDamage", false);
	}

	public void TakeDamage(int amount){
		//Debug.Log("Player takes: " + amount + " damage");
		if ( currentHealth - amount/defence <= 0){
			currentHealth = 0;
		}
		else{
			currentHealth -= amount/defence;
		}
		anim.SetBool("tookDamage", true);
		UIEventHandler.HealthChanged(currentHealth, maxHealth);
		if(currentHealth <= 0){
			Die();
		}
	}

	public void Heal(int amount){
		if(currentHealth + amount >= maxHealth){
			currentHealth = maxHealth;
		}
		else{
			currentHealth += amount;
		}
		UIEventHandler.HealthChanged(currentHealth, maxHealth);
	}

	private void Die(){
		anim.SetBool("dead", true);
		GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>().go = false;
		moveScript = player.GetComponent<PlayerMovement>();
		moveScript.go = false;  
		Invoke("Reset", 5f);
	}

	private void Reset(){
		SceneManager.LoadScene("Village");
	}
}
