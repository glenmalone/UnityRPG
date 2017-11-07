using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon, IProjectileWeapon {
	static Animator anim;
	private AnimatorStateInfo info;

	public List<BaseStat> Stats { get; set; }
	public CharacterStats CharacterStats { get; set; }
	public int CurrentDamage { get; set; }

	public Transform ProjectileSpawn { get; set; }
	Arrow arrow;

	void Start(){
		arrow = Resources.Load<Arrow>("Weapons/Projectiles/Arrow");
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
		Arrow arrowInstance = (Arrow)Instantiate(arrow, ProjectileSpawn.position, ProjectileSpawn.rotation);
		arrowInstance.Direction = ProjectileSpawn.forward;
		arrowInstance.Damage = damage;
	}
}
