using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] Waypoints = new GameObject[4];
    public GameObject waypoint0;
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;

    public GameObject GameManager;

 
    // Start is called before the first frame update
    void Start()
    {
        Waypoints[0] = waypoint0;
        Waypoints[1] = waypoint1;
        Waypoints[2] = waypoint2;
        Waypoints[3] = waypoint3;

        StartCoroutine(Waves());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadWolf (int health)
    {
        //-3.414, 0, 4 = spawn pos
        GameObject wolf = Instantiate(prefab, new Vector3(-3.414f, 0, 4), Quaternion.identity);
        WolfScript wc = wolf.GetComponent<WolfScript>();
        wc.Waypoints = Waypoints;
        wc.health = health;
        wolf.transform.LookAt(waypoint0.transform);
    }



    IEnumerator Waves()
    {
        for (int i = 0; i < 10; i++)
        {
            LoadWolf(100);
            yield return new WaitForSeconds(1);
        }
     

        yield return new WaitForSeconds(10);

        for (int i = 0; i < 20; i++)
        {
            LoadWolf(250);
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(10);

        for (int i = 0; i < 40; i++) {
            LoadWolf(300);
            yield return new WaitForSeconds(.5f);
        }
        GameManager.GetComponent<GameManagerScript>().Win();
        yield break;
    }
}
