using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    Text notification;
    bool waitForStart=false;
    InformationStorage information;
    Text rounds;

    void Start()
    {
        notification = GameObject.Find("Notification").GetComponent<Text>();
        rounds = GameObject.Find("Rounds").GetComponent<Text>();
        information = GameObject.Find("gameInfo").GetComponent<InformationStorage>();
    }

    public void StartBtn()
    {
        notification.text = "Waiting for other player to confirm";
        waitForStart = true;
    }
    public void OptionBtn()
    {
        StartCoroutine(ShiftMenu(700));
    }
    public void ApplyBtn()
    {
        information.rounds= (int)GameObject.Find("Slider").GetComponent<Slider>().value;
        BackBtn();
    }
    public void BackBtn()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value = information.rounds;
        displayRounds();
        StartCoroutine(ShiftMenu(-700));
    }
    public void displayRounds()
    {
        rounds.text = "Rounds: " + (int)GameObject.Find("Slider").GetComponent<Slider>().value;
    }
    private IEnumerator ShiftMenu(int _height)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _height);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    private void Update()
    {
        if(Input.GetButtonDown("MinerConfirm")&& waitForStart)
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

}
