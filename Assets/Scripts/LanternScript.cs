using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternScript : MonoBehaviour {

    private GameController _gameController;

    public GameObject GameControllerObject;

    // Use this for initialization
    void Start () {
        _initialize();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void _initialize()
    {
        GameControllerObject = GameObject.Find("GameController");
        _gameController = GameControllerObject.GetComponent<GameController>() as GameController;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Miner")){
            _gameController.LanternsCollected++;
            Destroy(this.gameObject);
        }
    }
}
