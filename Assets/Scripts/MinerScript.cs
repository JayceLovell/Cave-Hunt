using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerScript : MonoBehaviour {

    private GameManager _gameManager;
    private Rigidbody2D minerRigidBody;
    AudioSource audio;
    bool onMud = false;
    

    public float speed = 10.0f;
    public float moveHorizontal;
    public float moveVertical;

    void Awake()
    {
        minerRigidBody = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() as GameManager;
        audio = GetComponent<AudioSource>();
    }


    void Start() {
        audio.volume = _gameManager.Volume / 100f;
        audio.Play();
    }

    void FixedUpdate() {
        //movement
        Vector2 joymovement = new Vector2(Input.GetAxis("JoyStickHorizontal"), Input.GetAxis("JoyStickVertical"));
        //keyboard input
        Vector2 keymovement = new Vector2(Input.GetAxis("MinerHorizontal"), Input.GetAxis("MinerVertical"));
        if (joymovement.magnitude == 0)
        {
            minerRigidBody.velocity = keymovement * speed;
        }
        else
        {
            minerRigidBody.velocity = joymovement * speed;
        }

        if (speed == 10 && onMud)
        {
            audio.clip = (AudioClip)Resources.Load("SoundEffects/footstep");
            audio.Play();
            onMud = false;
        }
        if(speed!=10 &&!onMud)
        {
            audio.clip = (AudioClip)Resources.Load("SoundEffects/footstepMud");
            audio.Play();
            onMud = true;
        }
        
        if (minerRigidBody.velocity.magnitude == 0)
        {
            audio.mute=true;
        }
        else if(audio.mute)
        {
            audio.mute = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            audio.PlayOneShot((AudioClip)Resources.Load("SoundEffects/oof"), _gameManager.Volume / 100f);
        }
    }

}
