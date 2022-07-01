using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenTrigger : MonoBehaviour
{
    //public AudioSource audioSfxGolden;
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory PInventory = other.GetComponent<PlayerInventory>();

        if (PInventory != null)
        {
            PInventory.GoldenCollect();
            //audioSfxGolden.Play();
            gameObject.SetActive(false);
        }
    }
}
