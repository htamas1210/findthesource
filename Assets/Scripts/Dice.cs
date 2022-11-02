using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading.Tasks;
using System.Threading;

public class Dice : MonoBehaviour {

    public Sprite[] diceSides = new Sprite[6];

    public SpriteRenderer hely1;
    public SpriteRenderer hely2;

    public int[] diceResult = new int[2];

    private void Start() {
        //renderer = go.GetComponent<SpriteRenderer>();
    }

    // Ha rákattintassz meghívja a RollTheDice-ot
    /*public void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }*/

    // A RollTheDice
    /*private IEnumerator RollTheDice()
    {
        
        int randomDiceSide = 0;
        int finalSide = 0;


        for (int i = 0; i < 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);

            rend.sprite = diceSides[Random.Range(0, 5)];
            rend.size = new Vector2(38, 38);

            yield return new WaitForSeconds(0.05f);
        }

        finalSide = randomDiceSide + 1;
        Debug.Log(finalSide);
    }*/

    public int RollDice(SpriteRenderer renderer) {
        int randomDiceSide = 0;
        int finalSide = 0;

        for (int i = 0; i < 20; i++) {
            randomDiceSide = Random.Range(0, 5);

            renderer.sprite = diceSides[Random.Range(0, 5)];
            renderer.size = new Vector2(38, 38);

            //yield return new WaitForSeconds(0.05f);
            Thread.Sleep(500);
        }

        finalSide = randomDiceSide + 1;
        Debug.Log(finalSide);

        return finalSide;
    }

    public void renderDice(GameObject go) {
        do {
            diceResult[0] = RollDice(hely1);
            diceResult[1] = RollDice(hely2);
        } while (diceResult[0] == diceResult[1]);

        hely1.sprite = diceSides[diceResult[0]];
        hely1.size = new Vector2(38, 38);

        hely2.sprite = diceSides[diceResult[0]];
        hely2.size = new Vector2(38, 38);
    }
}
