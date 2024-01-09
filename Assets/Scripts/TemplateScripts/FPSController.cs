using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSController : MonoBehaviour
{
    float deltaTime = 0.0f;
    public TMP_Text fpsText;


    //FPS G�steren Kod istersek ayarlardan on off diye a��p kapar�z. Kod GPT'den ��kma.
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Round(fps).ToString() + " FPS";
    }
}