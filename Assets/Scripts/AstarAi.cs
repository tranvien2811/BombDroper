using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AstarAi : MonoBehaviour
{
    public Transform targetPosition;

    private Seeker seeker;

    private CharacterController controller;

    public Path path;

    public float speed = 2;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;

    public bool reachedEndOfPath;

    public Transform partRorate;

    public float speedRotation = 10f;

    public Air[] airs;

    public TYPE_AIRCRAF typeAir;

    public GameObject Bomb;

    public Transform posDragBomb;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        checkAir();
    }

    private void checkAir()
    {
        for (int i = 0; i < airs.Length; i++)
        {
            airs[i].gameObject.SetActive((int)typeAir == i ? true : false);
        }
    }

    public void SetUpMoveAi(Transform _pos)
    {
        targetPosition = _pos;              
        seeker = GetComponent<Seeker>();        
        seeker.StartPath(transform.position, targetPosition.position, OnPathComplete);
       
    }

    public void SetUpMoveAi()
    {
        for (int i = 0; i < airs.Length; i++)
        {           
            airs[i].gameObject.SetActive((int)typeAir == i ? true : false);
        }     
    }


    private void OnDisable()
    {
        
    }

    private void OnPathComplete(Path p)
    {
        
        if (!p.error)
        {
            path = p;
            // Reset the waypoint counter so that we start to move towards the first point in the path
            currentWaypoint = 0;
        }
        
    }

    public void Update()
    {       
        if (path == null)
        {
            // We have no path to follow yet, so don't do anything
            return;
        }

        // Check in a loop if we are close enough to the current waypoint to switch to the next one.
        // We do this in a loop because many waypoints might be close to each other and we may reach
        // several of them in the same frame.
        reachedEndOfPath = false;
        // The distance to the next waypoint in the path
        float distanceToWaypoint;
        while (true)
        {
            // If you want maximum performance you can check the squared distance instead to get rid of a
            // square root calculation. But that is outside the scope of this tutorial.
            distanceToWaypoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            Vector3 _dir = path.vectorPath[currentWaypoint] - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(_dir);
            Vector3 rotation = Quaternion.Lerp(partRorate.rotation, lookRotation, speedRotation * Time.deltaTime).eulerAngles;
            partRorate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            if (distanceToWaypoint < nextWaypointDistance)
            {
                // Check if there is another waypoint or if we have reached the end of the path
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                }
                else
                {
                    // Set a status variable to indicate that the agent has reached the end of the path.
                    // You can use this to trigger some special code if your game requires that.
                    if (CustomClass.isBombDrag == 1 && Vector3.Distance(transform.position, targetPosition.position) < 1)
                    {
                        OnDropBomb();
                        GameManager.Instance.HitTarget.GetChild(0).gameObject.SetActive(false);
                        CustomClass.isBombDrag = 2;
                    }
                    if (CustomClass.isBombDrag == 2 && Vector3.Distance(transform.position, GameManager.Instance.LastTarget.position) < 1.5f)
                    {
                       // GameManager.Instance.HitTarget.GetChild(0).gameObject.SetActive(true);
                        CustomClass.isBombDrag = 0;
                    }
                    break;
                }
            }
            else
            {
                break;
            }
        }
        MapManager.Instance.checkRangerAttrack(this.transform);
        // Slow down smoothly upon approaching the end of the path
        // This value will smoothly go from 1 to 0 as the agent approaches the last waypoint in the path.
        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWaypoint / nextWaypointDistance) : 1f;

        // Direction to the next waypoint
        // Normalize it so that it has a length of 1 world unit
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        // Multiply the direction by our desired speed to get a velocity
        Vector3 velocity = dir * speed * speedFactor;

        // Move the agent using the CharacterController component
        // Note that SimpleMove takes a velocity in meters/second, so we should not multiply by Time.deltaTime
        controller.SimpleMove(velocity);

        // If you are writing a 2D game you should remove the CharacterController code above and instead move the transform directly by uncommenting the next line
        // transform.position += velocity * Time.deltaTime;
    }

    public void OnDropBomb()
    {
        if (CustomClass.isBombDrag == 1)
        {
            Instantiate(Bomb, posDragBomb.position, Quaternion.identity);
            Invoke("AirGoHome", 0.5f);            
        }
        // when aircraf move finish drop bomb        
    }


    private void AirGoHome()
    {        
        seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, GameManager.Instance.LastTarget.position, OnPathComplete);
    }


    public Air GetHeath()
    {
        for (int i = 0; i < airs.Length; i++)
        {
            bool checkHeath = (int)typeAir == i ? true : false;
            if (checkHeath)
            {
                return airs[i];
            }
        }
        return null;
    }

}
