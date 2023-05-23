using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hasar : MonoBehaviour
{
    public int hasarMiktari = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Dusman"))
        {
            DusmanCan dusmanCan = other.GetComponent<DusmanCan>();          
           dusmanCan.HasarAl(hasarMiktari);
           Destroy(gameObject,0.5f);
        }
    }
}