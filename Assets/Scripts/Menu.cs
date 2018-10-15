using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    
    private bool waitForStartPlayerA = false;
    private bool waitForStartPlayerB = false;
    private int selection=0;
    public int rounds = 3;
    public float volume = 50;
    public int[] score = { 0, 0 };
    public int currentRoundLanternpieces = 0;
    public Text txtrounds;
    public Text notification;
    AudioSource audioSource;

    void Start()
    {
        notification = GameObject.Find("Notification").GetComponent<Text>();
        txtrounds = GameObject.Find("TxtRounds").GetComponent<Text>();
        audioSource = this.GetComponent<AudioSource>();
    }
    public void StartBtn()
    {
        notification.text = "Waiting for other player to confirm";
        waitForStartPlayerA = true;
    }
    public void OptionBtn()
    {
        displayRounds();
        StartCoroutine(ShiftMenu(2000));
    }
    public void ApplyBtn()
    {
        rounds= (int)GameObject.Find("Slider").GetComponent<Slider>().value;
        BackBtn();
    }
    public void BackBtn()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = rounds;
        displayRounds();
        StartCoroutine(ShiftMenu(-2000));
    }
    public void displayRounds()
    {
        txtrounds.text = "Rounds: " + (int)GameObject.Find("Slider").GetComponent<Slider>().value;
    }
    private IEnumerator ShiftMenu(int _height)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _height);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    private void playSelectionSound()
    {
        switch (selection)
        {
            case 0:
                audioSource.PlayOneShot((AudioClip)Resources.Load("../voice/StartGame"), volume/100);
                break;
            case 1:
                audioSource.PlayOneShot((AudioClip)Resources.Load("../voice/VolmeSetting"), volume / 100);
                break;
        }
    }
    //check for keys
    private void Update()
    {
        if (waitForStartPlayerA && waitForStartPlayerB)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        if (Input.GetAxis("MinerVer")>0.5f&&selection>0)
        {
            selection++;
            playSelectionSound();
        }
        else if (Input.GetAxis("MinerVer") < -0.5f && selection < 1)
        {
            selection--;
            playSelectionSound();
        }


        switch (selection)
        {
            case 0:
                if (Input.GetButton("MinerConfirm"))
                {
                    waitForStartPlayerB = true;
                    audioSource.PlayOneShot((AudioClip)Resources.Load("../voice/waitingStart"), volume / 100);
                }
                break;
                //loudness
            case 1:
                if (Input.GetAxis("MinerHor") > 0.5f && volume < 90)
                {
                    volume += 10;
                    string volSource = "../voice/" + volume + "p";
                    audioSource.PlayOneShot((AudioClip)Resources.Load(volSource), volume / 100);
                }
                else if (Input.GetAxis("MinerHor") < -0.5f && volume > 10) 
                {
                    volume -= 10;
                    string volSource = "../voice/"+volume + "p";
                    audioSource.PlayOneShot((AudioClip)Resources.Load(volSource), volume / 100);
                }
                break;
        }

  
    }

}
