using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    public Sprite[] diceSides = new Sprite[6];

    private SpriteRenderer rend;

	private void Start () {
        //Debug.Log("in");

        rend = GetComponent<SpriteRenderer>();
        
        // Innen szedi a képeket
        //diceSides = Resources.LoadAll<Sprite>("\\Dice");

        /*foreach (var t in diceSides) {
            Debug.Log(t.name);
        }*/
    }
	
    // Ha rákattintassz meghívja a RollTheDice-ot
    public void OnMouseDown()
    {
        StartCoroutine("RollTheDice");
    }

    // A RollTheDice
    private IEnumerator RollTheDice()
    {
        
        int randomDiceSide = 0;
        int finalSide = 0;


        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 5);

            rend.sprite = diceSides[Random.Range(0, 5)];
            rend.size = new Vector2(38, 38);

            yield return new WaitForSeconds(0.05f);
        }

        finalSide = randomDiceSide + 1;
        Debug.Log(finalSide);
    }
}
