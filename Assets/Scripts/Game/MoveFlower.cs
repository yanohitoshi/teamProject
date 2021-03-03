using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Numerics;

public class MoveFlower : MonoBehaviour
{

    private Vector3 velocity;
    private float moveX;
    private float moveY;
    private Vector3 position;
    private Vector3 firstPosition;

    public void Init()
    {
        velocity = Vector3.zero;
        moveX = Random.Range(1.0f, 50.0f);
        moveX *= 0.001f;
        moveY = Random.Range(10.0f, 40.0f);
        moveY *= 0.001f;
        firstPosition = this.transform.position;
    }

    public void Run()
    {
        float sin = Mathf.Sin(Time.time);
        velocity.x = sin * moveX;
        velocity.y = -moveY;
        this.transform.Translate(velocity);
        position = this.transform.position;

        //firstPosition += velocity;
        if (position.y <= -20.0f)
        {
            //position.y = firstPosition.y;
            //this.transform.Translate(firstPosition);
            this.transform.position = new Vector3(firstPosition.x, firstPosition.y, firstPosition.z);
        }
    }
}
