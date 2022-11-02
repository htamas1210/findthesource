using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
   public void testPass() {
        Debug.Log("Passhthrough test: " + FindObjectOfType<Dice>().getDices()[0]);
        Debug.Log("Passhthrough test: " + FindObjectOfType<Dice>().getDices()[1]);
   }

    public void test2() {
        var upgrade = FindObjectOfType<Upgrade>();
        Debug.Log("akcio: " + upgrade.akcio[upgrade.getAkcioIndex()]);
    }
}
