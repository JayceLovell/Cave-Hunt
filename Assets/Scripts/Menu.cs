using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    
    private bool _waitForStartPlayerA = false;
    private bool _waitForStartPlayerB = false;
    private int _selection=0;
    private GameManager _gameManager;

    public int Rounds;
    public int Volume;
    public Text Txtrounds;
    public Text Notification;
    public Text TxtVolume;
    public GameObject gameManangerObject;
    public Slider VolumeSlider;

    AudioSource audioSource;

    void Start()
    {
        Notification = GameObject.Find("Notification").GetComponent<Text>();
        Txtrounds = GameObject.Find("TxtRounds").GetComponent<Text>();
        TxtVolume = GameObject.Find("TxtVolume").GetComponent<Text>();
        VolumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        audioSource = this.GetComponent<AudioSource>();

        gameManangerObject = GameObject.Find("GameManager");
        _gameManager = gameManangerObject.GetComponent<GameManager>() as GameManager;

        Rounds = _gameManager.Rounds;
        Volume = _gameManager.Volume;

        GameObject.Find("Slider").GetComponent<Slider>().value = Rounds;
        VolumeSlider.value = Volume;
    }
    public void StartBtn()
    {
        Notification.text = "Waiting for other player to confirm";
        _waitForStartPlayerA = true;
    }
    public void OptionBtn()
    {
        DisplayRounds();
        DisplayVolume();
        StartCoroutine(ShiftMenu(2000));
    }
    public void ApplyBtn()
    {
        Rounds= (int)GameObject.Find("Slider").GetComponent<Slider>().value;
        Volume = (int)VolumeSlider.GetComponent<Slider>().value;
        BackBtn();
    }
    public void BackBtn()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = Rounds;
        GameObject.Find("VolumeSlider").GetComponent<Slider>().value=Volume;
        DisplayRounds();
        StartCoroutine(ShiftMenu(-2000));
    }
    public void DisplayRounds()
    {
        Txtrounds.text = "Rounds: " + (int)GameObject.Find("Slider").GetComponent<Slider>().value;
    }
    public void DisplayVolume()
    {
        //Unkown error here
        TxtVolume.text = "Volume: " + (int)VolumeSlider.GetComponent<Slider>().value;
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
           // _gameManager.Score = Score;
            _gameManager.Volume = Volume;
            _gameManager.Rounds = Rounds;

            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        if (Input.GetAxis("JoyStickVertical") > 0.5f&&_selection>0)
        {
            _selection++;
            playSelectionSound();
        }
        else if (Input.GetAxis("JoyStickVertical") < -0.5f && _selection < 1)
        {
            _selection--;
            playSelectionSound();
        }


        switch (_selection)
        {
            case 0:
                if (Input.GetButton("JoyPadSubmit"))
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
