using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public float _satirIkiDelay;
    public float _yazilarAras�Delay;

    private void Start()
    {
        StartCoroutine(YaziYazdir(text1, "Y�llar �nce b�y�c�l�k e�itimi veren tek okul olmas�yla �nl� Unitatem Akademisi, �zel g��leri kontrol edebilecek olan b�t�n �ocuklar� topluyordu. Uzun y�llar boyunca ��renciler birliktelik, yard�mla�ma ve beraberlikleriyle Unitatem Akademisinin ad�n� t�m d�nyaya duyurdular.\r\n \r\nLakin, i�erideki herkes masum de�ildi... \r\nKara b�y�y� ke�feden baz� ��renciler, g��lerini di�er ��renciler �zerinde test etmeye karar vermi�ti. ��retmenler ve ��renciler ise kendilerini koruyabilmek ad�na kar�� koyduklar�nda akademi i�erisinde inan�lmaz bir y�k�m ortaya ��km��t�. "));
        StartCoroutine(YaziYazdir2(text2, "Kara b�y�y� ke�feden ��renciler Unitatem Akademisinden sonsuza kadar at�ld�klar�nda, kendi akademilerini kurmaya karar verdiler. Somber Akademisi olarak kurduklar� bu akademi ise sadece kara b�y� ��renimini i�eriyordu. Somber Akademisi e�itimlerinde kara b�y�den olu�turulan yarat�klar ise Unitatem Akademisi'nin duvarlar�na dayanm��, ��rencilerin b�y�k bir sorunu haline gelmeye ba�lam��t�..."));
    }

    IEnumerator YaziYazdir(TextMeshProUGUI textMesh, string yazi)
    {
        textMesh.maxVisibleCharacters = 0;

        while (textMesh.maxVisibleCharacters < yazi.Length)
        {
            textMesh.maxVisibleCharacters++;
            yield return new WaitForSeconds(_yazilarAras�Delay);
        }
    }
    IEnumerator YaziYazdir2(TextMeshProUGUI textMesh, string yazi)
    {
        yield return new WaitForSeconds(_satirIkiDelay);
        textMesh.maxVisibleCharacters = 0;

        while (textMesh.maxVisibleCharacters < yazi.Length)
        {
            textMesh.maxVisibleCharacters++;
            yield return new WaitForSeconds(_yazilarAras�Delay);
        }
    }
}
