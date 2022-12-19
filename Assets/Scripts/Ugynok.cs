using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ugynok : MonoBehaviour
{
    public TMP_Text[] oneone;
    public TMP_Text[] twoone;
    public TMP_Text[] threeone;
    public TMP_Text[] onetwo;
    public TMP_Text[] twotwo;
    public TMP_Text[] threetwo;
    public TMP_Text[] onethree;
    public TMP_Text[] twothree;
    public TMP_Text[] threethree;
    public TMP_Text[] onefour;
    public TMP_Text[] twofour;
    public TMP_Text[] threefour;

    private void Start() {
        foreach(var item in oneone) {
            item.text = "";
        }
    }

    public void UgynokSorsolas(int x, int y) {
        if (x == 1 && y == 1) {
            if (oneone[0].text.Equals("")) {
                oneone[0].text = UnityEngine.Random.Range(1, 7).ToString();
            }else if (oneone[1].text.Equals("")) {
                oneone[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }else if (oneone[2].text.Equals("")) {
                oneone[1].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 1 && y == 2) {
            if (onetwo[0].text.Equals("")) {
                onetwo[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (onetwo[1].text.Equals("")) {
                onetwo[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (onetwo[2].text.Equals("")) {
                onetwo[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 1 && y == 3) {
            if (onethree[0].text.Equals("")) {
                onethree[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (onethree[1].text.Equals("")) {
                onethree[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (onethree[2].text.Equals("")) {
                onethree[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 1 && y == 4) {
            if (onefour[0].text.Equals("")) {
                onefour[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (onefour[1].text.Equals("")) {
                onefour[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (onefour[2].text.Equals("")) {
                onefour[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 2 && y == 1) {
            if (twoone[0].text.Equals("")) {
                twoone[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (twoone[1].text.Equals("")) {
                twoone[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (twoone[2].text.Equals("")) {
                twoone[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 2 && y == 2) {
            if (twotwo[0].text.Equals("")) {
                twotwo[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (twotwo[1].text.Equals("")) {
                twotwo[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (twotwo[2].text.Equals("")) {
                twotwo[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 2 && y == 3) {
            if (twothree[0].text.Equals("")) {
                twothree[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (twothree[1].text.Equals("")) {
                twothree[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (twothree[2].text.Equals("")) {
                twothree[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 2 && y == 4) {
            if (twofour[0].text.Equals("")) {
                twofour[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (twofour[1].text.Equals("")) {
                twofour[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (twofour[2].text.Equals("")) {
                twofour[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 3 && y == 1) {
            if (threeone[0].text.Equals("")) {
                threeone[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (threeone[1].text.Equals("")) {
                threeone[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (threeone[2].text.Equals("")) {
                threeone[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 3 && y == 2) {
            if (threetwo[0].text.Equals("")) {
                threetwo[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (threetwo[1].text.Equals("")) {
                threetwo[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (threetwo[2].text.Equals("")) {
                threetwo[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 3 && y == 3) {
            if (threethree[0].text.Equals("")) {
                threethree[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (threethree[1].text.Equals("")) {
                threethree[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (threethree[2].text.Equals("")) {
                threethree[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        } else if (x == 3 && y == 4) {
            if (threefour[0].text.Equals("")) {
                threefour[0].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (threefour[1].text.Equals("")) {
                threefour[1].text = UnityEngine.Random.Range(1, 7).ToString();
            } else if (threefour[2].text.Equals("")) {
                threefour[2].text = UnityEngine.Random.Range(1, 7).ToString();
            }
        }
    }



}
