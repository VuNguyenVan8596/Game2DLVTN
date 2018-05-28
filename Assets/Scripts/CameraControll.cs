using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public Transform transformTargetFollow;
    Vector3 targetPos;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if ((transformTargetFollow.position.x < 0 || transformTargetFollow.position.x > 15.5f) || (transformTargetFollow.position.y < 0 || transformTargetFollow.position.y > 9.7f))
            return;
        targetPos = new Vector3(transformTargetFollow.position.x, transformTargetFollow.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed*Time.deltaTime);
	}
}
