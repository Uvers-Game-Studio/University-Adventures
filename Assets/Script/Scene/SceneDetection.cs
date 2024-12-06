using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "lobby1")
        {
            SceneManagement.instance1.lobby1();
        }
        if (collision.gameObject.tag == "lobby2")
        {
            SceneManagement.instance1.lobby2();
        }
        if (collision.gameObject.tag == "Kitchen")
        {
            SceneManagement.instance1.kitchen();
        }
        if (collision.gameObject.tag == "Outdoor")
        {
            SceneManagement.instance1.Ourdoor();
        }
        if (collision.gameObject.tag == "Canteen")
        {
            SceneManagement.instance1.canteen();
        }
    }
}
