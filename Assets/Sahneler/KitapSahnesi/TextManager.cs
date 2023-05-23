using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public float _satirIkiDelay;
    public float _yazilarArasýDelay;

    private void Start()
    {
        StartCoroutine(YaziYazdir(text1, "Yýllar önce büyücülük eðitimi veren tek okul olmasýyla ünlü Unitatem Akademisi, özel güçleri kontrol edebilecek olan bütün çocuklarý topluyordu. Uzun yýllar boyunca öðrenciler birliktelik, yardýmlaþma ve beraberlikleriyle Unitatem Akademisinin adýný tüm dünyaya duyurdular.\r\n \r\nLakin, içerideki herkes masum deðildi... \r\nKara büyüyü keþfeden bazý öðrenciler, güçlerini diðer öðrenciler üzerinde test etmeye karar vermiþti. Öðretmenler ve öðrenciler ise kendilerini koruyabilmek adýna karþý koyduklarýnda akademi içerisinde inanýlmaz bir yýkým ortaya çýkmýþtý. "));
        StartCoroutine(YaziYazdir2(text2, "Kara büyüyü keþfeden öðrenciler Unitatem Akademisinden sonsuza kadar atýldýklarýnda, kendi akademilerini kurmaya karar verdiler. Somber Akademisi olarak kurduklarý bu akademi ise sadece kara büyü öðrenimini içeriyordu. Somber Akademisi eðitimlerinde kara büyüden oluþturulan yaratýklar ise Unitatem Akademisi'nin duvarlarýna dayanmýþ, öðrencilerin büyük bir sorunu haline gelmeye baþlamýþtý..."));
    }

    IEnumerator YaziYazdir(TextMeshProUGUI textMesh, string yazi)
    {
        textMesh.maxVisibleCharacters = 0;

        while (textMesh.maxVisibleCharacters < yazi.Length)
        {
            textMesh.maxVisibleCharacters++;
            yield return new WaitForSeconds(_yazilarArasýDelay);
        }
    }
    IEnumerator YaziYazdir2(TextMeshProUGUI textMesh, string yazi)
    {
        yield return new WaitForSeconds(_satirIkiDelay);
        textMesh.maxVisibleCharacters = 0;

        while (textMesh.maxVisibleCharacters < yazi.Length)
        {
            textMesh.maxVisibleCharacters++;
            yield return new WaitForSeconds(_yazilarArasýDelay);
        }
    }
}
