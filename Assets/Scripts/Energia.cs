using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Energia : MonoBehaviour
{
    public TMP_Text[] energiasav_text;
    private int enegiasav_index = 0;

    public int getEnergiasavIndex() { return enegiasav_index; }
    public void setEnegiasavIndex(int ertek) { enegiasav_index = ertek; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void csokkenEnergia() {
        if (enegiasav_index > 29) return;

        energiasav_text[getEnergiasavIndex()].text = "X";
        setEnegiasavIndex(getEnergiasavIndex() + 1);

        Debug.Log("energia csokkent");
    }
}
