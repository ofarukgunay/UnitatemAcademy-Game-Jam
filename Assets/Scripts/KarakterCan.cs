using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KarakterCan : MonoBehaviour
{
    public int maksCan = 100;
    public int suankiCan;
    public bool canlý = true;

    void Start()
    {
        suankiCan = maksCan;
       
    }

    public void HasarAl(int hasarMiktari)
    {
        if (!canlý)
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
        canlý = false;
        gameObject.SetActive(false);
    }
}


