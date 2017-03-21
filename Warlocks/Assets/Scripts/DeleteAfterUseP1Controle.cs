using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterUseP1Controle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("w"))
            MovePlayer1.p1w = false;
        if (Input.GetKeyDown("w"))
            MovePlayer1.p1w = true;

        if (Input.GetKeyUp("s"))
            MovePlayer1.p1s = false;
        if (Input.GetKeyDown("s"))
            MovePlayer1.p1s = true;

        if (Input.GetKeyUp("a"))
            MovePlayer1.p1a = false;
        if (Input.GetKeyDown("a"))
            MovePlayer1.p1a = true;

        if (Input.GetKeyUp("d"))
            MovePlayer1.p1d = false;
        if (Input.GetKeyDown("d"))
            MovePlayer1.p1d = true;

        if (Input.GetKeyUp("e"))
            MovePlayer1.p1e = false;
        if (Input.GetKeyDown("e"))
            MovePlayer1.p1e = true;



        new Vector3(3, 2, 3);

    }
}
