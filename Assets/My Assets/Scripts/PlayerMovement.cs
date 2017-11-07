using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	static Animator anim;
	private AnimatorStateInfo info;
	public float speed = 2.0f;
	public float jumpSpeed = 4.0f;
	public float rotationSpeed = 75.0f;
	public bool go;
	float rotation;
	bool isWalking, isSitting;

	void Awake () {
		//go = false;
		//Set bools to false
		isWalking = false;
		isSitting = false;

		//Setting animator state
		anim = GetComponentInParent<Animator>();
		info = anim.GetCurrentAnimatorStateInfo (0);
	}

	void Start(){
		go = GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>().go;
		//anim.SetBool("melee", true);
	}

	void OnTriggerStay(Collider col){
		//INTERACTING WITH ITEMS/NPCS - E Key
		if(col != null){
			if(Input.GetKeyDown(KeyCode.E)){
				if(go){
					col.gameObject.GetComponentInParent<Interactable>().Interact();
				}
				if(!go){
					DialogueSystem.Instance.ContinueDialogue();
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		go = GameObject.Find("DialogueSystem").GetComponent<DialogueSystem>().go;
		//Debug.Log(go);
		//Getting animator state
		info = anim.GetCurrentAnimatorStateInfo (0);
		if(go){
			//Camera Turning
			if(Input.GetMouseButton(1)){
				Cursor.visible = false;
				rotation = Input.GetAxis("Mouse X") * rotationSpeed;
			}
			else{
				Cursor.visible = true;
				rotation = Input.GetAxis("Horizontal") * rotationSpeed;
			}
			//MOVEMENT
			//Move_FNING - W, A, S, D Keys
			if (!info.IsName ("Sit") && !info.IsName("Victory")){
				float strafe = Input.GetAxis("Strafe") * speed;
				float translation = Input.GetAxis("Vertical") * speed;
				
				strafe *= Time.deltaTime;
				translation *= Time.deltaTime;
				rotation *= Time.deltaTime;
				transform.Translate(0, 0, translation);
				transform.Rotate(0, rotation, 0);

				if(!info.IsName("Sit") || !info.IsName("Victory")){
					if(Input.GetKey(KeyCode.A)){
         				transform.Translate(strafe, 0, 0);
						anim.SetBool("is_strafing_left", true);
					}
					else if(Input.GetKeyUp(KeyCode.A)){
						anim.SetBool("is_strafing_left", false);
					}
					if(Input.GetKey(KeyCode.D)){
         				transform.Translate(strafe, 0, 0);
						anim.SetBool("is_strafing_right", true);
					}
					else if(Input.GetKeyUp(KeyCode.D)){
						anim.SetBool("is_strafing_right", false);
					}
				}

				if(translation != 0){
					anim.SetBool("is_moving", true);
				}
				else{
					anim.SetBool("is_moving", false);
				}
			}

			if(!isWalking){
				speed = 2.0f;
			}

			if(isWalking){
				speed = 1.0f;
			}

			//JUMPING - Space Bar
			if(Input.GetButtonDown("Jump")){
				anim.SetBool("is_jumping", true);
			}
			else{
				anim.SetBool("is_jumping", false);
			}

			//WALKING - Toggle walk
			if(Input.GetKeyDown(KeyCode.Z)){
				isWalking = !isWalking;
				anim.SetBool("walk_toggle", isWalking);
			}

			//SWINGING LEFT AND RIGHT - Left Click
			if(Input.GetMouseButtonDown(0)){
				if(anim.GetBool("alternate_swing") == false){
					anim.SetBool("is_attacking01", true);
					if(!info.IsName("1HANDED-ATK1")){
						anim.SetBool("alternate_swing", true);
					}
				}
				else if(anim.GetBool("alternate_swing") == true){
					anim.SetBool("is_attacking02", true);
					if(!info.IsName("1HANDED-ATK2")){
						anim.SetBool("alternate_swing", false);
					}
				}
			}
			else{
				anim.SetBool("is_attacking01", false);
				anim.SetBool("is_attacking02", false);
			}

			//SPECIAL ATTACK 1 - Q Key
			if(Input.GetKeyDown(KeyCode.Q)){
				anim.SetBool("is_slamming", true);
			}
			else{
				anim.SetBool("is_slamming", false);
			}

			

			//EMOTES

			//SITTING - X Key
			if(Input.GetKeyDown(KeyCode.X)){
				isSitting = !isSitting;
				anim.SetBool("sit_toggle", isSitting);
			}

			//CHEERING - C Key
			if(Input.GetKeyDown(KeyCode.V)){
				anim.SetBool("is_cheering", true);
			}
			else{
				anim.SetBool("is_cheering", false);
			}
		}
	}
}
