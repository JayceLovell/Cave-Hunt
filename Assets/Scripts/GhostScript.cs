using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    private GameController _gameController;
    private GameManager _gameManager;
    private Rigidbody2D _ghostRigidBody;
    private AudioSource _ghostwhail;
    private Vector3 _defaultFog;
    private Vector3 _maxFog = new Vector3(3.631446f, 2.821614f, 0f);

    public float Speed = 10.0f;
    public GameObject FogOfWar;

    void Awake()
    {
        _ghostwhail = GetComponent<AudioSource>();
        _ghostRigidBody = GetComponent<Rigidbody2D>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>() as GameController;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() as GameManager;
        FogOfWar = GameObject.Find("GhostVision");
    }
    void Start()
    {
        _ghostwhail.volume = _gameManager.Volume / 100f;
        _defaultFog = FogOfWar.transform.localScale;
    }

    void FixedUpdate () {
        //movement
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _ghostRigidBody.velocity = movement * Speed;
        if (_ghostRigidBody.IsSleeping())
        {
            if (FogOfWar.transform.localScale.x >= _maxFog.x)
            {
                //Stop increasing
            }
            else
            {
                FogOfWar.transform.localScale += new Vector3(0.001f, 0.001f, 0);
            }
        }
        else
        {
            if (FogOfWar.transform.localScale.x <= _defaultFog.x)
            {
                Debug.Log("Stop decreasing");
            }
            else
            {
                FogOfWar.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Miner"))
        {
            _ghostwhail.Stop();
            _ghostwhail.clip = (AudioClip)Resources.Load("SoundEffects/Behind");
            _ghostwhail.Play();
            Destroy(other.gameObject);
            _gameController.GhostWin();
        }
    }
}
