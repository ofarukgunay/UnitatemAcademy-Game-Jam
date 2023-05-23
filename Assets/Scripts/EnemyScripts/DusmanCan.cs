using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanCan : MonoBehaviour
{
    public int maksCan = 100;
    public int suankiCan;
    public bool canli = true;
    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        suankiCan = maksCan;
    }

    public void HasarAl(float hasarMiktari)
    {
        if (!canli)
        {
            return;
        }

        suankiCan -= (int)hasarMiktari;

        if (suankiCan <= 0)
        {
            Ol();
        }
    }

    private void Ol()
    {
        canli = false;
        gameObject.SetActive(false);
    }
}


