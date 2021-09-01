using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
   public Joystick joystick;
   public CharacterController controller;
   
   public float speed;
   public float gravity;
   
   Vector3 moveDirection;
   
   void Start(){
	   
   }
   
   void Update(){
	   
	   Vector2 direction = joystick.direction;
	   
	   if(controller.isGrounded){
            moveDirection = new Vector3(direction.x, 0);
			
			Quaternion targetRotation = moveDirection != Vector3.zero ? Quaternion.LookRotation(moveDirection) : transform.rotation;
			transform.rotation = targetRotation;
	
            moveDirection = moveDirection * speed;
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
   }
}
