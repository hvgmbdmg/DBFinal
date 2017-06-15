using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.
using System.IO.Ports;
//using MySQLDriverCS;


public class playerController : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float pushPower = 2.0F;
    public static int deathNumber = 0;
    public Text deathText;
    public Text gameTimeText;
    public static float timeNumber;
    string WT;
    public static bool isWin = true;
    public static float startTime;

    public static bool isMove = false;
    public static bool isJump = false;
    public static bool isRight = true;

    //SerialPort sp = new SerialPort("COM3",9600);

    /*

int threshold = 123; //Change this value if you want change the sensibility of sensor
int val;
void setup()
{
    Serial.begin(9600);
}
void loop()
{
    val = analogRead(A0); // Reads the value from the Analog PIN A0
    Serial.println(val);
    delay(90);
}*/


    // Use this for initialization
    void Start()
    {
        //sp.Open();
        //sp.ReadTimeout = 1;
        if (isWin) {
            startTime = Time.time;
            isWin = false;
            deathNumber = 0;
        }
            
        deathText.text = "死亡次數：" + deathNumber;
        timeNumber = Time.time - startTime;
        //Debug.Log("Time.time: "+Time.time);
        gameTimeText.text = "遊戲時間：" + Mathf.Round(timeNumber);

    }

    // Update is called once per frame
    void Update()
    {
        

        /*
        try
        {
            WT = sp.ReadLine();
            int result = int.Parse(WT);
            if( result >30 )
                Debug.Log("ya!!!!!!!!!");
        }
        catch (System.Exception)
        {
        }
        */

        if ( isWin == false ) {
            timeNumber = Time.time - startTime;
            gameTimeText.text =  "遊戲時間：" +Mathf.Round(timeNumber);
        }

        

        CharacterController controller = GetComponent<CharacterController>();
        //controller.
        if (controller.isGrounded)
        {
            isJump = false;
            //我们着地了，所以直接通过轴重新计算moveDirection。

            //Only allow x-axis move
            //x should between 0 and 1
            //when we get sound it should add 0.1 until 1.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            if (moveDirection.x != 0)
            {
                isMove = true;
                if (moveDirection.x > 0)
                {
                    isRight = true;
                }
                else {
                    isRight = false;
                }
            }

            else {
                isMove = false;
            }
            //Debug.Log(moveDirection);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            /*
            try
            {
                WT = sp.ReadLine();
                int result = int.Parse(WT);
                if (result > 10) {
                    moveDirection.y = jumpSpeed;
                    isMove = true;
                    isJump = true;
                    result = 0;
                }
                    //Debug.Log("ya!!!!!!!!!");
            }
            catch (System.Exception)
            {
            }*/
            
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                isMove = true;
                isJump = true;
            }
                
            //if (Input.GetKey(KeyCode.O))
            //    moveDirection.y = jumpSpeed;
        }

        //about gravity
        moveDirection.y -= gravity * Time.deltaTime;

        //moveDirection.z = 0;
        controller.Move(moveDirection * Time.deltaTime);
        //}

    }

    //public float pushPower = 2.0F;
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (hit.transform.tag == "EnemyTag" || hit.transform.tag == "DeathTag")
        {
            Debug.Log("Death!");
            deathNumber++;
            SceneManager.LoadScene("BaseScene", LoadSceneMode.Single);
            //Application.LoadLevel("BaseScene");
        }
        else if(hit.transform.tag == "WinTag" && isWin == false){
            Debug.Log("Win");
            isWin = true;
            SceneManager.LoadScene("WinScene", LoadSceneMode.Additive);
            //Application.LoadLevel("WinScene");
            
        }
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }


}
