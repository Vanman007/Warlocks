using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFireBall : MonoBehaviour {
    private int baseSpeed = 20;
    private Vector3 Direction;
    public GameObject Player1;
    public GameObject Player2;

    //holy fuck this is ugly but here goes..
    public static Vector3 p1TempDirection;
    public static Vector3 p2TempDirection;


    // Use this for initialization
    void Start () {
        Direction = new Vector3(MovePlayer1.P1YAimDir, 0, -MovePlayer1.P1XAimDir);
        transform.Translate(Direction*1.6f);
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Direction * Time.deltaTime * baseSpeed);
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.ToString() == Player1.name.ToString())
        {
            p1TempDirection = Direction;
            MovePlayer1.p1HitByFireBall = true;
        }
        if (other.name.ToString() == Player2.name.ToString())
        {
            MovePlayer2.p2HitByFireBall = true;
            p2TempDirection = Direction;
        }
        Destroy(this.gameObject);
    }


}
