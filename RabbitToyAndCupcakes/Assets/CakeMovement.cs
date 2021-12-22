using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CakeMovement : MonoBehaviour
{
    public AudioSource Rabbiteat;
    public Text FloorTalking;

    void Update()
    {
        if (GameObject.Find("Canvas").GetComponent<StartgameButton>().gamestarted && GameObject.Find("Player").GetComponent<PlayerMovement>().points < 10)
        {
            transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            FloorTalking.text = "Delicious cake!";
            //Debug.Log("Player");
            Rabbiteat.Play();
            //Destroy(gameObject);
        }
    }
}
