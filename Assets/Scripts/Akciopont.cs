using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Akciopont : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;    
    private int akciopont = 0;

    public int getAkciopont(){ return akciopont; }

    private void Start(){
        setText();
    }

    private void setText(){
        _text.text = "Akciopontok: " + akciopont;
    }

    public void UpdateAkciopont(int number) {
        akciopont += number;
        setText();
    }

    public void resetAkciopont() {
        akciopont = 0;
        setText();
    }
}
