using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon {
	static Animator anim;
	private AnimatorStateInfo info;

	public List<BaseStat> Stats { get; set; }
	public CharacterStats CharacterStats { get; set; }
	public int CurrentDamage{ get; set; }

	public Transform ProjectileSpawn { get; set; }
	Fireball fireball;

	void Start(){
		fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
		anim = GetComponentInParent<Animator>();
	}

	void Update(){
		info = anim.GetCurrentAnimatorStateInfo (0);
	}
	public void PerformAttack(int damage){
		CastProjectile(damage);
		Debug.Log(name + " attack");
	}

	public void CastProjectile(int damage){
		Fireball fireballInstance = (Fireball)Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
		fireballInstance.Direction = ProjectileSpawn.forward;
		fireballInstance.Damage = damage;
	}
}
