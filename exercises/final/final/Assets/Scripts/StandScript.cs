using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandScript : MonoBehaviour
{
    public GameObject[] liqs;

    public Material UpgradedMat;
    public GameManager GM;
    string KeyOptsString = "U: Upgrade";

    public int HydrationRate;
    public int SpeedRate;
    int UpgradeCost;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        HydrationRate = 1;
        SpeedRate = 0;
        UpgradeCost = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMaterial(Material mat)
    {
        foreach (GameObject liq in liqs) {
            liq.GetComponent<Renderer>().material = mat;
        }
    }

    private void OnMouseEnter()
    {
        GM.KeyOpts.text = KeyOptsString + " " + UpgradeCost.ToString();
    }
    private void OnMouseExit()
    {
        GM.NormalizeKeyOpts();
    }

    private void OnMouseOver()
    {

        if (Input.GetKeyDown(KeyCode.U))
        {

            Upgrade();
            
        }
    }

    private void Upgrade()
    {
        if (GM.money < UpgradeCost)
        {
            return;
        }
        else
        {
            GM.money -= UpgradeCost;
            UpgradeCost *= 2;
            HydrationRate *= 2;
            SpeedRate++;
            changeMaterial(UpgradedMat);
        }
    }
}
