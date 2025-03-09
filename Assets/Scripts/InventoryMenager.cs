using UnityEngine;

public class InventoryMenager : MonoBehaviour
{
    public Item[] startItems;
    public int maxStackedItems = 3;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlot = -1;

    private void Start()
    {
        ChangeSlecectedSlot(0);
        foreach (var item in startItems){
            AddItem(item);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSlecectedSlot(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSlecectedSlot(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSlecectedSlot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeSlecectedSlot(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeSlecectedSlot(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeSlecectedSlot(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ChangeSlecectedSlot(6);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            ChangeSlecectedSlot(7);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            ChangeSlecectedSlot(8);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            ChangeSlecectedSlot(9);
        }
    }

    void ChangeSlecectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
            inventorySlots[selectedSlot].DeSelect();

        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }
    public bool AddItem(Item item)
    {
        // Check if slot is the same
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems
            && itemInSlot.item.stackable == true)
            {

                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        // Find empty Slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DraggableItem inventoryItem = newItemGo.GetComponent<DraggableItem>();
        inventoryItem.InitialiseItem(item);
    }
    public Item GetSelectedItem(bool use) {
        InventorySlot slott = inventorySlots[selectedSlot];
        DraggableItem itemInSlot = slott.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null) {
                Item itemm = itemInSlot.item;
                if (use == true){
                    itemInSlot.count--;
                    if (itemInSlot.count <= 0){
                        Destroy(itemInSlot.gameObject);
                    } else {
                        itemInSlot.RefreshCount();
                    }
                }
                return itemm;
            }

            return null;
    }
}
