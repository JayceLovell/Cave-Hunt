using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*

 *

 * Yueyang Sun - 300933625

 * Jayce Lovell - 300833478

 * Vincent Wright - 300928112

 *

 * COMP394-002 Practical Game Design - Cave Hunt

 */
public class EndGameScript : MonoBehaviour {

    private GameManager _gameManager;

    public GameObject GameManager;
    public Text TxtMinerScore;
    public Text TxtGhostScore;

    // Use this for initialization
    void Start () {
        this._initialize();

        TxtGhostScore.text = "Score: " + _gameManager.Score[0];
        TxtMinerScore.text = "Score: " + _gameManager.Score[1];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void _initialize()
    {
        GameManager = GameObject.Find("GameManager");
        _gameManager = GameManager.GetComponent<GameManager>() as GameManager;
        TxtGhostScore = GameObject.Find("TxtGhostScore").GetComponent<Text>();
        TxtMinerScore = GameObject.Find("TxtMinerScore").GetComponent<Text>();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void PlayAgainButton()
    {
        _gameManager.Score[0] = 0;
        _gameManager.Score[1] = 0;

        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
