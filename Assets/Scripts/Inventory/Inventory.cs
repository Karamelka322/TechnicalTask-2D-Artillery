using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Player/Inventory", order = 51)]
public class Inventory : ScriptableObject
{
    public Spell[] Spells;
}
