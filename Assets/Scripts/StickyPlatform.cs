using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// makes the player move with moving platforms he is standing on
public class StickyPlatform : MonoBehaviour
{
    // if player collides with moving gameobject(platform) nest 
    // player under platform to move alongside platform

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    
    // remove player from parent"platform" so he can move 
    // individually again 
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
