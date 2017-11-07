using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	public Vector3 Direction { get; set; }
	public float Range { get; set; }
	public int Damage { get; set; }

	Vector3 spawnPosition;

	void Start(){
		Range = 20f;
		spawnPosition = transform.position;
		GetComponent<Rigidbody>().AddForce(Direction * 250f);
		Destroy(gameObject, 5);
	}

	void Update(){
		if (Vector3.Distance(spawnPosition, transform.position) >= Range){
			Extinguish();
		}
	}

	void OnCollisionEnter(Collision col){
		Debug.Log("Hit: " + col.transform.name);
		if (col.transform.tag == "Enemy"){
			col.transform.GetComponent<IEnemy>().TakeDamage(Damage);
		}
		Extinguish();
	}

	void Extinguish(){
		Destroy(gameObject);
	}
}
