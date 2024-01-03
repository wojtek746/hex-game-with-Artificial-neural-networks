using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private Material material;
    private bool isFading = false;
    private float fadeDuration = 1f; // Czas trwania efektu zanikania
    private float startTime;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        StartFadeOut(); 
    }

    void Update()
    {
        if (isFading)
        {
            float elapsed = Time.time - startTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            material.color = new Color(material.color.r, material.color.g, material.color.b, alpha);

            if (material.color.a >= 1f)
            {
                isFading = false;
            }
        }
    }

    public void StartFadeOut()
    {
        isFading = true;
        startTime = Time.time;
    }
}
