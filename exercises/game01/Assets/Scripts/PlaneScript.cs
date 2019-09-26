using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneScript : MonoBehaviour
{
    public GameObject gameCam;
    public GameObject model;
    public Text scoreboard;
    public GameObject ringPrefab;
    private int score = 0;
    public float movespeed = 5f;
    public float timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -1 * movespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -1 * movespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
        }
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * 100f);

        gameCam.transform.position = transform.position - transform.forward * 8 + transform.up * 3;
        gameCam.transform.LookAt(transform);

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "ring")
        {
            timer += 10f;
            score++;
            scoreboard.text = "Score: " + score;
            Destroy(other.gameObject);

            var newobj = Instantiate(ringPrefab, transform.position + transform.forward * 10 + transform.right * Random.Range(-5, 5), Quaternion.identity);
         
        }

    }
}
