using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

	public KeyCode up, down, left, right;

    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private int distance = 1;
    private Vector3 moveToVector = Vector3.zero;
    private float moveLerp = 10;
    private bool okToMove = true;
    private bool hMove, vMove;

    void Start()
    {
        moveToVector = transform.position;
    }

	void Update ()
    {
        PlayerDefinedMovement();
    }

    void FixedUpdate()
    {
        PreciseMovement();
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
            if (hMove) { moveToVector.x += Input.GetAxisRaw(horizontalAxis); }
            if (vMove) { moveToVector.y += Input.GetAxisRaw(verticalAxis); }
            PerformedMovement();
        }
    }

    void PerformedMovement()
    {
        Debug.Log("Movement Performed...");
    }

    void BoundInputMovement()
    {
        if (Input.GetKeyDown(up))
        {
            print("moveup");
            transform.Translate(Vector2.up);
        }
        if (Input.GetKeyDown(down))
        {
            print("movedown");
            transform.Translate(Vector2.down);
        }
        if (Input.GetKeyDown(left))
        {
            print("moveleft");
            transform.Translate(Vector2.left);
        }
        if (Input.GetKeyDown(right))
        {
            print("moveright");
            transform.Translate(Vector2.right);
        }
    }
}
