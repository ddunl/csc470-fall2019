using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerHitboxScript : MonoBehaviour
{
    // Start is called before the first frame update
    public ShowerScript StSc;
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
        js.deltaRed -= StSc.CoolingRate;
    }

    private void OnTriggerExit(Collider other)
    {
        JoggerScript js = other.gameObject.GetComponent<JoggerScript>();
        if (js == null) return;
        js.deltaRed += StSc.CoolingRate;

    }
}
