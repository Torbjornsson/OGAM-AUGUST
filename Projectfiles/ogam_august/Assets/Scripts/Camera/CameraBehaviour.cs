using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public Transform target;
    private Vector3 tmpVec;
    private float slerpSpeed = 1000;

    private float threshold = 15;

    void FixedUpdate()
    {
        if (target) { FollowTarget(); }
        else { target = GameObject.FindGameObjectWithTag("Player").transform; }
    }

    void FollowTarget()
    {
        tmpVec = target.position;
        tmpVec.z = transform.position.z;
        float dist = Vector3.Distance(tmpVec, transform.position);
        //print(dist);
        if(dist > threshold)
        {
            //print(transform.position);
            transform.position = Vector3.MoveTowards(transform.position, tmpVec,slerpSpeed * Time.deltaTime);
            //print(transform.position);
            //transform.position = Vector3.Slerp(transform.position, tmpVec, slerpSpeed * Time.deltaTime);
        }
    }

}
