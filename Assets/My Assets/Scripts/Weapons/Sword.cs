using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon {
	static Animator anim;
	private AnimatorStateInfo info;

	public List<BaseStat> Stats { get; set; }
	public CharacterStats CharacterStats { get; set; }
	public int CurrentDamage{ get; set; }

	void Start(){
		anim = GetComponentInParent<Animator>();
	}

	public void PerformAttack(int damage){
		CurrentDamage = damage;
		//Debug.Log(name + " attack");
	}


	void Update(){
		info = anim.GetCurrentAnimatorStateInfo (0);
	}

	void OnTriggerEnter(Collider col){
		//Debug.Log("Hit: " + col.name);
		if (col.tag == "Enemy"){
			if(info.IsName("1HANDED-ATK1") || info.IsName("1HANDED-ATK2") || info.IsName("2HANDED-ATK")){
				col.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
			}
		}
	}
}
