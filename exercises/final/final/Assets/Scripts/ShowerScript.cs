using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowerScript : MonoBehaviour
{
    public GameManager GM;
    string KeyOptsString = "R: Rotate U: Upgrade";

    public Material UpgradedMat;

    public GameObject[] components;
  
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnMouseOver()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        {//rotate
            transform.rotation *= Quaternion.Euler(0, 45, 0);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {//upgrade
            Debug.Log("PRESSED U");
            foreach (GameObject comp in components)
            {
                comp.GetComponent<Renderer>().material = UpgradedMat;
            }
        }
    }

    private void OnMouseEnter () {
        GM.KeyOpts.text = KeyOptsString;
    }
    private void OnMouseExit()
    {
        GM.NormalizeKeyOpts();
    }


}
