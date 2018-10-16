using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    private GameObject _camera;
    private Vector2 _newPosition = new Vector2(0.0f, 0.0f);
    private Rigidbody2D ghostRigidBody;

    public AudioSource ghostwhail;
    public float speed=10.0f;
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
        this._camera = GameObject.FindWithTag("MainCamera");
        ghostRigidBody = GetComponent<Rigidbody2D>();
    }

        // Update is called once per frame
    void FixedUpdate () {

            //Store the current horizontal input in the float moveHorizontal.
            moveHorizontal = Input.GetAxis("Horizontal");

            //Store the current vertical input in the float moveVertical.
            moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        ghostRigidBody.velocity = movement * speed;
    }
 }
