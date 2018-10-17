using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    private int _rounds;
    private int _currentround=1;
    private GameObject[] _lanternPieces = new GameObject[3];
    private GameObject _miner;
    private GameObject _mud;
    private GameManager _gameManager;
    private int _ghostWin;
    private int _minerWin;

    public GameObject[] MinerSpawns = new GameObject[8];
    public GameObject[] MudSpawns = new GameObject[3];
    public GameObject[] LanternSpawns = new GameObject[3];
    public GameObject GameManager;
    public Text TxtRounds;
    public GameObject Ghost;
    public GameObject Miner;
    public GameObject Mud;
    public GameObject[] LanternPieces = new GameObject[3];

    void Start()
    {
        this._initialize();
        StartSpawn();
    }

    private void _initialize()
    {
        GameManager = GameObject.Find("GameManager");
        _gameManager = GameManager.GetComponent<GameManager>() as GameManager;
        _rounds = _gameManager.Rounds;
        TxtRounds.text = "Round: " + _currentround;
        _ghostWin = _gameManager.Score[0];
        _minerWin = _gameManager.Score[1];
    }

    void Update()
    {
        if(_ghostWin>(_rounds/2))
        {
            //Implement WInner here
        }
        else if(_minerWin>(_rounds/2))
        {
            //Miner Win
        }
        else if(_currentround==_rounds)
        {
            //No Wnner
            GameEnd();
        }

    }

    void StartSpawn()//spawn the player, mud and lantern pieces at predefined locations
    {
        _miner = (GameObject)Instantiate(Miner, MinerSpawns[Random.Range(0, MinerSpawns.Length)].transform.position, Quaternion.identity);
        _mud = (GameObject)Instantiate(Mud, MudSpawns[Random.Range(0, MudSpawns.Length)].transform.position, Quaternion.identity);
        int[] lanternPos = new int[3];
        /*do
        {
            lanternPos[0] = Random.Range(0, lanternPieces.Length);
            lanternPos[1] = Random.Range(0, lanternPieces.Length);
            lanternPos[2] = Random.Range(0, lanternPieces.Length);
        } while ((lanternPos[0] == lanternPos[1]) || (lanternPos[0] == lanternPos[2]) || (lanternPos[1] == lanternPos[2]));
        */
        _lanternPieces[0] = (GameObject)Instantiate(LanternPieces[0], LanternSpawns[0].transform.position, Quaternion.identity);
        _lanternPieces[1] = (GameObject)Instantiate(LanternPieces[1], LanternSpawns[1].transform.position, Quaternion.identity);
        _lanternPieces[2] = (GameObject)Instantiate(LanternPieces[2], LanternSpawns[2].transform.position, Quaternion.identity);
    }
    /*
    void PlayerInput()
    {
        ghost.GetComponent<GhostScript>.inputVec = new Vector2(Input.GetAxisRaw("GhostHor"), Input.GetAxisRaw("GhostVer")).normalized;
        miner.GetComponent<MinerScript>.inputVec = new Vector2(Input.GetAxisRaw("MinerHor"), Input.GetAxisRaw("MinerVer")).normalized;
        if (Input.GetMouseButton(0))
        {
            ghost.GetComponent<GhostScript>.mouseVec= Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,0));
        }
    }
    */
    public void RestartGame()
    {
        StartSpawn();
        _currentround++;
    }
    public void GhostWin()
    {
        _ghostWin++;
        RestartGame();
    }
    public void MinerWin()
    {
        _minerWin++;
        RestartGame();
    }
    public void GameEnd()
    {

    }
}
