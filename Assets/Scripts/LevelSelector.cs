﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour
{
    public Image levelDisplay;
    public Image levelNameDisplay;

    public Sprite[] levels;
    public Sprite[] names;
    public Sprite random;

    public int levelNumber;
    public int nameNumber;
    public int show = 0;
    public int RandomShow = 0;
    public bool chosenShown = false;

    public string[] levelNames;
    public string chosenLevel;

    //used to adjust time between showing each image
    public float waitTime = 0.5f;
    private float timer = 0.0f;
    public float maxWaitTime;
    public float minWaitTime;
    public float waitInterval;

    public bool levelChosen = false;
    private bool set = true;

    public Button nextLevel;
    public Button prevLevel;

    public Text instructions;

    // Start is called before the first frame update
    void Start()
    {
        levelChosen = false;

        //Control what is displayed on the image
        levelDisplay = GetComponent<Image>();
        //Debug.Log(levels.Length);

        //Immediately chooses the next level for random
        ChooseLevel();

        levelDisplay.sprite = levels[show];
        levelNameDisplay.sprite = names[show];

        //prevents players from using left and right arrow buttons on screen
        nextLevel.interactable = false;
        prevLevel.interactable = false;

        instructions.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        /*if(show == levels.Length)
        {
            //ChooseLevel();
            timer += Time.deltaTime;
            //Cycles between levels
            if (timer > waitTime)
            {
                RandomLevel();
                timer -= waitTime;
            }
        }*/

        //Allow players to navigate UI by only using their controllers
        for (int i = 0; i < ReInput.players.playerCount; i++)
        {
            if (Rewired.ReInput.players.GetPlayer(i).GetButtonDown("UIRight"))
            {
                CycleChoices();
            }
            if (Rewired.ReInput.players.GetPlayer(i).GetButtonDown("UILeft"))
            {
                CycleBackChoices();
            }
            if (Rewired.ReInput.players.GetPlayer(i).GetButtonDown("Back"))
            {
                ReturnToMainMenu("Main_Menu");
            }
        }

        if (PlayerSelect.S.TwoPlayersReady)
        {
            //enables users to select level once two players are selected
            DisplayChosen();

            /*if (Rewired.ReInput.players.GetPlayer(0).GetButtonDown("Submit"))
            {
                ActuallyStartLevel();
            }*/
        }
    }

    /*void FixedUpdate()
    {
        //stop doing this if leveCHosen/displayed
        if (!levelChosen)
        {
            //Does process if there are more than 1 level in the list
            if (levels.Length - 1 > 0)
            {
                //If the random level is not shown, then the levels will be displayed in rapid succession
                if (!chosenShown)
                {
                    RotateLevels();
                    //Displays the randomly chosen level after the min wait time is reached.
                    if (waitTime >= minWaitTime && show == levelNumber && PlayerSelect.S.bothPlayersReady)
                    {
                        DisplayChosen();
                    }
                }
            }
            //Displays the chosen level if there is one level in the list
            else
            {
                RotateLevels();
                if (PlayerSelect.S.bothPlayersReady)
                {
                    DisplayChosen();
                }
            }
        }

    }*/

    void ChooseLevel()
    {//Takes a random number from the levels array
        levelNumber = Random.Range(1, levels.Length);
        //Stores level name
        chosenLevel = levelNames[levelNumber];
    }

    public void CycleChoices()
    {
        //Cycles through levels in the array to be shown. Resets to show top level (0) once the display hits the bottom of the list
        if(show >= levels.Length-1)
        {
            show = 0;
        }
        else
        {
            show ++;
        }

        //Displays level if the show variable is in range of the number of levels
        if (show < levels.Length)
        {
            levelDisplay.sprite = levels[show];
            levelNameDisplay.sprite = names[show];

            if (show > 0)
            {
                chosenLevel = levelNames[show];
            }
            else if (show == 0)
            {
                ChooseLevel();
            }
        }
    }

    public void CycleBackChoices()
    {
        //Cycles through levels in the array to be shown. Resets to show top level (0) once the display hits the bottom of the list
        if (show <= 0)
        {
            show = levels.Length-1;
        }
        else
        {
            show--;
        }

        if (show < levels.Length)
        {
            levelDisplay.sprite = levels[show];
            levelNameDisplay.sprite = names[show];

            if (show > 0)
            {
                chosenLevel = levelNames[show];
            }
            else if (show == 0)
            {
                ChooseLevel();
            }
        }
    }

    void RotateLevels()
    {
        //displays level based on the order in the array
        levelDisplay.sprite = levels[RandomShow];
    }

    void DisplayChosen()
    {
        //print("Level chosen");

        instructions.text = "*Click on the left and right arrows or use the left and right d-pad to select a level";

        levelChosen = true;

        //Displays the chosen level after a certain amount of time. Can be changed to display level after all players are ready.
        //levelDisplay.sprite = levels[levelNumber];

        //Stops random level stuff in order to not slow down Unity
        chosenShown = true;

        if(!PlayerSelect.S.LevelStartBtn.interactable)
        {
            PlayerSelect.S.LevelStartBtn.interactable = set;
            EventSystem.current.SetSelectedGameObject(PlayerSelect.S.LevelStartBtn.gameObject, null);
        }
        else
        {
            nextLevel.interactable = true;
            prevLevel.interactable = true;
        }

        PlayerSelect.S.LevelStartBtnText.text = "Start Game";
    }

    public void ActuallyStartLevel()
    {
        PlayerSelect.S.allowControllerSelection = false;
        StartLevel(chosenLevel);
    }

    private void StartLevel (string level)
    {//Opens level based on which level was chosen in ChooseLevel
        if(SceneManager.GetSceneByName(level) == null)
        {
            print("No scene with this name");
            return;
        }
        //obselete
        //level = chosenLevel;
        //Debug.Log(level);
        InputManager.isUsingUI = false;
        SceneManager.LoadScene(level);
    }

    public void ReturnToMainMenu(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }

    /*public void nextLevel()
    {
        CycleChoices();

    }*/

   /* void RandomLevel()
    {
        if (RandomShow >= levels.Length-1)
        {
            RandomShow = 0;
        }
        else
        {
            RandomShow += 1;
        }
        RotateLevels();
    }*/
}
