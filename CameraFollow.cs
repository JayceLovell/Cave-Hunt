using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

    GameObject ghost;
    public float targetSize = 6;
    public Vector2 targetPos;
    public bool camLock=false;
	void Start () {
        ghost = GameObject.Find("Ghost");
    }
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector2(ghost.transform.position.x, ghost.transform.position.y);
        targetSize = 5;
        updateCamera();
    }
    void updateCamera()
    {
        this.GetComponent<Camera>().orthographicSize = Mathf.Lerp(this.GetComponent<Camera>().orthographicSize, targetSize, Time.deltaTime*2);
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, targetPos.x, Time.deltaTime * 3), Mathf.Lerp(this.transform.position.y, targetPos.y, Time.deltaTime * 3), -10);
    }
}
