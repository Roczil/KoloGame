using UnityEngine;

public class Test : MonoBehaviour
{
    public InventoryMenager inventoryMenager;
    public Item[] itemsToPickup;


    public void PickupItem(int id)
    {
        bool result = inventoryMenager.AddItem(itemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("Item Added");
        }
        else
        {
            Debug.Log("Item not added");
        }
    }
}
