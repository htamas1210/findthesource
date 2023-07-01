using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Helyszinaktivalas1 : MonoBehaviour
{
    public Helyszin[] helyszinek;

    private movement movement;

    public void SetLepesSzamlalo(int x, int y, string lepesSzam){
        foreach(var item in helyszinek){
            if(item.X == x && item.Y == y){
                if(item.LepesSzamlalo[0].Equals("")){ //ha nincs meg az elsobe beirva
                    item.LepesSzamlalo[0].text = lepesSzam; 
                }else{
                    item.LepesSzamlalo[1].text = lepesSzam;
                }
            }
        }
    }

    public void HelyszinAktivalas() {
        int x = movement.jelenlegi_x - 1;
        int y = movement.jelenlegi_y - 1;

        foreach (var item in helyszinek){
            throw new NotImplementedException();
        }
    }

    private void Start() {
        movement = FindObjectOfType<movement>();
    }
}
