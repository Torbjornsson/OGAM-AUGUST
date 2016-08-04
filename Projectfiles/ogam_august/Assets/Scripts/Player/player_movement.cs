﻿using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private string rotateXAxis = "RotateX";
    private string rotateYAxis = "RotateY";
    private int distance = 1;
    private Vector3 moveToVector = Vector3.zero;
    private float moveLerp = 10;
    private bool okToMove = true;
    private bool hMove, vMove;
    private float rotX = 0;
    private float rotY = 0;
    private float rotateLerp = 10;
    private Vector3 tmpRot = Vector3.zero;
    private Quaternion rotateToQuat = Quaternion.identity;

    void Start()
    {
        moveToVector = transform.position;
    }

    void OnEnable()
    {
        moveToVector = transform.position;
    }

    // använd för allt som inte rör sig
	void Update ()
    {
        PlayerDefinedMovement();
        RotatePlayer();
    }

    // använd för allt som rör sig
    void FixedUpdate()
    {
        PreciseMovement();
        RotateToPoint();
    }

    void PreciseMovement()
    {
        transform.position = Vector3.Lerp(transform.position, moveToVector, moveLerp * Time.deltaTime);
        okToMove = Vector3.Distance(transform.position, moveToVector) < 0.1f;
        if (okToMove) { transform.position = moveToVector; }         
    }

    void PlayerDefinedMovement()
    {
        hMove = Input.GetButtonDown(horizontalAxis);
        vMove = Input.GetButtonDown(verticalAxis);
        if (hMove ^ vMove && okToMove)
        {
            Vector3 tmpMov = moveToVector;
            if (hMove) { moveToVector.x += Input.GetAxisRaw(horizontalAxis); }
            if (vMove) { moveToVector.y += Input.GetAxisRaw(verticalAxis); }
            if (CheckSpace(moveToVector)) { moveToVector = tmpMov; }
            PerformedMovement();
        }
    }

    /// <summary>
    /// looks for blocking colliders 
    /// </summary>
    /// <param name="checkPos">position to be checked for colliders</param>
    /// <returns>if there are any blocking colliders</returns>
    bool CheckSpace(Vector3 checkPos)
    {
        Collider[] c = Physics.OverlapBox(checkPos, new Vector3(0.25f, 0.25f, 0.2f));
        foreach (Collider col in c)
        {
            if (col.isTrigger) { return false; }
            Debug.Log(col.transform.name + " blocking the way");
        }

        return c.Length > 0;
    }

    void PerformedMovement()
    {
        //Debug.Log("Movement Performed...");
    }

    void RotatePlayer()
    {
        rotX = Input.GetAxisRaw(rotateXAxis);
        rotY = Input.GetAxisRaw(rotateYAxis);
        if (rotX > 0) { rotateToQuat = Quaternion.Euler(0, 0, -90); }
        else if (rotX < 0) { rotateToQuat = Quaternion.Euler(0, 0, 90); }
        else if (rotY > 0) { rotateToQuat = Quaternion.Euler(0, 0, 180); }
        else if (rotY < 0) { rotateToQuat = Quaternion.Euler(0, 0, 0); }
    }

    void RotateToPoint()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, rotateToQuat, rotateLerp * Time.deltaTime);
    }

    public Quaternion GetEntityRotation()
    {
        return rotateToQuat;
    }
}