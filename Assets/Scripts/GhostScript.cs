using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour {

    private GameController _gameController;
    private GameManager _gameManager;
    private Rigidbody2D _ghostRigidBody;
    private AudioSource _ghostwhail;
    private Vector3 _minimumFod = new Vector3(1.0506f, 1.0403f,0f);
    private Vector3 _maxFog = new Vector3(5.772128f, 3.003333f, 0f);
    private SpriteRenderer sprite;
    private Animator animator;

    public float Speed = 10.0f;
    public GameObject FogOfWar;

    void Awake()
    {
        _ghostwhail = GetComponent<AudioSource>();
        _ghostRigidBody = GetComponent<Rigidbody2D>();
        _gameController = GameObject.Find("GameController").GetComponent<GameController>() as GameController;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() as GameManager;
        FogOfWar = GameObject.Find("GhostVision");
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        _ghostwhail.volume = _gameManager.Volume / 100f;
        _minimumFod = FogOfWar.transform.localScale;
    }

    void FixedUpdate () {
        //movement
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _ghostRigidBody.velocity = movement * Speed;
        if (_ghostRigidBody.IsSleeping())
        {
            if (FogOfWar.transform.localScale.x >= _maxFog.x && FogOfWar.transform.localScale.y >= _maxFog.y)
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
            if (FogOfWar.transform.localScale.x <= _minimumFod.x && FogOfWar.transform.localScale.y <= _minimumFod.y)
            {
                //Stop decreasing);
            }
            else
            {
                FogOfWar.transform.localScale -= new Vector3(0.01f, 0.01f, 0);
            }
        }
        if (_ghostRigidBody.velocity.x > 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;
        if (_ghostRigidBody.velocity.magnitude > 0.1f)
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);

    }
    public void Refresh()
    {
        this.transform.position = new Vector3(0f, 0f, 0f);
        _ghostwhail.Stop();
        _ghostwhail.clip = (AudioClip)Resources.Load("SoundEffects/wailingCry");
        _ghostwhail.Play();
    }
    IEnumerator Wait()
    {
        Debug.Log("pause");
        yield return new WaitForSecondsRealtime(3);
        _gameController.GhostWin();
        Debug.Log("unpause");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Miner"))
        {
            _ghostwhail.Stop();
            _ghostwhail.clip = (AudioClip)Resources.Load("SoundEffects/Behind");
            _ghostwhail.Play();

            StartCoroutine(Wait()); 
        }
    }
}
