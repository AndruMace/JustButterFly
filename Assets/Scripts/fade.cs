using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fade : MonoBehaviour
{

    TextMeshProUGUI[] text;
    Image[] image;

    // Start is called before the first frame update
    void Start()
    {
        // text = gameObject.GetComponent<TextMeshProUGUI>
        // image = gameObject.GetComponent<Image>
        StartCoroutine(fadeOut());
    }

    // Update is called once per frame
    IEnumerator fadeOut()
    {
        text = GetComponentsInChildren<TextMeshProUGUI>();
        image = GetComponentsInChildren<Image>();

        Color originalTextColor = text[0].color;
        Color originalImageColor = image[0].color;

        for(float t = 0.01f; t < 3; t += Time.deltaTime)
        {
            text[0].color = Color.Lerp(originalTextColor, Color.clear, Mathf.Min(1, t/3));
            image[0].color = Color.Lerp(originalImageColor, Color.clear, Mathf.Min(1, t/3));
            yield return null;
        }
    }
}
