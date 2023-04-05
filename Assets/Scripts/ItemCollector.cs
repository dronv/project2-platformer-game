using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// picing up collctibles (for now just keys)
// TODO : PowerUps/Healpotions
public class ItemCollector : MonoBehaviour
{
    private int collected_keys = 0;

    [SerializeField] private TextMeshProUGUI collectedKeysText;
    [SerializeField] public AudioSource collect_keys_sound;

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.CompareTag("Key"))
        {   
            collect_keys_sound.Play();
            Destroy(collison.gameObject);
            collected_keys +=1;

            collectedKeysText.text = "Keys " + collected_keys + "/3";
            }
    }
}
