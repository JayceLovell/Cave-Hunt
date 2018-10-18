using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public int Timer;
	// Use this for initialization
	void Start () {
        StartCoroutine(timer());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator timer()
    {
        yield return new WaitForSeconds(Timer);
        Destroy(this.gameObject);
    }
}
