using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    public GameObject karakter;
    public float hýz = 5f;
    public float zýplamagücü = 5f;
    private Rigidbody rb;
    private bool sagabakýyor;
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
        sagabakýyor = true; //saðabakarakbaþlýyoruz
    }

    void Update()
    {
        Hareket();//hareket fonksiyonunu çalýþtýr
    }


    private void Hareket()
    {
        float hareketgirdisi = Input.GetAxisRaw("Horizontal");//sað ve sol girdilerini al
        rb.velocity = new Vector2(hareketgirdisi * hýz * Time.deltaTime, rb.velocity.y);//hareket et

        if (hareketgirdisi > 0 && !sagabakýyor)//saða gidiyor ve saða bakmýyorsa döndür
        {
            Dondur();
        }
        else if (hareketgirdisi < 0 && sagabakýyor)//ssola gidiyor ve sola bakmýyorsa döndür
        {
            Dondur();
        }

        if (Input.GetMouseButtonDown(0)&&!saldiriYapiliyor)//mousenin sol týkýný basýldýðýnda saldýrsýn
        {
            anim.SetBool("saldýrýyor", true);
            dondurmeAktif = false;
            saldiriYapiliyor = true;
            

            
            StartCoroutine(SaldiriDurumunuSifirla(efektSure));
        }
        else
        {
            anim.SetBool("saldýrýyor", false);
            
            dondurmeAktif = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))//spaceye basýldýðýnda takla atsýn
        {
            anim.SetBool("taklaatýyor", true);
            dondurmeAktif = false;
        }
        else
        {
            anim.SetBool("taklaatýyor", false);
            dondurmeAktif = true;
        }

       

        anim.SetBool("yürüyor", hareketgirdisi != 0 && !Input.GetKey(KeyCode.LeftShift));//shifte basýlmayýp hareket ediyorsa yürüyor anim çalýþsýn
        anim.SetBool("koþuyor", hareketgirdisi != 0 && Input.GetKey(KeyCode.LeftShift));//shifte basýlýp hareket ediyorsa koþuyor anim çalýþsýn
        karakter.GetComponent<Animator>().avatar = idleavatar;
    }

    void Dondur()//dondurme fonksiyonu
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("saldýrýyor") && !anim.GetCurrentAnimatorStateInfo(0).IsName("taklaatýyor"))
        {
            sagabakýyor = !sagabakýyor;
            transform.Rotate(Vector3.up, 180f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("zemin"))
        {
            //yere deðiyor
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

        
      
        
        anim.SetBool("saldýrýyor", false);
        
        dondurmeAktif = true;
    }
}
