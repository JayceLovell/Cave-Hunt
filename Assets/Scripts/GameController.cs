using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController: MonoBehaviour
{

    public GameObject[] minerSpawns;
    public GameObject[] mudSpawns;
    public GameObject[] lanternSpawns;

    public GameObject ghost;
    GameObject miner;
    GameObject mudPickup;
    GameObject[] lanternPieces = new GameObject[3];

    void Start()
    {
        StartSpawn();
    }

    void Update()
    {


    }

    void StartSpawn()//spawn the player, mud and lantern pieces at predefined locations
    {
        GameObject miner = (GameObject)Instantiate(Resources.Load("Miner"), minerSpawns[Random.Range(0, minerSpawns.Length)].transform.position, Quaternion.identity);
        mudPickup = (GameObject)Instantiate(Resources.Load("MudItem"), mudSpawns[Random.Range(0, mudSpawns.Length)].transform.position, Quaternion.identity);
        int[] lanternPos = new int[3];
        do
        {
            lanternPos[0] = Random.Range(0, lanternPieces.Length);
            lanternPos[1] = Random.Range(0, lanternPieces.Length);
            lanternPos[2] = Random.Range(0, lanternPieces.Length);
        } while ((lanternPos[0] == lanternPos[1]) || (lanternPos[0] == lanternPos[2]) || (lanternPos[1] == lanternPos[2]));
        lanternPieces[0] = (GameObject)Instantiate(Resources.Load("LanternPiece1"), lanternSpawns[lanternPos[0]].transform.position, Quaternion.identity);
        lanternPieces[1] = (GameObject)Instantiate(Resources.Load("LanternPiece2"), lanternSpawns[lanternPos[1]].transform.position, Quaternion.identity);
        lanternPieces[2] = (GameObject)Instantiate(Resources.Load("LanternPiece3"), lanternSpawns[lanternPos[2]].transform.position, Quaternion.identity);
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
