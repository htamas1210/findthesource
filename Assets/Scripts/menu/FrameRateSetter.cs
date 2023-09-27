using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{

    private void Awake() {
#if !UNITY_ANDROID || !UNITY_IOS
        Application.targetFrameRate = 60;
#else
        Application.targetFrameRate = 30;
#endif
    }
}