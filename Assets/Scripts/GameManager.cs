using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    private int _rounds = 3;
    private int _volume = 50;
    public int[] Score = new int[2];
    private int _currentRoundLanternpieces;

    public int Rounds
    {
        get
        {
            return _rounds;
        }
        set
        {
            _rounds = value;
        }
    }
    public int Volume
    {
        get
        {
            return _volume;
        }
        set
        {
            _volume = value;
        }
    }
    /*public int[] Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }*/
    public int CurrentRoundLanternpieces
    {
        get
        {
            return _currentRoundLanternpieces;
        }
        set
        {
            _currentRoundLanternpieces = value;
        }
    }


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        initialization();
    }
    private void initialization()
    {
        Score[0] = 0;
        Score[1] = 0;
        Debug.Log("Game Manager Loaded");
    }
}
