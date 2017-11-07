using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {
	public GameObject playerHand;
	public GameObject EquippedWeapon { get; set; }

	Transform spawnProjectile;
	Item currentlyEquippedItem;
	IWeapon equippedWeapon;
	public CharacterStats characterStats;

	static Animator anim;
	private AnimatorStateInfo info;
	bool go;

	void Start(){
		anim = GetComponentInParent<Animator>();
		if(transform.Find("ProjectileSpawn") != null){
			spawnProjectile = transform.Find("ProjectileSpawn");
		}
		characterStats = GetComponent<Player>().characterStats;
	}

	public void EquipWeapon(Item itemToEquip){
		if (EquippedWeapon != null){
			InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
			characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
			Destroy(playerHand.transform.GetChild(0).gameObject);
		}
		EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.WeaponType + "/" + itemToEquip.Rarity + "/" + itemToEquip.ObjectSlug), 
			playerHand.transform.position, playerHand.transform.rotation);
		equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
		if (EquippedWeapon.GetComponent<IProjectileWeapon>() != null){
			EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
		}
		EquippedWeapon.transform.SetParent(playerHand.transform);

		characterStats.AddStatBonus(itemToEquip.Stats);
		equippedWeapon.Stats = itemToEquip.Stats;
		currentlyEquippedItem = itemToEquip;
	}

	public void PerformWeaponAttack(){
		if(equippedWeapon != null){
			equippedWeapon.PerformAttack(CalculateDamage());
		}
	}

	void Update(){ 
		go = GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>().go;
		info = anim.GetCurrentAnimatorStateInfo (0);
		if(go){
			//SWINGING LEFT AND RIGHT - Left Click
			if(Input.GetMouseButtonDown(0)){
				PerformWeaponAttack();
			}
			else{
				anim.SetBool("is_attacking01", false);
				anim.SetBool("is_attacking02", false);
			}
		}
	}

	private int CalculateDamage(){
		int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue()) + Random.Range(2, 5);
		damageToDeal += CalculateCrit(damageToDeal);
		Debug.Log("Damage dealt: " + damageToDeal);
		return damageToDeal;
	}

	private int CalculateCrit(int damage){
		//.05f is 5% crit chance
		if (Random.value <= .05f){
			int critDamage = damage += (int)(damage * Random.Range(.5f, 1.5f));
			return critDamage; 
		}
		return 0;
	}
}
