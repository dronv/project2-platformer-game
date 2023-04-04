using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int collected_keys = 0;

    [SerializeField] private TextMeshProUGUI collectedKeysText;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.CompareTag("Key"))
        {
            Destroy(collison.gameObject);
            collected_keys +=1;

            collectedKeysText.text = "Keys " + collected_keys;        }
    }
}
