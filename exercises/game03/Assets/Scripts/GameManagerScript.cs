using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 25;
    public int money = 50;
    public Text moneyText;
    public Image healthBar;
    public GameObject selectedUnit;
    public Canvas unitUI;
    public Camera cam;
    public Text winloss;

    public GameObject panel;

    public GameObject WolfPrefab;
   

    GameObject dmgText;
    GameObject dmg;
    GameObject rangeText;
    GameObject range;
    void Start()
    {
        range = GameObject.Find("Upgrade Range");
        dmg = GameObject.Find("Upgrade Damage");


        rangeText = GameObject.Find("RangeText");
        dmgText = GameObject.Find("DamageText");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        UpdateUnitUI();
        CheckLoss();

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 9999))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Tower"))
                {
                    if (selectedUnit != null)
                    {
                        selectedUnit.transform.position -= Vector3.up*.2f;
                        
                    }
                    selectedUnit = hit.collider.gameObject;
                    selectedUnit.transform.position += Vector3.up * .2f;
                }
                else
                {
                    if (selectedUnit != null)
                    {
                        selectedUnit.transform.position -= Vector3.up * .2f;
                        selectedUnit = null;


                    }
                }
            }
            else
            {
                // If we got here, it means that the raycast didn't hit anything, so let's deselect.
                if (selectedUnit != null)
                {
                    selectedUnit.transform.position -= Vector3.up * .2f;
                    selectedUnit = null;

                    
                }
            }
        }
    }


    void UpdateUI()
    {
        moneyText.text = "$" + money;
        healthBar.fillAmount = health / 25.0f;
        

    }

    void UpdateUnitUI()
    {
        if (selectedUnit != null)
        {
            range.SetActive(true);
            dmg.SetActive(true);


            rangeText.SetActive(true);
            dmgText.SetActive(true);

            GameObject.Find("Upgrade Range").transform.position = Camera.main.WorldToScreenPoint(selectedUnit.transform.position + Vector3.up);
            GameObject.Find("Upgrade Damage").transform.position = Camera.main.WorldToScreenPoint(selectedUnit.transform.position + Vector3.up * 1.75f);
            //unitUI.transform.position = selectedUnit.transform.position + Vector3.up;
            GameObject.Find("RangeText").GetComponent<Text>().text = "Upgrade Range ($50) " + selectedUnit.GetComponent<TowerScript>().range;
            GameObject.Find("DamageText").GetComponent<Text>().text = "Upgrade Damage ($50) " + selectedUnit.GetComponent<TowerScript>().damage;
        } else
        {
            range.SetActive(false);
            dmg.SetActive(false);


            rangeText.SetActive(false);
            dmgText.SetActive(false);
        }
    }


    void CheckLoss()
    {
        if (health <= 0)
        {
            panel.SetActive(true);
            winloss.text = "You Lose!!! You let the wolves in the house!!";
        }

    }

    public void Win ()
    {
        if (health <= 0)
        {
            return;
        } else
        {
            winloss.text = "You Win!! You kept the wolves out of the house!!";
            panel.SetActive(true);
        }
    }

    public void newgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void updateRange ()
    {
        if (selectedUnit == null || money < 50)
        {
            return;
        } else
        {
            money -= 50;
            selectedUnit.GetComponent<TowerScript>().range += .5f;
        }
    }

    public void updateDamage()
    {
        if (selectedUnit == null || money < 50)
        {
            return;
        }
        else
        {
            money -= 50;
            selectedUnit.GetComponent<TowerScript>().damage++;
        }
    }
}
