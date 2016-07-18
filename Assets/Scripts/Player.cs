using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    float moveSpeed = 0.08f;
    
    bool canMove = false;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canMove) {
            float leftRight = 0f;
            float upDown = 0f;

            if (!(Mathf.Abs(upDown) > 0f)) {
                leftRight = Input.GetAxis("Horizontal");
            }
            
            if (!(Mathf.Abs(leftRight) > 0f)) {
                upDown = Input.GetAxis("Vertical");
            }

            anim.SetFloat("leftRight", (leftRight));
            //anim.SetFloat("right", Mathf.Abs(leftRight));
            anim.SetFloat("upDown", (upDown));
           // anim.SetFloat("down", Mathf.Abs(upDown));

            if (leftRight < -0.5f)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x - moveSpeed, gameObject.transform.position.y);
                
                
                
            }
            else if (leftRight > 0f)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x + moveSpeed, gameObject.transform.position.y);
                
            }

            else if (upDown > 0f)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + moveSpeed);
                
            }
            else if (upDown < 0f)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - moveSpeed);
                
            }
        }

	}

    public void SetCanMove(bool val) {
        canMove = val;
    }

}
