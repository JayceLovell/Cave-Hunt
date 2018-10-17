using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerScript : MonoBehaviour {

    private GameController _gameController;
    private GameManager _gameManager;
    private Rigidbody2D minerRigidBody;

    public float speed = 10.0f;
    public float moveHorizontal;
    public float moveVertical;

    void Awake()
    {
        minerRigidBody = GetComponent<Rigidbody2D>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>() as GameController;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() as GameManager;
    }


    void Start () {
        GetComponent<AudioSource>().volume = _gameManager.Volume / 300f;

    }

    void FixedUpdate() {
        //movement
        Vector2 movement = new Vector2(Input.GetAxis("JoyStickHorizontal"), Input.GetAxis("JoyStickVertical"));
        minerRigidBody.velocity = movement * speed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            //playsound
        }
     }
}
