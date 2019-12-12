using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager GM;
    public int health = 100;
  
    int currentWaypoint = 0;
    float distanceThreshold = .01f;
    public bool SPICY; // used in start menu

    public float red = 0;  //heat
    public float green = 25; //speed
    public float blue = 0; //thirst

    public int deltaRed, deltaBlue, deltaGreen = -1;

    public Renderer Rend;
    void Start()
    {
        if (SPICY) return;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
       if (SPICY)
        {
            updateColors();
            Rend.material.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
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
            transform.position = Vector3.MoveTowards(transform.position, GM.Waypoints[currentWaypoint].transform.position, Time.deltaTime * (green/64.0f));
        }

        updateColors();

        Rend.material.color = new Color32((byte) red, (byte) green, (byte) blue, 255);
        
    }

    void CheckIfDie()
    {
        if (red >= 255 || green >= 255 || blue >= 255)
        {
            Die();
        }
    }

    public void setColors (int red, int blue, int green)
    {
        this.red = red;
        this.blue = blue;
        this.green = green;
    }

    public void setDeltas (int dred, int dblue, int dgreen)
    {
        deltaRed = dred;
        deltaBlue = dblue;
        deltaGreen = dgreen;
    }

    public void updateColors ()
    {
        red += (deltaRed * Time.deltaTime);
        blue += (deltaBlue * Time.deltaTime);
        green += (deltaGreen * Time.deltaTime);

        if (red < 0) red = 0;
        if (blue < 0) blue = 0;
        if (green < 0) green = 0;
    }

    public void Die()
    {//making this seperate to maybe add in some simple animation at some point
        GM.DQs--;
        Destroy(gameObject);//for now
    }
}
