using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Button[] buttons;

    int Rounds=3;
    int Volume=50;
    Text Txtrounds;
    Text Notification;
    Text TxtVolume;
    bool _waitForStartPlayerA = false;
    bool _waitForStartPlayerB = false;
    int _selection = 0;
    GameManager _gameManager;
    AudioSource audioSource;

    private void Awake()
    {
        Notification = GameObject.Find("Notification").GetComponent<Text>();
        Txtrounds = GameObject.Find("TxtRounds").GetComponent<Text>();
        TxtVolume = GameObject.Find("TxtVolume").GetComponent<Text>();
        audioSource = this.GetComponent<AudioSource>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() as GameManager;
    }
    void Start()
    {

        Rounds = _gameManager.Rounds;
        Volume = _gameManager.Volume;

        GameObject.Find("Slider").GetComponent<Slider>().value = Rounds;
        GameObject.Find("VolumeSlider").GetComponent<Slider>().value = Volume;
    }
    public void StartBtn()
    {
        if(!_waitForStartPlayerA)playSound("voice/startPromp");
        Notification.text = "Waiting for players to start";
        _waitForStartPlayerA = true;
    }
    public void OptionBtn()
    {
        DisplayRounds();
        DisplayVolume();
        StartCoroutine(ShiftMenu(1000));
        buttons[1].enabled = false;
        buttons[2].enabled = true;
        buttons[3].enabled = true;
    }
    public void ApplyBtn()
    {
        Rounds= (int)GameObject.Find("Slider").GetComponent<Slider>().value;
        Volume = (int)GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
        BackBtn();
    }
    public void BackBtn()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = Rounds;
        GameObject.Find("VolumeSlider").GetComponent<Slider>().value=Volume;
        DisplayRounds();
        DisplayVolume();
        StartCoroutine(ShiftMenu(-1000));
        buttons[1].enabled = true;
        buttons[2].enabled = false;
        buttons[3].enabled = false;
    }
    public void DisplayRounds()
    {
        Txtrounds.text = "Rounds: " + (int)GameObject.Find("Slider").GetComponent<Slider>().value;
    }
    
    public void DisplayVolume()
    {
        TxtVolume.text = "Volume: " + (int)GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
    }
    
    private IEnumerator ShiftMenu(int _height)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _height);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
    private void playSound(string x)
    {
        audioSource.Stop();
        audioSource.clip = (AudioClip)Resources.Load(x);
        audioSource.Play();
    }
    //check for keys
    private void Update()
    {
        if (_waitForStartPlayerA && _waitForStartPlayerB)
        {
            _gameManager.Volume = Volume;
            _gameManager.Rounds = Rounds;
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        if (Input.GetAxis("JoyStickVertical") > 0&& _selection!=0)
        {
            _selection=0;
            playSound("voice/start");
        }
        else if (Input.GetAxis("JoyStickVertical") < 0&& _selection != 1)
        {
            _selection=1;
            playSound("voice/volume");
        }   


        switch (_selection)
        {
            case 0:
                if (Input.GetButton("JoyPadSubmit"))
                {
                    _waitForStartPlayerB = true;
                    Notification.text = "Waiting for players to start";
                    audioSource.clip = (AudioClip)Resources.Load("voice/start");
                    audioSource.Play();
                }
                break;
            case 1:
                if (Input.GetAxis("JoyStickHorizontal") != 0)
                {
                    Volume += (int)Input.GetAxis("JoyStickHorizontal");
                    if (Volume > 100) Volume = 100;
                    if (Volume < 0) Volume = 0;
                    GameObject.Find("VolumeSlider").GetComponent<Slider>().value = Volume;
                    DisplayVolume();
                    audioSource.volume = Volume/100f;
                    playSound("voice/loudnessCheck");
                }
                break;
        }

  
    }

}
