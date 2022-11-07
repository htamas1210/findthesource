using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Akciopont : MonoBehaviour
{
    public TMP_Text text;    

    public int akciopontok = 0;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "Akciópontok: ";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Akciópontok: " + akciopontok;
    }

    public void UpdateAkciopont(int number) {
        akciopontok += number;
    }

    public void resetAkciopont() {
        akciopontok = 0;
    }
}
