using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleh : MonoBehaviour {

    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion q = transform.rotation;
        q.eulerAngles += new Vector3(0, 0, Time.deltaTime * speed);
        transform.rotation = q;
    }
}
