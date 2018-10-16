using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCamera : MonoBehaviour {

    private Vector3 offset; //Private variable to store the offset distance between the player and camera

    public GameObject Ghost;
    void Start()
    {
        Ghost = GameObject.Find("Ghost");
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - Ghost.transform.position;
    }

    // LateUpdate is called after Update each frame
    void Update()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = Ghost.transform.position + offset;
    }
}
