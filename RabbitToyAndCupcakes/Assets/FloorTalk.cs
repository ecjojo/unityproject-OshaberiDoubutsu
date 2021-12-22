using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorTalk : MonoBehaviour
{
    public Text FloorTalking;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Mouse")
        {
            FloorTalking.text = "Oops! The mouse fell to the floor!";
        }
        if (other.gameObject.tag == "Cup")
        {
            FloorTalking.text = "Oops! The Cup fell to the floor!";
        }
        if (other.gameObject.tag == "Book")
        {
            FloorTalking.text = "Oops! The Book fell to the floor!";
        }
        if (other.gameObject.tag == "Lamp")
        {
            FloorTalking.text = "Oops! The Lamp fell to the floor!";
        }
        if (other.gameObject.tag == "Player")
        {
            FloorTalking.text = "Lets eat Cupcake!";
        }
    }
}
