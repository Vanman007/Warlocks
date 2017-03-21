using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer1 : MonoBehaviour {
        public static int P1XAimDir = 0;
    public static int P1YAimDir = 1;
    public static int P1ButtonPress = 0;
    public static bool p1w = false;
    public static bool p1s = false;
    public static bool p1a = false;
    public static bool p1d = false;
    public static bool p1q = false;
    public static bool p1e = false;

    public static int p1Health = 1000;

    public static bool p1HitByFireBall = false;

    public static Vector3 P1CurrentFacing;

    public GameObject FireBallProjectil;


    private int baseSpeed = 5;

    private float FireBallCD = 3;
    private float FireBallCurrentCD = 0;


    private IEnumerator HitByFireBallFunc;


    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {

        P1CurrentFacing = new Vector3(P1XAimDir, 0, P1YAimDir);


        transform.rotation = Quaternion.LookRotation(P1CurrentFacing);
       

        if (p1w == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * baseSpeed,Space.World);   
        }
        if (p1s == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * baseSpeed, Space.World);
        }
        if (p1a == true) 
        {
            transform.Translate(Vector3.left * Time.deltaTime * baseSpeed, Space.World);
        }
        if (p1d == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * baseSpeed, Space.World);
        }

        ShootFireBall();
        AoEBlast();

       
        //---- hit trigger - ik kønt men kunne i tænke på andre måder at gøre det..
        if (p1HitByFireBall == true)
        {
            p1HitByFireBall = false;
            HitByFireBallFunc = HitByFireBall(MoveFireBall.p1TempDirection);
            StartCoroutine(HitByFireBallFunc);
        }

    }

    public void ShootFireBall()
    {
        if (MovePlayer1.p1e == true)
        {
            if (Time.time > FireBallCurrentCD)
            {
                FireBallCurrentCD = Time.time + FireBallCD;
                Instantiate(FireBallProjectil, transform.position, Quaternion.Euler(0,0,0));
                //GameObject dummyFireBall = Instantiate(FireBallProjectil, transform.position, transform.rotation) as GameObject;

            }
        }
    }

    public void AoEBlast()
    {
        
    }


    private IEnumerator HitByFireBall(Vector3 HitDirection)
    {
        for (int i = 80; i > 0; i--)
        {
            transform.Translate(HitDirection * Time.deltaTime*(i/4), Space.World);
            yield return null;
        }
    }



}

