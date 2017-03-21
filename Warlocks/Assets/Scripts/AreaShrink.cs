using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaShrink : MonoBehaviour {
    public GameObject Player1;
    public GameObject Player2;
    public GameObject VisualBound;
    public GameObject Bound;

    private bool p1OutaBound;
    private bool p2OutaBound;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (Time.realtimeSinceStartup > 60 && Time.realtimeSinceStartup < 60+10)
        {

            VisualBound.transform.localScale -= new Vector3(0.01f, 0, 0.01f);
            Bound.transform.localScale -= new Vector3(0.01f, 0, 0.01f);

        }
        if (Time.realtimeSinceStartup > 60*2 && Time.realtimeSinceStartup < 60*2+10)
        {

            VisualBound.transform.localScale -= new Vector3(0.01f, 0, 0.01f);
            Bound.transform.localScale -= new Vector3(0.01f, 0, 0.01f);
        }
        if (Time.realtimeSinceStartup > 60*2+10+15 && VisualBound.transform.localScale.x >= 0f)
        {

            VisualBound.transform.localScale -= new Vector3(0.01f, 0, 0.01f);
            Bound.transform.localScale -= new Vector3(0.01f, 0, 0.01f);
        }
        if (VisualBound.transform.localScale.x <= 0f)
        { 
            Destroy(VisualBound);
            Destroy(Bound);
        }


        if (p1OutaBound)
        {
            MovePlayer1.p1Health = MovePlayer1.p1Health - 1;
        }
        if (p2OutaBound)
        {
            MovePlayer2.p2Health = MovePlayer2.p2Health - 1;
        }
        Debug.Log(MovePlayer2.p2Health);
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name.ToString() == Player1.name.ToString())
        {
            p1OutaBound = true;
        }
        if (other.name.ToString() == Player2.name.ToString())
        {
            p2OutaBound = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name.ToString() == Player1.name.ToString())
        {
            p1OutaBound = false;
        }
        if (other.name.ToString() == Player2.name.ToString())
        {
            p2OutaBound = false;
        }
    }

}
