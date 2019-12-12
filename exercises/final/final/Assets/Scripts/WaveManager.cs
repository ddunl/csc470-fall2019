using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public GameObject JoggerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waves());
    }

    // Update is called once per frame
    void Update()
    {
        
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
            var jog = LoadJogger(100);
            jog.setDeltas(5, 5, 0);
            yield return new WaitForSeconds(1);
        }
    }
}
