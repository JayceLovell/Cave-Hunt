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
public class LanternScript : MonoBehaviour {

    private GameController _gameController;

    private void Awake()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>() as GameController;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Miner")){
            _gameController.GotLantern();
            Instantiate((GameObject)Resources.Load("ding"), this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
