using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController: MonoBehaviour
{
    private int _rounds;
    private int _currentround=1;

    public GameObject[] MinerSpawns;
    public GameObject[] MudSpawns;
    public GameObject[] LanternSpawns;
    public GameManager _gameManager;
    public Text TxtRounds;
    public GameObject Ghost;
    public GameObject Miner;
    public GameObject MudPickup;
    public GameObject[] lanternPieces = new GameObject[3];

    void Start()
    {
        StartSpawn();
        _rounds = _gameManager.Rounds;
        TxtRounds.text = "Round: " + _currentround;
    }

    void Update()
    {


    }

    void StartSpawn()//spawn the player, mud and lantern pieces at predefined locations
    {
        var miner = (GameObject)Instantiate(Resources.Load("Miner"), MinerSpawns[Random.Range(0, MinerSpawns.Length)].transform.position, Quaternion.identity);
        var mudPickup = (GameObject)Instantiate(Resources.Load("MudItem"), MudSpawns[Random.Range(0, MudSpawns.Length)].transform.position, Quaternion.identity);
        int[] lanternPos = new int[3];
        do
        {
            lanternPos[0] = Random.Range(0, lanternPieces.Length);
            lanternPos[1] = Random.Range(0, lanternPieces.Length);
            lanternPos[2] = Random.Range(0, lanternPieces.Length);
        } while ((lanternPos[0] == lanternPos[1]) || (lanternPos[0] == lanternPos[2]) || (lanternPos[1] == lanternPos[2]));
        //lanternPieces[0] = (GameObject)Instantiate(Resources.Load("LanternPiece1"), LanterSpawns[lanternPos[0]].transform.position, Quaternion.identity);
        //lanternPieces[1] = (GameObject)Instantiate(Resources.Load("LanternPiece2"), LanterSpawns[lanternPos[1]].transform.position, Quaternion.identity);
        //lanternPieces[2] = (GameObject)Instantiate(Resources.Load("LanternPiece3"), LanterSpawns[lanternPos[2]].transform.position, Quaternion.identity);
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
}
