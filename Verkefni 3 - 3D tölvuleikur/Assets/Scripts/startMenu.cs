using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class startMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
	public void goToStartMenu(){  
		SceneManager.LoadScene("startScene");
	}   
	public void gotToHowToPlayMenu(){
		SceneManager.LoadScene("howtoScene");
	}
    public void playGame()
    {
        SceneManager.LoadScene("gameScene");
    }
    public void quitGame()
    {
    	Application.Quit();
    }
}
