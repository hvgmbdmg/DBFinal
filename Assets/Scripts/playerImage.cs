using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerImage : MonoBehaviour {

    //public GameObject rabbit;
    public Sprite rabbitSet1;
    public Sprite rabbitSet2;
    public Sprite rabbitRun1;
    public Sprite rabbitRun2;
    public Sprite rabbitJump;

    float timer = 1f;
    float delay = 0.4f;


    // Use this for initialization
    void Start () {

        this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbitSet1;
        this.gameObject.GetComponent<SpriteRenderer>().size = Vector2.one;

    }
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;

        if (playerController.isRight)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }


        if( timer <= 0) {

            if (playerController.isMove)
            {
                if (playerController.isJump) {
                    //here is Jump;
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbitJump;
                    this.gameObject.GetComponent<SpriteRenderer>().size = Vector2.one;
                }
                else {
                    //here is run;
                    if (this.gameObject.GetComponent<SpriteRenderer>().sprite == rabbitRun1)
                    {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbitRun2;
                        this.gameObject.GetComponent<SpriteRenderer>().size = Vector2.one;
                    }
                    else {
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbitRun1;
                        this.gameObject.GetComponent<SpriteRenderer>().size = Vector2.one;
                    }
                }
            }
            else
            {
                if (this.gameObject.GetComponent<SpriteRenderer>().sprite == rabbitSet1)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbitSet2;
                    this.gameObject.GetComponent<SpriteRenderer>().size = Vector2.one;
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = rabbitSet1;
                    this.gameObject.GetComponent<SpriteRenderer>().size = Vector2.one;
                }
            }
            timer = delay;
        }//need change image end;
	}//Update end;
}
