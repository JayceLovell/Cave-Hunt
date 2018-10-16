using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerScript : MonoBehaviour {

    private GameController _gameController;
    private GameManager _gameManager;
    private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
    private Rigidbody2D minerRigidBody;

    public GameObject GameControllerObject;
    public GameObject GameManagerObject;
    public float speed = 10.0f;
    public float moveHorizontal;
    public float moveVertical;

    // Use this for initialization
    void Start () {
        this._initialize();
        
    }
    // PRIVATE METHODS
    /**
     * This method initializes variables and object when called
     */
    private void _initialize()
    {
        minerRigidBody = GetComponent<Rigidbody2D>();
        GameControllerObject = GameObject.Find("GameController");
        _gameController = GameControllerObject.GetComponent<GameController>() as GameController;

        GameManagerObject = GameObject.Find("GameManager");
        _gameManager = GameManagerObject.GetComponent<GameManager>() as GameManager;
    }

    // Update is called once per frame
    void FixedUpdate() {
        //_gameController.RestartGame();
        //Store the current horizontal input in the float moveHorizontal.
        moveHorizontal = Input.GetAxis("JoyStickHorizontal");

        //Store the current vertical input in the float moveVertical.
        moveVertical = Input.GetAxis("JoyStickVertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        minerRigidBody.velocity = movement * speed;
    }
}
