using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fps : MonoBehaviour
{
    public TMP_Text fpsText;

    // Update is called once per frame
    void Update()
    {
        int current = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = "Fps: " + current.ToString();
    }
}
