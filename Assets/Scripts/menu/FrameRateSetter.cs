using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    //mobil miatt volt (30fps) van ertelme? nincs sok mozgas es animacio \\ ha lesz animacio vissza rakhato
    private void Awake() {
        Application.targetFrameRate = 60;
    }
}