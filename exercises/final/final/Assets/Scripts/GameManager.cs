using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentCube;

    public Text KeyOpts;
    public Text Resources;
    public string NormalKeyOpts = "B: Build new tower";
    public int DQs = 50;
    public int money = 100;

    string[] TowerList = new string[] { "Shower", "Drink Stand" };
    int[] TowerPrices = new int[] { 50, 50 };
    public GameObject[] TowerPrefabs = new GameObject[2] { null, null };
    public GameObject[] Waypoints = { null, null, null, null, null, null };

    bool pressedB;
    int selectedTurret = -1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.B) && !pressedB)
        {
            pressedB = true;
            NormalKeyOpts = "1: Shower (50) 2: Drink Stand (50)";



        }

        if (pressedB && selectedTurret == -1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedTurret = 0;
                NormalKeyOpts = "Click to place";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedTurret = 1;
                NormalKeyOpts = "Click to place";
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                pressedB = false;
                NormalKeyOpts = "B: Build new tower";
            }
            NormalizeKeyOpts();
        }

        if (pressedB && selectedTurret != -1)
        {
            if (Input.GetMouseButtonDown(0) && currentCube != null)
            {
                Transform t = currentCube.transform;
                Debug.Log(t.position);
                GameObject newT = Instantiate(TowerPrefabs[selectedTurret], t.position + new Vector3(0, .475f, 0), Quaternion.identity);
                //;
                pressedB = false;
                selectedTurret = -1;
                NormalKeyOpts = "B: Build new tower";
            }
            NormalizeKeyOpts();
        }

        
    }

    void UpdateUI()
    {
        Resources.text = "DQs:" + DQs + "\n\n $" + money;
    }

    public void NormalizeKeyOpts ()
    {
        KeyOpts.text = NormalKeyOpts;
    }

    //void SelectGround ()
    //{
    //    int layer_mask = LayerMask.GetMask("Ground");

    //    RaycastHit hit;
    //    Ray ray = camera.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        hit.collider.gameObject.GetComponent<CubeScript>()
    //    }
    //
}
