using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    private int _rounds;
    private int _currentround=1;
    private GameObject[] _lanternPieces = new GameObject[3];
    private GameObject _miner;
    private GameObject _mud;
    private GameManager _gameManager;
    private MinerScript _playerMiner;
    private int _ghostWin;
    private int _minerWin;

<<<<<<< HEAD
<<<<<<< HEAD
    public GameObject[] SpawnLocations = new GameObject[11];
    public GameObject GameManager;
=======
    public GameObject[] MinerSpawns;
    public GameObject[] MudSpawns;
    public GameObject[] LanternSpawns;
>>>>>>> master
=======
    public GameObject[] MinerSpawns = new GameObject[8];
    public GameObject[] MudSpawns = new GameObject[3];
    public GameObject[] LanternSpawns = new GameObject[3];
    public GameObject GameManager;
>>>>>>> parent of 0292850... Merge pull request #28 from JayceLovell/micheal
    public Text TxtRounds;
    public GameObject Ghost;
    public GameObject Miner;
    public GameObject Mud;
    public GameObject[] LanternPieces = new GameObject[3];
    public int LanternsCollected;

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
        LanternsCollected = 0;
    }

    void Update()
    {
        _gameManager.Score[0] = _ghostWin;
        _gameManager.Score[1] = _minerWin;
        if (_ghostWin>(_rounds/2))
        {
            SceneManager.LoadScene("Finish", LoadSceneMode.Single);
        }
        else if(_minerWin>(_rounds/2))
        {
            SceneManager.LoadScene("Finish", LoadSceneMode.Single);
        }
        else if(LanternsCollected == 3)
        {
            MinerWin();
        }
        else if(_currentround==_rounds)
        {
            //No Wnner
            GameEnd();
        }

    }

    void StartSpawn()//spawn the player, mud and lantern pieces at predefined locations
    {
        _miner = (GameObject)Instantiate(Miner, SpawnLocations[UnityEngine.Random.Range(0, SpawnLocations.Length)].transform.position, Quaternion.identity);
        _mud = (GameObject)Instantiate(Mud, SpawnLocations[UnityEngine.Random.Range(0, SpawnLocations.Length)].transform.position, Quaternion.identity);
        int[] lanternPos = new int[3];
        /*do
        {
            lanternPos[0] = Random.Range(0, lanternPieces.Length);
            lanternPos[1] = Random.Range(0, lanternPieces.Length);
            lanternPos[2] = Random.Range(0, lanternPieces.Length);
        } while ((lanternPos[0] == lanternPos[1]) || (lanternPos[0] == lanternPos[2]) || (lanternPos[1] == lanternPos[2]));
<<<<<<< HEAD
<<<<<<< HEAD
        */
        _lanternPieces[0] = (GameObject)Instantiate(LanternPieces[0], SpawnLocations[UnityEngine.Random.Range(0, SpawnLocations.Length)].transform.position, Quaternion.identity);
        _lanternPieces[1] = (GameObject)Instantiate(LanternPieces[1], SpawnLocations[UnityEngine.Random.Range(0, SpawnLocations.Length)].transform.position, Quaternion.identity);
        _lanternPieces[2] = (GameObject)Instantiate(LanternPieces[2], SpawnLocations[UnityEngine.Random.Range(0, SpawnLocations.Length)].transform.position, Quaternion.identity);
=======
        
        _lanternPieces[0] = (GameObject)Instantiate(LanternPieces[0], LanternSpawns[0].transform.position, Quaternion.identity);
        _lanternPieces[1] = (GameObject)Instantiate(LanternPieces[1], LanternSpawns[1].transform.position, Quaternion.identity);
        _lanternPieces[2] = (GameObject)Instantiate(LanternPieces[2], LanternSpawns[2].transform.position, Quaternion.identity);
        foreach (GameObject lantern in _lanternPieces)
        {
            lantern.GetComponent<AudioSource>().volume = _gameManager.Volume/100f;
        }
>>>>>>> master
=======
        */
        _lanternPieces[0] = (GameObject)Instantiate(LanternPieces[0], LanternSpawns[0].transform.position, Quaternion.identity);
        _lanternPieces[1] = (GameObject)Instantiate(LanternPieces[1], LanternSpawns[1].transform.position, Quaternion.identity);
        _lanternPieces[2] = (GameObject)Instantiate(LanternPieces[2], LanternSpawns[2].transform.position, Quaternion.identity);
>>>>>>> parent of 0292850... Merge pull request #28 from JayceLovell/micheal
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
        TxtRounds.text = "Round: " + _currentround;
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
        SceneManager.LoadScene("Finish", LoadSceneMode.Single);
    }
    public void SlowMiner()
    {
        _playerMiner = _miner.GetComponent<MinerScript>() as MinerScript;
        _playerMiner.Speed = 1;
        StartCoroutine(speedTime());
    }
    IEnumerator speedTime()
    {
        yield return new WaitForSeconds(3);
        revertSpeed();
    }

    private void revertSpeed()
    {
        _playerMiner.Speed = 10;
    }
}
