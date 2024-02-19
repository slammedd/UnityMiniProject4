using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform waypoint;
    public float movementSpeed;

    private Vector3 startPoint;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        waypoint.parent = null;
        startPoint = transform.position;
        target = waypoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(target, transform.position) < 1)
        {
            if(target == startPoint)
            {
                target = waypoint.position;
                transform.Rotate(0, 180, 0);
            }

            else if(target == waypoint.position)
            {
                target = startPoint;
                transform.Rotate(0, 180, 0);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }
}
