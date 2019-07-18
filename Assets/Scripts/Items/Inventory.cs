using UnityEngine;

public class Inventory
{
    private InventoryItem[] items;
    private int maxSize;

    public Inventory(int maxSize)
    {
        this.maxSize = maxSize;
        items = new InventoryItem[maxSize];
    }

    public bool Add(InventoryItem item)
    {
        int slot = GetFreeSlot();
        if (slot >= 0)
        {
            items[slot] = item;
            return true;
        }
        return false;
    }

    public InventoryItem[] GetAll()
    {
        return items;
    }

    public void Remove(InventoryItem item)
    {
        Remove(item.itemId);
    }

    public void Remove(int id)
    {
        int slot = GetItemSlot(id);
        if (slot >= 0)
            items[slot] = null;
    }

    private int GetItemSlot(InventoryItem item)
    {
        return GetItemSlot(item.itemId);
    }

    private int GetItemSlot(int id)
    {
        for (int i = 0; i < maxSize; i++)
        {
            if (items[i] != null && items[i].itemId == id)
                return i;
        }
        return -1;
    }

    private int GetFreeSlot()
    {
        for (int i = 0; i < maxSize; i++)
        {
            if (items[i] == null)
                return i;
        }
        return -1;
    }
}
