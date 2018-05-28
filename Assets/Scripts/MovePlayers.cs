using UnityEngine;
using System.Collections;

public class MovePlayers : MonoBehaviour {

	public float moveSpeed;
	public VJHandler jsMovement;
	private Vector3 direction;
    Animator anim;
    bool playerMoving;
    Vector2 lastMove;
    public GameObject ThanhKiem;

    bool Attacking = false;
    public float timeAttack;
    private float countdownTimeAttack;


    private void Awake()
    {
        ThanhKiem.SetActive(false);
    }

    void Update () {
		


		direction = jsMovement.InputDirection; //InputDirection can be used as per the need of your project
        playerMoving = false;
        if (direction.magnitude != 0)
        {

            if (!ThanhKiem.activeSelf)
                ThanhKiem.SetActive(true);

            transform.position += direction * Time.deltaTime * moveSpeed;
            playerMoving = true;
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    direction = new Vector3(1, 0, 0);
                    lastMove = new Vector2(1, 0);

                }
                else
                {
                    direction = new Vector3(-1, 0, 0);
                    lastMove = new Vector2(-1, 0);
                }
            }
            if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
            {
                if (direction.y > 0)
                {
                    direction = new Vector3(0, 1, 0);
                    lastMove = new Vector2(0, 1);

                }
                else
                {
                    direction = new Vector3(0, -1, 0);
                    lastMove = new Vector2(0, -1);
                }
            }

        }

        if (Attacking)
        {
            if (countdownTimeAttack > 0)
                countdownTimeAttack -= Time.deltaTime;
            else
            {
                Attacking = false;
                anim.SetBool("Attack", Attacking);
            }
                
        }

        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("MoveX", direction.x);
        anim.SetFloat("MoveY", direction.y);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);




    }	
	
	void Start(){

        //Initialization of boundaries
        //xMax = Screen.width - 50; // I used 50 because the size of player is 100*100
        //xMin = 50; 
        //yMax = Screen.height - 50;
        //yMin = 50;

        anim = GetComponent<Animator>();
	}


    public void ButtonAttackClick()
    {
        Attacking = true;
        countdownTimeAttack = timeAttack;
        anim.SetBool("Attack", Attacking);
    }
}