using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

	public KeyCode up, down, left, right;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(up)){
			print("moveup");
			transform.Translate(Vector2.up);
		}
		if(Input.GetKeyDown(down)){
			print("movedown");
			transform.Translate(Vector2.down);
		}
		if(Input.GetKeyDown(left)){
			print("moveleft");
			transform.Translate(Vector2.left);
		}
		if(Input.GetKeyDown(right)){
			print("moveright");
			transform.Translate(Vector2.right);
		}
	}
}
