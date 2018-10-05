using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    Text notification;
    bool waitForStart=false;

    void Start()
    {
        notification = GameObject.Find("Notification").GetComponent<Text>();
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

    }
    public void BackBtn()
    {
        StartCoroutine(ShiftMenu(-700));
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
