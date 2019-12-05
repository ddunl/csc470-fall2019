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

    void LoadJogger (int health, float speed)
    {
        GameObject Jogger = Instantiate(JoggerPrefab, new Vector3(4, 2, -5), Quaternion.identity);

        JoggerScript js = Jogger.GetComponent<JoggerScript>();

        js.speed = speed;
        js.health = health;
    }


    IEnumerator Waves()
    {
        for (int i = 0; i < 10; i++)
        {
            LoadJogger(100, 5);
            yield return new WaitForSeconds(1);
        }
    }
}
