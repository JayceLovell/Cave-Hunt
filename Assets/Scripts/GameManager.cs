using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private int _rounds;
    private float _volume = 50;
    private int[] _score = { 0, 0 };
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
    public float Volume
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
    public int[] Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }
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
    }
}
