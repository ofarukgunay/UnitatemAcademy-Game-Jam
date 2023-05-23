using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    public GameObject karakter;
    public float h�z = 5f;
    public float z�plamag�c� = 5f;
    private Rigidbody rb;
    private bool sagabak�yor;
    private Animator anim;
    public Avatar idleavatar;
    public Avatar yurumeavatar;
    private bool dondurmeAktif = true;
    [SerializeField] GameObject saldiriEfektiPrefab;
    [SerializeField] float efektSure = 0.4f;
    private bool saldiriYapiliyor = false;
    public Transform efektpozisyon;
    void Start()
    {
        
        anim = GetComponent<Animator>();//animasyon cacheleniyor
        rb = GetComponent<Rigidbody>();//rigidbody cacheleniyor
        sagabak�yor = true; //sa�abakarakba�l�yoruz
    }

    void Update()
    {
        Hareket();//hareket fonksiyonunu �al��t�r
    }


    private void Hareket()
    {
        float hareketgirdisi = Input.GetAxisRaw("Horizontal");//sa� ve sol girdilerini al
        rb.velocity = new Vector2(hareketgirdisi * h�z * Time.deltaTime, rb.velocity.y);//hareket et

        if (hareketgirdisi > 0 && !sagabak�yor)//sa�a gidiyor ve sa�a bakm�yorsa d�nd�r
        {
            Dondur();
        }
        else if (hareketgirdisi < 0 && sagabak�yor)//ssola gidiyor ve sola bakm�yorsa d�nd�r
        {
            Dondur();
        }

        if (Input.GetMouseButtonDown(0)&&!saldiriYapiliyor)//mousenin sol t�k�n� bas�ld���nda sald�rs�n
        {
            anim.SetBool("sald�r�yor", true);
            dondurmeAktif = false;
            saldiriYapiliyor = true;
            

            
            StartCoroutine(SaldiriDurumunuSifirla(efektSure));
        }
        else
        {
            anim.SetBool("sald�r�yor", false);
            
            dondurmeAktif = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))//spaceye bas�ld���nda takla ats�n
        {
            anim.SetBool("taklaat�yor", true);
            dondurmeAktif = false;
        }
        else
        {
            anim.SetBool("taklaat�yor", false);
            dondurmeAktif = true;
        }

       

        anim.SetBool("y�r�yor", hareketgirdisi != 0 && !Input.GetKey(KeyCode.LeftShift));//shifte bas�lmay�p hareket ediyorsa y�r�yor anim �al��s�n
        anim.SetBool("ko�uyor", hareketgirdisi != 0 && Input.GetKey(KeyCode.LeftShift));//shifte bas�l�p hareket ediyorsa ko�uyor anim �al��s�n
        karakter.GetComponent<Animator>().avatar = idleavatar;
    }

    void Dondur()//dondurme fonksiyonu
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("sald�r�yor") && !anim.GetCurrentAnimatorStateInfo(0).IsName("taklaat�yor"))
        {
            sagabak�yor = !sagabak�yor;
            transform.Rotate(Vector3.up, 180f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("zemin"))
        {
            //yere de�iyor
        }
    }
    private IEnumerator SaldiriDurumunuSifirla(float gecikme)
    {
        if (saldiriYapiliyor)
        {
         yield return new WaitForSeconds(0.5f);
         GameObject saldiriEfekti = Instantiate(saldiriEfektiPrefab, efektpozisyon.position, Quaternion.identity);
         saldiriEfekti.transform.parent = transform;
         Destroy(saldiriEfekti, 2f);
         yield return new WaitForSecondsRealtime(0.5f);
         saldiriYapiliyor = false;
        }

        
      
        
        anim.SetBool("sald�r�yor", false);
        
        dondurmeAktif = true;
    }
}
