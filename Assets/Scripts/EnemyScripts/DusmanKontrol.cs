using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class DusmanKontrol : MonoBehaviour
{
    [SerializeField] float takipHizi = 2f;
    [SerializeField] float saldiriMesafesi = 2f;
    bool hasaraldý;
    private Transform oyuncuTransformu;
    private Animator animator;
    private bool saldiriYapiliyor;
    public float itmeGucu = 100f;
    bool volumeacýk;
    private void Start()
    {
        oyuncuTransformu = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Oyuncunun pozisyonuna doðru hareket et
        Vector3 oyuncuYonu = oyuncuTransformu.position - transform.position;
        float mesafeOyuncuya = oyuncuYonu.magnitude;
        oyuncuYonu.Normalize();

        // Düþmanýn oyuncunun arkasýna dönmesi
        Quaternion hedefRotasyon = Quaternion.LookRotation(oyuncuYonu);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, hedefRotasyon, 360f);

        // Düþmanýn hareket etmesi
        transform.position += transform.forward * takipHizi * Time.deltaTime;

        // Oyuncuya yeterince yakýnsan saldýrýyý baþlat
        if (mesafeOyuncuya <= saldiriMesafesi && !saldiriYapiliyor)
        {
            saldiriYapiliyor = true;
            animator.SetBool("Saldýrý", true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasaraldý = true;
            // Oyuncuya temas edildi, saldýrýyý baþlat
            saldiriYapiliyor = true;
            animator.SetBool("Saldýrý", true);
            
            if (hasaraldý)
            {

               Rigidbody rb2 = other.GetComponent<Rigidbody>();
               Volume karaktervolume = other.GetComponent<Volume>();

               Vector3 itmeYonu = (other.transform.position - transform.position).normalized;
               rb2.AddForce(Vector3.left * itmeGucu, ForceMode.Impulse);
               StartCoroutine(hasarefektidelay());
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncudan ayrýldý, saldýrýyý durdur
            saldiriYapiliyor = false;
            animator.SetBool("Saldýrý", false);
        }
    }
    IEnumerator hasarefektidelay()
    {
        
        hasaraldý = false;
        yield return new WaitForSecondsRealtime(1.5f);
        hasaraldý = true;
    }
}
