using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float moveSpeed;
    Animator anim;
    bool EnemyMoving;
    Vector2 lastMove;

    Vector3 luuPos;


    public Transform player;


    public GameObject khoiLua;

    bool flagAttack = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
  
        luuPos = player.position;

        EnemyMoving = true;
        if (Mathf.Abs(luuPos.x) > Mathf.Abs(luuPos.y))
        {
            if (luuPos.x > 0)
            {
                luuPos = new Vector3(1, 0, 0);
                lastMove = new Vector2(1, 0);

            }
            else
            {
                luuPos = new Vector3(-1, 0, 0);
                lastMove = new Vector2(-1, 0);
            }
        }
        if (Mathf.Abs(luuPos.x) < Mathf.Abs(luuPos.y))
        {
            if (luuPos.y > 0)
            {
                luuPos = new Vector3(0, 1, 0);
                lastMove = new Vector2(0, 1);

            }
            else
            {
                luuPos = new Vector3(0, -1, 0);
                lastMove = new Vector2(0, -1);
            }
        }



            anim.SetBool("Move", EnemyMoving);
            anim.SetFloat("MoveX", luuPos.x);
            anim.SetFloat("MoveY", luuPos.y);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);

        if (!EnemyMoving)
            return;
        transform.position = Vector3.Lerp(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
