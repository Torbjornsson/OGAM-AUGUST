using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public Transform target;
    private Vector3 tmpVec;
    private float slerpSpeed = 10;

    void FixedUpdate()
    {
        if (target) { FollowTarget(); }
        else { target = GameObject.FindGameObjectWithTag("Player").transform; }
    }

    void FollowTarget()
    {
        tmpVec = target.position;
        tmpVec.z = transform.position.z;
        transform.position = Vector3.Slerp(transform.position, tmpVec, slerpSpeed * Time.deltaTime);
    }

}
