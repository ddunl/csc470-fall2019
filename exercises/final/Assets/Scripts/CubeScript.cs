using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameManager GM;
    public Material Selected;
    public Material Unavailable;
    public Material RoadMaterial;
    Material starting;
    Renderer rend;

    bool empty = true;
    void Start()
    {
        rend = GetComponent<Renderer>();
        starting = rend.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        GM.currentCube = this.gameObject;
        if (starting == RoadMaterial && !empty)
        {
            rend.material = Unavailable;
        } else
        {
            rend.material = Selected;
        }
        
    }

    private void OnMouseExit()
    {
        GM.currentCube = null;
        rend.material = starting;
    }
}
