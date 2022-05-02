using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement :MonoBehaviour
{
    List<Cell> path;
    [SerializeField]
    private float moveSpeed = 2f;

    public Vector2 GetPosition => transform.position;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetPath(List<Cell> path)
    {
        //ResetPosition();
        waypointIndex = 0;
        path.RemoveAt(0);
        this.path = path;
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(0, 0);
    }

    private void Move()
    {
        if (path == null)
            return;

        if (waypointIndex <= path.Count - 1)
        {

          
            transform.position = Vector2.MoveTowards(transform.position,
               path[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            if (transform.position == path[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }
}