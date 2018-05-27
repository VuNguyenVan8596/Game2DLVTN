using UnityEngine;
using System.Collections;

public class MovePlayers : MonoBehaviour {

	public float moveSpeed;
	public VJHandler jsMovement;
	private Vector3 direction;
    Animator anim;
	
	void Update () {
		
		direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project


        Debug.Log(direction);

		if(direction.magnitude != 0){

            transform.position += direction * Time.deltaTime * moveSpeed;
		}


        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
    }	
	
	void Start(){

        //Initialization of boundaries
        //xMax = Screen.width - 50; // I used 50 because the size of player is 100*100
        //xMin = 50; 
        //yMax = Screen.height - 50;
        //yMin = 50;

        anim = GetComponent<Animator>();
	}
}