using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KarakterCan : MonoBehaviour
{
    public int maksCan = 100;
    public int suankiCan;
    public bool canl� = true;

    void Start()
    {
        suankiCan = maksCan;
       
    }

    public void HasarAl(int hasarMiktari)
    {
        if (!canl�)
        {
            return;
        }

        suankiCan -= hasarMiktari;


        if (suankiCan <= 0)
        {
            Ol();
        }
    }

    void Ol()
    {
        canl� = false;
        gameObject.SetActive(false);
    }
}


