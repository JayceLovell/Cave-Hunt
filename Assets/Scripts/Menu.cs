using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    
    private bool _waitForStartPlayerA = false;
    private bool _waitForStartPlayerB = false;
    private int _selection=0;

    public int Rounds;
    public float Volume;
    public int[] Score;
    public Text txtrounds;
    public Text notification;
    public GameManager gameManager;

    AudioSource audioSource;

    void Start()
    {
        notification = GameObject.Find("Notification").GetComponent<Text>();
        txtrounds = GameObject.Find("TxtRounds").GetComponent<Text>();
        audioSource = this.GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Rounds = gameManager.Rounds;
        Volume = gameManager.Volume;
        Score = gameManager.Score;
    }
    public void StartBtn()
    {
        notification.text = "Waiting for other player to confirm";
        _waitForStartPlayerA = true;
    }
    public void OptionBtn()
    {
        displayRounds();
        StartCoroutine(ShiftMenu(2000));
    }
    public void ApplyBtn()
    {
        Rounds= (int)GameObject.Find("Slider").GetComponent<Slider>().value;
        BackBtn();
    }
    public void BackBtn()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = Rounds;
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
        switch (_selection)
        {
            case 0:
                audioSource.PlayOneShot((AudioClip)Resources.Load("../voice/StartGame"), Volume/100);
                break;
            case 1:
                audioSource.PlayOneShot((AudioClip)Resources.Load("../voice/VolmeSetting"), Volume / 100);
                break;
        }
    }
    //check for keys
    private void Update()
    {
        if (_waitForStartPlayerA && _waitForStartPlayerB)
        {
            gameManager.Score = Score;
            gameManager.Volume = Volume;
            gameManager.Rounds = Rounds;
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        if (Input.GetAxis("MinerVer")>0.5f&&_selection>0)
        {
            _selection++;
            playSelectionSound();
        }
        else if (Input.GetAxis("MinerVer") < -0.5f && _selection < 1)
        {
            _selection--;
            playSelectionSound();
        }


        switch (_selection)
        {
            case 0:
                if (Input.GetButton("MinerConfirm"))
                {
                    _waitForStartPlayerB = true;
                    audioSource.PlayOneShot((AudioClip)Resources.Load("../voice/waitingStart"), Volume / 100);
                }
                break;
                //loudness
            case 1:
                if (Input.GetAxis("MinerHor") > 0.5f && Volume < 90)
                {
                    Volume += 10;
                    string volSource = "../voice/" + Volume + "p";
                    audioSource.PlayOneShot((AudioClip)Resources.Load(volSource), Volume / 100);
                }
                else if (Input.GetAxis("MinerHor") < -0.5f && Volume > 10) 
                {
                    Volume -= 10;
                    string volSource = "../voice/"+Volume + "p";
                    audioSource.PlayOneShot((AudioClip)Resources.Load(volSource), Volume / 100);
                }
                break;
        }

  
    }

}
