using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class Enemy : MonoBehaviour, IEnemy {
	private CharacterStats characterStats;
	public float currentHealth, maxHealth;
	public int power, defence, aggroRange;

	Animator anim;
	private AnimatorStateInfo info;

	private NavMeshAgent navAgent;
	public LayerMask aggroLayerMask;
	private Collider[] aggroColliders;
	private Player player;
	public DropTable DropTable { get; set; }
	public PickUpItem pickupItem;

	void Start(){
		DropTable = new DropTable();
		DropTable.loot = new List<LootDrop>{
			//Common Weapons
			//Axe
			new LootDrop("Axe01", 1),
			new LootDrop("Axe02", 1),
			new LootDrop("Axe03", 1),
			new LootDrop("Axe04", 1),
			new LootDrop("Axe05", 1),
			new LootDrop("Axe06", 1),
			//Bows
			new LootDrop("Bow03", 1),
			new LootDrop("Bow05", 1),
			new LootDrop("Bow06", 1),
			//Daggers
			new LootDrop("Dagger01", 1),
			new LootDrop("Dagger07", 1),
			new LootDrop("Dagger08", 1),
			new LootDrop("Dagger09", 1),
			//Maces
			new LootDrop("Mace01", 1),
			new LootDrop("Mace02", 1),
			new LootDrop("Mace05", 1),
			new LootDrop("Mace06", 1),
			new LootDrop("Mace07", 1),
			//Polearms
			new LootDrop("Polearm01", 1),
			new LootDrop("Polearm04", 1),
			new LootDrop("Polearm05", 1),
			new LootDrop("Polearm06", 1),
			new LootDrop("Polearm07", 1),
			new LootDrop("Polearm09", 1),
			//Staves
			new LootDrop("Staff01", 1),
			new LootDrop("Staff03", 1),
			new LootDrop("Staff03_a", 1),
			new LootDrop("Staff03_b", 1),
			new LootDrop("Staff04", 1),
			new LootDrop("Staff05", 1),
			//Swords
			new LootDrop("Sword02", 1),
			new LootDrop("Sword04", 1),
			new LootDrop("Sword05", 1),
			new LootDrop("Sword08", 1),
			new LootDrop("Sword09_a", 1),
			//2H Axes
			new LootDrop("TH_Axe01", 1),
			new LootDrop("TH_Axe02", 1),
			new LootDrop("TH_Axe03_a", 1),
			//2H Maces
			new LootDrop("TH_Mace01", 1),
			new LootDrop("TH_Mace02", 1),
			new LootDrop("TH_Mace04", 1),
			new LootDrop("TH_Mace07", 1),
			//2H Swords
			new LootDrop("TH_Sword02", 1),
			new LootDrop("TH_Sword06", 1),
			new LootDrop("TH_Sword07", 1),
			//Wands
			new LootDrop("Wand01", 1),
			new LootDrop("Wand03", 1),

			//Rare Weapons
			//Axe
			new LootDrop("Axe06_a", 1),
			new LootDrop("Axe07", 1),
			new LootDrop("Axe08", 1),
			new LootDrop("Axe09", 1),
			new LootDrop("Axe09_a", 1),
			//Bows
			new LootDrop("Bow07", 1),
			new LootDrop("Bow08", 1),
			new LootDrop("Bow09", 1),
			new LootDrop("Bow09_b", 1),
			new LootDrop("Bow10", 1),
			//Daggers
			new LootDrop("Dagger11", 1),
			new LootDrop("Dagger12", 1),
			new LootDrop("Dagger14", 1),
			new LootDrop("Dagger15", 1),
			//Maces
			new LootDrop("Mace09", 1),
			new LootDrop("Mace10", 1),
			new LootDrop("Mace11", 1),
			new LootDrop("Mace12_a", 1),
			//Polearms
			new LootDrop("Polearm10", 1),
			new LootDrop("Polearm11", 1),
			new LootDrop("Polearm12", 1),
			//Staves
			new LootDrop("Staff06_a", 1),
			new LootDrop("Staff07", 1),
			new LootDrop("Staff08", 1),
			new LootDrop("Staff09", 1),
			//Swords
			new LootDrop("Sword11", 1),
			new LootDrop("Sword12", 1),
			new LootDrop("Sword16", 1),
			new LootDrop("Sword16_c", 1),
			//2H Axes
			new LootDrop("TH_Axe05_a", 1),
			new LootDrop("TH_Axe06", 1),
			//2H Maces
			new LootDrop("TH_Mace08", 1),
			new LootDrop("TH_Mace09", 1),
			//2H Swords
			new LootDrop("TH_Sword09", 1),
			new LootDrop("TH_Sword12", 1),
			new LootDrop("TH_Sword12_a", 1),
			//Wands
			new LootDrop("Wand04", 1),
			new LootDrop("Wand04_a", 1),
			new LootDrop("Wand05", 1),
			new LootDrop("Wand06", 1),
			new LootDrop("Wand08", 1),

			//Epic Weapons
			//Axe
			new LootDrop("Axe10", 1),
			new LootDrop("Axe11", 1),
			new LootDrop("Axe12", 1),
			new LootDrop("Axe14", 1),
			new LootDrop("Axe17", 1),
			//Bows
			new LootDrop("Bow11_a", 1),
			new LootDrop("Bow12", 1),
			new LootDrop("Bow12_b", 1),
			//Daggers
			new LootDrop("Dagger18", 1),
			new LootDrop("Dagger20", 1),
			new LootDrop("Dagger21", 1),
			new LootDrop("Dagger21_a", 1),
			new LootDrop("Dagger21_b", 1),
			//Maces
			new LootDrop("Mace14", 1),
			new LootDrop("Mace17", 1),
			//Polearms
			new LootDrop("Polearm13", 1),
			new LootDrop("Polearm14", 1),
			new LootDrop("Polearm18", 1),
			new LootDrop("Polearm19", 1),
			//Staves
			new LootDrop("Staff10", 1),
			new LootDrop("Staff11", 1),
			new LootDrop("Staff12", 1),
			new LootDrop("Staff14", 1),
			//Swords
			new LootDrop("Sword17", 1),
			new LootDrop("Sword26", 1),
			new LootDrop("Sword26_a", 1),
			new LootDrop("Sword29", 1),
			//2H Axes
			new LootDrop("TH_Axe08", 1),
			new LootDrop("TH_Axe09", 1),
			new LootDrop("TH_Axe10", 1),
			new LootDrop("TH_Axe10_a", 1),
			//2H Maces
			new LootDrop("TH_Mace11", 1),
			new LootDrop("TH_Mace12", 1),
			new LootDrop("TH_Mace14_a", 1),
			new LootDrop("Warhammer", 1),
			//2H Swords
			new LootDrop("TH_Sword12_b", 1),
			new LootDrop("TH_Sword14_a", 1),
			new LootDrop("TH_Sword16", 1),
			new LootDrop("TH_Sword21", 1),
			//Wands
			new LootDrop("Wand09", 1),
			new LootDrop("Wand10", 1),

			//Legendary
			//Axe
			new LootDrop("Axe13", 1),
			new LootDrop("Axe15", 1),
			new LootDrop("Axe16", 1),
			new LootDrop("Axe16_a", 1),
			//Bows
			new LootDrop("Bow13", 1),
			new LootDrop("Bow13_a", 1),
			new LootDrop("Bow16", 1),
			new LootDrop("Bow17", 1),
			//Daggers
			new LootDrop("Dagger23", 1),
			new LootDrop("Dagger25", 1),
			new LootDrop("Dagger25_a", 1),
			new LootDrop("Dagger25_b", 1),
			new LootDrop("Dagger26", 1),
			//Maces
			new LootDrop("Mace18", 1),
			new LootDrop("Mace19", 1),
			new LootDrop("Mace20", 1),
			new LootDrop("Mace21", 1),
			//Polearms
			new LootDrop("Polearm20", 1),
			new LootDrop("Polearm21", 1),
			new LootDrop("Polearm22", 1),
			new LootDrop("Polearm24", 1),
			//Staves
			new LootDrop("Staff16", 1),
			new LootDrop("Staff18", 1),
			new LootDrop("Staff18_a", 1),
			//Swords
			new LootDrop("Sword21", 1),
			new LootDrop("Sword22", 1),
			new LootDrop("Sword23", 1),
			new LootDrop("Sword31", 1),
			//2H Axes
			new LootDrop("TH_Axe11", 1),
			new LootDrop("TH_Axe13", 1),
			new LootDrop("TH_Axe13_a", 1),
			//2H Maces
			new LootDrop("TH_Mace16", 1),
			new LootDrop("TH_Mace17", 1),
			new LootDrop("TH_Mace18", 1),
			//2H Swords
			new LootDrop("Runeblade", 1),
			new LootDrop("TH_Sword15", 1),
			new LootDrop("TH_Sword19", 1),
			new LootDrop("TH_Sword20", 1),
			//Wands
			new LootDrop("Wand07", 1),
			new LootDrop("Wand11", 1),
		};

		navAgent = GetComponent<NavMeshAgent>();
		characterStats = new CharacterStats(power, defence);
		anim = GetComponent<Animator>();
		currentHealth = maxHealth;
	}

	void FixedUpdate(){
		aggroColliders = Physics.OverlapSphere(transform.position, aggroRange, aggroLayerMask);
		if (aggroColliders.Length > 0){
			//Debug.Log(gameObject + ": Found player");
			anim.SetBool("isMoving", true);
			ChasePlayer(aggroColliders[0].GetComponent<Player>());
		}
		else{
			anim.SetBool("isMoving", false);
		}
	}

	void Update(){
		//Debug.Log("Gameobject: " + gameObject);
		info = anim.GetCurrentAnimatorStateInfo (0);
		if(info.IsName("Damage")){
			anim.SetBool("tookDamage", false);
		}
		if(info.IsName("Destroy")){
			navAgent.Stop();
			Die();
		}
	}

	public void PerformAttack(){
		anim.SetBool("isAttacking", true);
		anim.SetBool("isMoving", false);
		player.TakeDamage(power);
	}

	public void TakeDamage(int amount){
		//Debug.Log(gameObject + "took " + amount + " damage.");
		currentHealth -= amount/defence;
		anim.SetBool("tookDamage", true);
		if(currentHealth <= 0){
			navAgent.speed = 0;
			anim.SetBool("dead", true);
		}
	}

	void ChasePlayer(Player player){
		navAgent.SetDestination(player.transform.position);
		this.player = player;
		if(navAgent.remainingDistance <= navAgent.stoppingDistance){
			if(!IsInvoking("PerformAttack")){
				anim.SetBool("isMoving", false);
				navAgent.Stop();
				InvokeRepeating("PerformAttack", 0.5f, 1.5f);
			}
		}
		else{
			//Debug.Log("Not within distance");
			anim.SetBool("isAttacking", false);
			anim.SetBool("isMoving", true);
			navAgent.Resume();
			CancelInvoke("PerformAttack");
		}
	}

	public void Die(){
		DropLoot();
		Destroy(this.gameObject);
	}

	void DropLoot(){
		Item item = DropTable.GetDrop();
		if (item != null){
			PickUpItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);
			instance.ItemDrop = item;
		}
	}
}
