using UnityEngine;

[CreateAssetMenu(menuName = "Player/PlayerData", fileName = "PlayerData", order = 51)]
public class PlayerData : ScriptableObject
{
    public string Name;
    public Color Color;

    public Inventory Inventory;
}
