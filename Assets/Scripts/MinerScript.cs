using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerScript : MonoBehaviour {

    private GameManager _gameManager;
    private Rigidbody2D minerRigidBody;
    private SpriteRenderer sprite;
    private Animator animator;

    new AudioSource audio;
    bool onMud = false;
    

    public float speed = 10.0f;
    public float moveHorizontal;
    public float moveVertical;

    void Awake()
    {
        minerRigidBody = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() as GameManager;
        audio = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Start() {
        audio.volume = _gameManager.Volume / 100f;
        audio.Play();
    }

    void FixedUpdate() {
       
            
        if(Input.GetButton("MinerHorizontal")|| Input.GetButton("MinerVertical"))
        {
            //keyboard input
            Vector3 keymovement = new Vector3(Input.GetAxis("MinerHorizontal"), Input.GetAxis("MinerVertical"));
            minerRigidBody.velocity = keymovement * speed;
        }
        else
        {
            //movement
            Vector2 joymovement = new Vector2(Input.GetAxis("JoyStickHorizontal"), Input.GetAxis("JoyStickVertical"));
            minerRigidBody.velocity = joymovement * speed;
        }

        if (speed == 10 && onMud)
        {
            audio.clip = (AudioClip)Resources.Load("SoundEffects/footstep");
            audio.Play();
            onMud = false;
            animator.SetBool("Slow", false);
        }
        if(speed !=10 && !onMud)
        {
            audio.clip = (AudioClip)Resources.Load("SoundEffects/footstepMud");
            audio.Play();
            onMud = true;
            animator.SetBool("Slow", true);
        }
        
        if (minerRigidBody.velocity.magnitude == 0)
        {
            audio.mute=true;
        }
        else if(audio.mute)
        {
            audio.mute = false;
        }
        if (minerRigidBody.velocity.x > 0)
            sprite.flipX = true;
        else
            sprite.flipX = false;

        if (minerRigidBody.velocity.magnitude > 0.1f)
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            audio.PlayOneShot((AudioClip)Resources.Load("SoundEffects/oof"), _gameManager.Volume / 100f);
        }
    }

}
