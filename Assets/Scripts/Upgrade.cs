using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public readonly int[] energia = { 3, 3, 2, 2, 1 };
    public readonly int[] akcio = { 0, 0, 1, 1, 2 };
    public readonly int[] harc = { 1, 1, 2, 2, 3 };
    public readonly int[] ujradobas = { 0, 1, 2, 3, 4 };
    public readonly int[] hack = { 4, 3, 2, 1 };

    private int energia_index, akcio_index, harc_index, ujradobas_index, hack_index = 0;

    private int getEnergiaIndex() { return energia_index; }
    private int getAkcioIndex() { return akcio_index; }
    private int getHarcIndex() { return harc_index; }
    private int getUjradobasIndex() { return ujradobas_index; }
    private int getHackIndex() { return hack_index; }

    public void upgradeEnergia() {
        energia_index++;
    }

    public void upgradeAkcio() {
        akcio_index++;
    }

    public void upgradeHarc() {
        harc_index++;
    }

    public void upgradeUjradobas() {
        ujradobas_index++;
    }

    public void upgradeHack() {
        hack_index++;
    }
}
