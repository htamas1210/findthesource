using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyomozas : MonoBehaviour
{
    private movement movement;
    private Akciopont ap;

    private string[,] nyomozasok =
    {
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"", "", "", "" }
    };
    //int jelenlegi_x;
    //int jelenlegi_y;

    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<movement>();   
        ap = FindObjectOfType<Akciopont>();
    }

    // Update is called once per frame
    /*void Update()
    {
        int jelenlegi_x = movement.jelenlegi_x;
        int jelenlegi_y = movement.jelenlegi_y;
    }*/

    public void Nyomozas()
    {
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
