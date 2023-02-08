using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Akciopont : MonoBehaviour
{
    public TMP_Text text;    

    public int akciopont = 0;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Akciopontok: ";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Akciopontok: " + akciopont;
    }

    public void UpdateAkciopont(int number) {
        akciopont += number;
    }

    public void resetAkciopont() {
        akciopont = 0;
    }
}
