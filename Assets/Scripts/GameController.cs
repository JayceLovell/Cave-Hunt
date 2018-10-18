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

    public GameObject[] MinerSpawns;
    public GameObject[] MudSpawns;
    public GameObject[] LanternSpawns;
    public Text TxtRounds;
    public GameObject Ghost;
    public GameObject Miner;
    public GameObject Mud;
    public GameObject[] LanternPieces = new GameObject[3];
    public int LanternsCollected;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>() as GameManager;
        _rounds = _gameManager.Rounds;
        TxtRounds.text = "Round: " + _currentround;
        _ghostWin = _gameManager.Score[0];
        _minerWin = _gameManager.Score[1];
        LanternsCollected = 0;
        
    }
    void Start()
    {
        GetComponent<AudioSource>().volume = _gameManager.Volume / 400f;
        StartSpawn(); 
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
        _miner = (GameObject)Instantiate(Miner, MinerSpawns[UnityEngine.Random.Range(0, MinerSpawns.Length)].transform.position, Quaternion.identity);
        _mud = (GameObject)Instantiate(Mud, MudSpawns[UnityEngine.Random.Range(0, MudSpawns.Length)].transform.position, Quaternion.identity);
        int[] lanternPos = new int[3];
        do
        {
            lanternPos[0] = UnityEngine.Random.Range(0, LanternPieces.Length);
            lanternPos[1] = UnityEngine.Random.Range(0, LanternPieces.Length);
            lanternPos[2] = UnityEngine.Random.Range(0, LanternPieces.Length);
        } while ((lanternPos[0] == lanternPos[1]) || (lanternPos[0] == lanternPos[2]) || (lanternPos[1] == lanternPos[2]));
        
        _lanternPieces[0] = (GameObject)Instantiate(LanternPieces[0], LanternSpawns[0].transform.position, Quaternion.identity);
        _lanternPieces[1] = (GameObject)Instantiate(LanternPieces[1], LanternSpawns[1].transform.position, Quaternion.identity);
        _lanternPieces[2] = (GameObject)Instantiate(LanternPieces[2], LanternSpawns[2].transform.position, Quaternion.identity);
        foreach (GameObject lantern in _lanternPieces)
        {
            lantern.GetComponent<AudioSource>().volume = _gameManager.Volume/700f;
        }
    }
    
    public void RestartGame()
    {
        if (_miner)
            Destroy(_miner);
        foreach (GameObject item in _lanternPieces)
        {
            if (item)
                Destroy(item);
        }
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
        _playerMiner.speed = 1;
        StartCoroutine(speedTime());
    }
    IEnumerator speedTime()
    {
        yield return new WaitForSeconds(3);
        revertSpeed();
    }

    private void revertSpeed()
    {
        _playerMiner.speed = 10;
    }
}
