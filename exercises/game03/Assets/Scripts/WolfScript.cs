using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScript : MonoBehaviour
{
    public int health = 100;


    public GameObject GameManager;

    public GameObject[] Waypoints = { null, null, null, null };

    int currentWaypoint = 0;
    float distanceThreshold = .01f;   
    // Start is called before the first frame update
    void Start()
    {
        //I'd just like to apologize for how this is written, I'm sure there is a better way
        GameManager = GameObject.Find("GameManagerObject");

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.GetComponent<GameManagerScript>().money += 10;
            return;
        }

        if (Vector3.Distance(Waypoints[currentWaypoint].transform.position, transform.position) < distanceThreshold)
        {
            if (currentWaypoint == Waypoints.Length - 1)
            {
                GameManager.GetComponent<GameManagerScript>().health--;//at end of course and isn't dead, therefore we decrement health and kill the unit
                Destroy(gameObject);
                return;
            }
            currentWaypoint++;
            gameObject.transform.LookAt(Waypoints[currentWaypoint].transform);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[currentWaypoint].transform.position, Time.deltaTime * 5);
        }
    }
}
