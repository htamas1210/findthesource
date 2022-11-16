using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nyomozas : MonoBehaviour
{
    public movement movement;
    private string[,] nyomozasok =
    {
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"ures", "ures", "ures", "" },
        {"", "", "", "" }
    };
    int jelenlegi_x;
    int jelenlegi_y;

    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<movement>();

        
    }

    // Update is called once per frame
    void Update()
    {
        int jelenlegi_x = movement.jelenlegi_x;
        int jelenlegi_y = movement.jelenlegi_y;
    }

    public void Nyomozas()
    {
        int atirandox = (jelenlegi_x -1);
        int atirandoy = (jelenlegi_y - 1);
        nyomozasok[atirandoy, atirandox] = "nyomozott";
    }
}
