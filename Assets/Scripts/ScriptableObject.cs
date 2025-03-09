using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scrictable object/Item")]
public class Item : ScriptableObject
{

    [Header("Only gameplay")]
    public TileBase title;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 5);

    [Header("Only UI")]
    public bool stackable = true;
    [Header("Both")]
    public Sprite image;

}

public enum ItemType
{
    Food,
    Tool,
    Fuel
}
public enum ActionType
{
    Eat,
    Cook
}