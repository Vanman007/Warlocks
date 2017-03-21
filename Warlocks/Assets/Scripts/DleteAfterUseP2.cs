using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DleteAfterUseP2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("w"))
            MovePlayer1.p1w = false;
        if (Input.GetKeyDown("w"))
            MovePlayer1.p1w = true;

        


    }


}
