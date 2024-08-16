using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string fullText = "MEGAMEGO";
    public float typingSpeed = 0.1f;

    private void Start()
    {
        textMeshPro.text = "";
    }

    // 로고 애니메이션이 끝난 후 호출할 메서드
    public void StartTypingEffect()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        foreach (char letter in fullText.ToCharArray())
        {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
