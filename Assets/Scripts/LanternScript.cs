using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternScript : MonoBehaviour {

    private GameController _gameController;

    private void Awake()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>() as GameController;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Miner")){
            _gameController.LanternsCollected++;
            Destroy(this.gameObject);
        }
    }
}
