using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationStorage : MonoBehaviour {
    public int rounds = 0;
    public float volume = 1;
    public int[] score = { 0, 0 };
    public int currentRoundLanternpieces = 0;

	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
}
