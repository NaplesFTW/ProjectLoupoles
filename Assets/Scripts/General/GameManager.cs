using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public Player player;


    public ChangeLevel changeLevel;
    // Use this for initialization
    void Start () {
        changeLevel = GetComponent<ChangeLevel>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void terminateGame()
    {
        Application.Quit();
    }
}
