using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager GM;
    public int health = 100;
    public float speed = .1f;
    int currentWaypoint = 0;
    float distanceThreshold = .01f;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GM.DQs--;//at end of course and isn't dead, therefore we decrement health and kill the unit
            Destroy(gameObject);
            return;

        }

        if (Vector3.Distance(GM.Waypoints[currentWaypoint].transform.position, transform.position) < distanceThreshold)
        {
            if (currentWaypoint == GM.Waypoints.Length - 1)
            {

                Destroy(gameObject);
                GM.money += 10;
                return;
            }
            currentWaypoint++;
            gameObject.transform.LookAt(GM.Waypoints[currentWaypoint].transform);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, GM.Waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
        }
    }
}
