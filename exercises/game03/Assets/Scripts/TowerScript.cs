using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour

    
{
    public GameObject partcileSys;
    public int damage = 1;
    public float range = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Wolves = GameObject.FindGameObjectsWithTag("Wolf");
        //Debug.Log(Wolves.Length);
        GameObject target = null;
        float nearest = -1;
        for (int i = 0; i < Wolves.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, Wolves[i].transform.position);
            if ((nearest == -1 || dist < nearest) && dist < range)
            {
                nearest = dist;
                target = Wolves[i];
            }
        }

        if (target == null)
        {
            //partcileSys.GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            target.GetComponent<WolfScript>().health -= damage;
            partcileSys.transform.LookAt(target.transform);
            //partcileSys.GetComponent<ParticleSystem>().Play();

        }

        
    }

    void SetColor(bool isSelected)
    {
        if (isSelected)
        {
            
        }
    }


}
