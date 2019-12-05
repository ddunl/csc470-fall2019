using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandScript : MonoBehaviour
{
    public GameObject[] liqs;

    public Material UpgradedMat;
    public GameManager GM;
    string KeyOptsString = "U: Upgrade";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void changeMaterial(Material mat)
    {
        foreach (GameObject liq in liqs) {
            liq.GetComponent<Renderer>().material = mat;
        }
    }

    private void OnMouseEnter()
    {
        GM.KeyOpts.text = KeyOptsString;
    }
    private void OnMouseExit()
    {
        GM.NormalizeKeyOpts();
    }

    private void OnMouseOver()
    {

        if (Input.GetKeyDown(KeyCode.U))
        {
            changeMaterial(UpgradedMat);
        }
    }
}
