using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public GameManager GM;
    public GameObject JoggerPrefab;
    public Text WaveNumber;
    int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waves());
    }

    // Update is called once per frame
    void Update()
    {
        WaveNumber.text = "Wave " + num;
    }

    JoggerScript LoadJogger (int health)
    {
        GameObject Jogger = Instantiate(JoggerPrefab, new Vector3(4, 2, -5), Quaternion.identity);

        JoggerScript js = Jogger.GetComponent<JoggerScript>();

       
        js.health = health;

        return js;
    }


    IEnumerator Waves()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < i*5 + 10; j++)
            {
                var Jogger = LoadJogger(1);
                Jogger.setDeltas(i + 10, i  + 10, 0);
                yield return new WaitForSeconds(1);
            }
            num++;
            GM.money += 100 + i * 10;
            yield return new WaitForSeconds(25);
        }

        GM.Win();

    }
}
