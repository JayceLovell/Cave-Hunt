using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*

 *

 * Yueyang Sun - 300933625


 * Jayce Lovell - 300833478

 * Vincent Wright - 300928112

 *

 * COMP394-002 Practical Game Design - Cave Hunt

 */
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
