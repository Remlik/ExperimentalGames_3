﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager instance;

    public float timer;
    public bool playing;
    public Text SPACE;

    private float childWinTime;
    private AudioManager am;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;

        childWinTime = Time.time + timer;
        am = AudioManager.instance;
        am.StopAll();
        am.Play("MetalSong");
	}
	
	// Update is called once per frame
	void Update () {
		if (playing)
        {
            if (Time.time > childWinTime) //Reset to a counter to gather the time for the UI
            {
                ChildWin();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SPACE.enabled = !SPACE.enabled;
        }
	}

    public void ChildWin()
    {
        Time.timeScale = 0;
        Debug.Log("Child Win!");
    }

    public void WindWin()
    {
        Time.timeScale = 0;
        Debug.Log("Nature Win!");
    }
}
