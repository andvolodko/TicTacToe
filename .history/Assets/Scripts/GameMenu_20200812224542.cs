﻿using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour
{
    GameObject[] menuObjects;
	GameObject newGameButton;
    void Start()
    {
        menuObjects = GameObject.FindGameObjectsWithTag("SelectMode");
		newGameButton = GameObject.Find("NewGameButton");
        switchSelectMenu(true);
    }

    void PlayerVsPlayer()
    {
        switchSelectMenu(false);
    }

    void PlayerVsAI()
    {
        switchSelectMenu(false);
    }

    void OnlineGame()
    {
        switchSelectMenu(false);
    }

    void NewGame()
    {
        switchSelectMenu(true);
    }

    void switchSelectMenu(bool on)
    {
        foreach (GameObject obj in menuObjects)
        {
            if (on)
                Utils.showGameObject(obj);
            else
                Utils.hideGameObject(obj);
            /*
                if (obj.GetComponent<MeshRenderer>()) {
                        if (on)
                                obj.GetComponent<MeshRenderer>().enabled = true;
                        else
                                obj.GetComponent<MeshRenderer>().enabled = false;
                } 
                if (obj.GetComponent<Collider>()) {
                        if (on)
                                obj.GetComponent<Collider>().enabled = true;
                        else
                                obj.GetComponent<Collider>().enabled = false;
                } 
                */
        }
        if (on)
            Utils.hideGameObject(newGameButton);
        else
            Utils.showGameObject(newGameButton);

    }
}
