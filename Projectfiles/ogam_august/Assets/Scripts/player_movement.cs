using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

	public KeyCode up, down, left, right;

    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private int distance = 1;
    private Vector3 moveToVector = Vector3.zero;
    private float moveLerp = 10;

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
        transform.position = Vector3.Lerp(transform.position, moveToVector, moveLerp * Time.deltaTime);
    }

    void PlayerDefinedMovement()
    {
        if (Input.GetButtonDown(horizontalAxis) ^ Input.GetButtonDown(verticalAxis))
        {
            moveToVector.x += Input.GetAxisRaw(horizontalAxis);
            moveToVector.y += Input.GetAxisRaw(verticalAxis);
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
