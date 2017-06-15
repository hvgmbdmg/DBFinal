using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class systemControl : MonoBehaviour {
    public static bool isWin = false;
    public static int rankNumber = 0;
    public static int death = 0;
    public static int costTime = 0;
    public static int score = 0;

	// Use this for initialization
	void Start () {
		//playerController.deathNumber
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void test() {
        Debug.Log("why");
    }

    public void clickedChooseRankButton() {
        playerController.isWin = true;  //reset time;
        SceneManager.LoadScene("ChooseRankScene", LoadSceneMode.Single);
        //Application.LoadLevel("ChooseRankScene");
        //Application.loadedLevel(1);
    }

    public void clickedFirstRankButton() {
        SceneManager.LoadScene("BaseScene", LoadSceneMode.Single);
        //Application.LoadLevel("BaseScene");
    }

    public void clickedTitleButton() {
        Debug.Log("Return Title.");
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }

    public void clickedRankingButton() {
        Debug.Log("Ranking Button");
    }

    public void clickedAboutUsButton()
    {
        Debug.Log("About Us Button");
    }

    public void clickedLeaveButton()
    {
        Debug.Log("Leave Button");
    }


}
