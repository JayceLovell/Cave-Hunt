using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*

 *

 * Yueyang Sun - 300933625


 * Jayce Lovell - 300833478

 * Vincent Wright - 300928112

 *

 * COMP394-002 Practical Game Design - Cave Hunt

 */

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
    public static GameManager instance = null;


    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;
        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

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
