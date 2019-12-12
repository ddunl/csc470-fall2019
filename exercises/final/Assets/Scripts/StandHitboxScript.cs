using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandHitboxScript : MonoBehaviour
{
    // Start is called before the first frame update
    public StandScript StSc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        JoggerScript js = other.gameObject.GetComponent<JoggerScript>();
        if (js == null) return;
        js.deltaBlue -= StSc.HydrationRate;
        js.green += StSc.SpeedRate;
        Debug.Log("Trigger Enter");
    }

    private void OnTriggerExit(Collider other)
    {
        JoggerScript js = other.gameObject.GetComponent<JoggerScript>();
        if (js == null) return;
        js.deltaBlue += StSc.HydrationRate;
        js.green -= StSc.SpeedRate;
        Debug.Log("Trigger Exit");
    }
}
