using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitapManager : MonoBehaviour
{
    public GameObject _satirBir;
    public GameObject _satirIki;
    public GameObject girisSenaryo;
    public float _satirIkiDelay;
    private IEnumerator Delay()
    {
        yield return new WaitForSecondsRealtime(1.87f);
        _satirBir.SetActive(true);
    }
    private IEnumerator Delay2()
    {
        yield return new WaitForSecondsRealtime(1.25f);
        girisSenaryo.SetActive(true);
    }

    private IEnumerator Delay3()
    {
        yield return new WaitForSecondsRealtime(_satirIkiDelay);
        _satirIki.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(Delay());
        StartCoroutine(Delay2());
        StartCoroutine(Delay3());
        _satirBir.SetActive(false);
        _satirIki.SetActive(false);
        girisSenaryo.SetActive(false);
    }



}
