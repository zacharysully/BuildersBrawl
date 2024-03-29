﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Rewired;

public class Pause : MonoBehaviour
{   //2 buttons, resume & exit to main menu
    //public Button pause;
    //public Button exitToMenu;

    public static Pause S;
    public GameObject pauseMenu;
    //private GameObject eventSystem;
    private GameObject resumeButton;

    private void Awake()
    {
        S = this;
    }

    private void Start()
    {
        //S = this;
        //eventSystem = GameObject.Find("EventSystem");
        resumeButton = GameObject.Find("ResumeButton");

        S.pauseMenu = this.gameObject;
        S.pauseMenu.SetActive(false);
    }

    private void Update()
    {
        //if (ReInput.players.GetPlayer(i).GetButtonDown("Submit")
    }

    //have tom run the pausegame function when a player presses start
    //change input from Default to UI in the same spot
    public void PauseGame()
    {
        //Debug.Log("Pause - PauseGame");

        //turn on pause menu
        S.pauseMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(resumeButton, null);
        InputManager.isUsingUI = true;

        //change time scale
        Time.timeScale = 0;

    }

    public void Resume()
    {
        //change timescale back to 100%
        Time.timeScale = 1;

        S.pauseMenu.SetActive(false);
        
        //set the controller maps to default
        InputManager.isUsingUI = false;
        

    }

    public void ExitToMenu()
    {
        InputManager.isUsingUI = true;
        SceneManager.LoadScene("Main_Menu");

        //need to reset playerselect
        //rounds = 0
        //players = 0
        //

    }
}
