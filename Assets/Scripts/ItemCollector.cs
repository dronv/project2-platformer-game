using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int collected_keys = 0;
    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.CompareTag('Key'))
        {
            Destroy(collison.gameObject);
            collected_keys +=1;
            Debug.Log("Keys: " + collected_keys );
        }
    }
}
