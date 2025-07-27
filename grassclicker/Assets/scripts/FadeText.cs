using UnityEngine;
using TMPro;
using System.Collections;

public class FadeText : MonoBehaviour
{
    public static FadeText Instance;

    public TextMeshProUGUI feedbackText;
    public CanvasGroup textGroup;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void ShowMessage(string message)
    {
        feedbackText.text = message;
        StopAllCoroutines();
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        textGroup.alpha = 1;
        yield return new WaitForSeconds(1f);

        float fadeDuration = 1f;
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            textGroup.alpha = Mathf.Lerp(1, 0, t / fadeDuration);
            yield return null;
        }
    }
}