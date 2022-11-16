using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Akciok : MonoBehaviour
{
    //Betarazashoz
    public TMP_Text[] toltenyek;
    private int tolteny_index = 3;
    private int felhasznalt_tolteny = 0;
    public int betarazott_tolteny = 3;
    private Akciopont ap;
    //

    //Nyomozashoz
    private movement movement;
    private string[,] nyomozasok =
    {
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },

    };

    private void Start() {
        ap = FindObjectOfType<Akciopont>();
        movement= FindObjectOfType<movement>();

        //kezdesnel karikazza be az elso harom adott toltenyt
        for (int i = 0; i < tolteny_index; i++) {
            toltenyek[i].text = "O";
        }
    }

    public void Betarazas(int betarazas) {
        if (tolteny_index < 24 && ap.akciopont != 0) {
            if(tolteny_index + betarazas > 23) {
                tolteny_index = 23;
            } else {
                tolteny_index += betarazas;
            }
            //felhasznalt toltenytol megy hogy az ott levo x-et ne irja felul
            for (int i = felhasznalt_tolteny; i < tolteny_index; i++) {
                toltenyek[i].text = "O";
            }

            betarazott_tolteny += betarazas;
            //tolteny_index++;
            ap.akciopont--;

            Debug.Log("Tolteny betarazva");
            Debug.Log("Betarazott toltenyek szama: " + betarazott_tolteny);
        }
    }

    public void Loves(int elhasznalt_toltenyek) {
        if (felhasznalt_tolteny < betarazott_tolteny) {
            if (felhasznalt_tolteny + elhasznalt_toltenyek > betarazott_tolteny) {
                Debug.Log("Nincs eleg tolteny betarazva, tul sok lenne egyszerre felhasznalva!");
                return;
            } else {
                felhasznalt_tolteny += elhasznalt_toltenyek;
                for (int i = 0; i < felhasznalt_tolteny; i++) {
                    toltenyek[i].text = "X";
                }
                betarazott_tolteny -= elhasznalt_toltenyek;
            }
        } else {
            Debug.Log("Nincs eleg tolteny");
        }
    }


    //Nyomozas
    public void Nyomozas() {
        if (ap.akciopont <= 0) {
            Debug.Log("nincs eleg akciopont");
            return;
        }

        ap.akciopont--;

        int atirandox = (movement.jelenlegi_x - 1);
        int atirandoy = (movement.jelenlegi_y - 1);

        if (nyomozasok[atirandox, atirandoy] == "nyomozott") {
            Debug.Log("Itt mar nyomoztal");
            return;
        } else {
            nyomozasok[atirandoy, atirandox] = "nyomozott";
        }

        for (int i = 0; i < nyomozasok.GetLength(0); i++) {
            string sor = "";
            for (int j = 0; j < nyomozasok.GetLength(1); j++) {
                sor += nyomozasok[i, j] + " ";
            }
            Debug.Log(sor);
        }
    }
}
