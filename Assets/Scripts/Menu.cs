using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private int _rounds = 3;
    private bool _waitForStart = false;

    public float volume = 10;
    public int[] score = { 0, 0 };
    public int currentRoundLanternpieces = 0;
    public Text txtrounds;
    public Text notification;

    public int Rounds
    {
        get
        {
            return _rounds;
        }
        set
        {
            _rounds = value;
        }
    }

    public bool WaitForStart
    {
        get
        {
            return _waitForStart;
        }
        set
        {
            _waitForStart = value;
        }
    }


    void Start()
    {
        notification = GameObject.Find("Notification").GetComponent<Text>();
        txtrounds = GameObject.Find("TxtRounds").GetComponent<Text>();
    }
    public void StartBtn()
    {
        notification.text = "Waiting for other player to confirm";
        _waitForStart = true;
    }
    public void OptionBtn()
    {
        displayRounds();
        StartCoroutine(ShiftMenu(2000));
    }
    public void ApplyBtn()
    {
        _rounds= (int)GameObject.Find("Slider").GetComponent<Slider>().value;
        BackBtn();
    }
    public void BackBtn()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = _rounds;
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

    private void Update()
    {
        if (Input.GetButtonDown("MinerConfirm") && _waitForStart)
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        else if (Input.GetButtonDown("MinerConfirm"))
        {
            notification.text = "Waiting for other player to confirm";
            //play sound Text now
        }

    }

}
