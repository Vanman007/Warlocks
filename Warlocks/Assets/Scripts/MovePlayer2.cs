using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{
    public static int P2XAimDir = 0;
    public static int P2YAimDir = -1;
    public static int P2ButtonPress = 0;
    public static bool p2w = false;
    public static bool p2s = false;
    public static bool p2a = false;
    public static bool p2d = false;
    public static bool p2q = false;
    public static bool p2e = false;

    public static int p2Health = 1000;

    public static bool p2HitByFireBall = false;

    private int baseSpeed = 8;


    public static Vector3 P2CurrentFacing;

    public GameObject FireBallProjectil;


    private float FireBallCD = 3;
    private float FireBallCurrentCD = 0;


    private IEnumerator HitByFireBallFunc;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        P2CurrentFacing = new Vector3(P2XAimDir, 0, P2YAimDir);


        transform.rotation = Quaternion.LookRotation(P2CurrentFacing);


        if (p2w == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * baseSpeed);
        }
        if (p2s == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * baseSpeed);
        }
        if (p2a == true)
        {
            transform.Translate(Vector3.left * Time.deltaTime * baseSpeed);
        }
        if (p2d == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * baseSpeed);
        }

        ShootFireBall();
        AoEBlast();


        //---- hit trigger - ik kønt men kunne i tænke på andre måder at gøre det..
        if (p2HitByFireBall == true)
        {
            p2HitByFireBall = false;
            HitByFireBallFunc = HitByFireBall(MoveFireBall.p2TempDirection);
            StartCoroutine(HitByFireBallFunc);
        }



    }

    public void ShootFireBall()
    {
        if (MovePlayer2.p2e == true)
        {
            if (Time.time > FireBallCurrentCD)
            {
                FireBallCurrentCD = Time.time + FireBallCD;
                Instantiate(FireBallProjectil, transform.position, Quaternion.Euler(0, 0, 0));
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
            transform.Translate(HitDirection * Time.deltaTime * (i / 4), Space.World);
            yield return null;
        }
    }

}