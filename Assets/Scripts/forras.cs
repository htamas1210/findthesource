using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forras : MonoBehaviour
{
    int hackcounter = 0;
    private int[] sourcegenerate = new int[4];
    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Generate()
    {
        for (int i = 0; i < 2; i++)
        {
            if (hackcounter == 0)
            {
                int random = UnityEngine.Random.Range(0, 2);
                sourcegenerate[1] = random;
                //Debug.Log(sourcegenerate[0]);
                hackcounter++;
            }
            if (hackcounter == 1)
            {
                int random = UnityEngine.Random.Range(0, 3);
                sourcegenerate[2] = random;
                //Debug.Log(sourcegenerate[1]);
                hackcounter++;
            }
            if (hackcounter == 2)
            {
                int random = UnityEngine.Random.Range(0, 1);
                sourcegenerate[3] = random;
                //Debug.Log(sourcegenerate[2]);
                hackcounter++;
            }
            if (hackcounter == 3)
            {
                hackcounter = 0;
                break;
            }

        }
        for (int i = 0; i < sourcegenerate.Length; i++)
        {
            Debug.Log(sourcegenerate[i]);
        }
        
    }
}
