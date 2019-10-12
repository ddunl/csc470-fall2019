using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public bool alive = false;
    public bool nextAlive;
    bool prevAlive;
    public int x = -1;
    public int y = -1;
    public Color cellColor = new Color(0, 0, 0);
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        prevAlive = alive;
    }

    // Update is called once per frame
    void Update()
    {
        if (prevAlive != alive)
        {
            updateColor();
            transform.localScale = new Vector3(3.3f, 1, 3.3f);

        }
        else {
            float a = 0.05f * Time.deltaTime;
            cellColor -= new Color(a, a, a);
            renderer.material.color = cellColor;
            transform.localScale += new Vector3(0, 1*Time.deltaTime, 0);
        }

        prevAlive = alive;
    }

    public void updateColor()
    {
        if (renderer == null)
        {
            renderer = gameObject.GetComponentInChildren<Renderer>();
        }

        if (this.alive)
        {
            cellColor = Color.green;
            renderer.material.color = cellColor;
        }
        else
        {
            cellColor = Color.cyan;
            renderer.material.color = cellColor;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            transform.localScale += new Vector3(0, 3 , 0);

        } else
        {
            alive = !alive;
        }
       
    }
}