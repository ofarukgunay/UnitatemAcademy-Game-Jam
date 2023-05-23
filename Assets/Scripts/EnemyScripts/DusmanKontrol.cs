using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class DusmanKontrol : MonoBehaviour
{
    [SerializeField] float takipHizi = 2f;
    [SerializeField] float saldiriMesafesi = 2f;
    bool hasarald�;
    private Transform oyuncuTransformu;
    private Animator animator;
    private bool saldiriYapiliyor;
    public float itmeGucu = 100f;
    bool volumeac�k;
    private void Start()
    {
        oyuncuTransformu = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Oyuncunun pozisyonuna do�ru hareket et
        Vector3 oyuncuYonu = oyuncuTransformu.position - transform.position;
        float mesafeOyuncuya = oyuncuYonu.magnitude;
        oyuncuYonu.Normalize();

        // D��man�n oyuncunun arkas�na d�nmesi
        Quaternion hedefRotasyon = Quaternion.LookRotation(oyuncuYonu);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, hedefRotasyon, 360f);

        // D��man�n hareket etmesi
        transform.position += transform.forward * takipHizi * Time.deltaTime;

        // Oyuncuya yeterince yak�nsan sald�r�y� ba�lat
        if (mesafeOyuncuya <= saldiriMesafesi && !saldiriYapiliyor)
        {
            saldiriYapiliyor = true;
            animator.SetBool("Sald�r�", true);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasarald� = true;
            // Oyuncuya temas edildi, sald�r�y� ba�lat
            saldiriYapiliyor = true;
            animator.SetBool("Sald�r�", true);
            
            if (hasarald�)
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
            // Oyuncudan ayr�ld�, sald�r�y� durdur
            saldiriYapiliyor = false;
            animator.SetBool("Sald�r�", false);
        }
    }
    IEnumerator hasarefektidelay()
    {
        
        hasarald� = false;
        yield return new WaitForSecondsRealtime(1.5f);
        hasarald� = true;
    }
}
