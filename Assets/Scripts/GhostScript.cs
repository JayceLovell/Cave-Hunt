using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    private GameController _gameController;
    private GameManager _gameManager;
    private Rigidbody2D ghostRigidBody;
    private AudioSource ghostwhail;

    public float speed = 10.0f;

    void Awake()
    {
        ghostwhail = GetComponent<AudioSource>();
        ghostRigidBody = GetComponent<Rigidbody2D>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>() as GameController;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() as GameManager;
    }
    void Start()
    {
        ghostwhail.volume = _gameManager.Volume / 100f;
    }

    void FixedUpdate () {
        //movement
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        ghostRigidBody.velocity = movement * speed;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Miner"))
        {
            ghostwhail.Stop();
            ghostwhail.clip = (AudioClip)Resources.Load("SoundEffects/Behind");
            ghostwhail.Play();
            Destroy(other.gameObject);
            _gameController.GhostWin();
        }
    }
}
