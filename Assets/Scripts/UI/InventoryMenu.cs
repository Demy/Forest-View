using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    public Transform grid;
    public ObjectPool slotPool;

    public Transform itemPreview;
    public Text itemDescription;

    private List<InventoryMenuSlot> slots = new List<InventoryMenuSlot>();

    private void Start()
    {
        itemDescription.text = "";
    }

    public void Show(Character character)
    {
        int slotsCount = slots.Count;
        InventoryItem[] items = character.GetInventory().GetAll();
        for (int i = 0; i < items.Length; i++)
        {
            InventoryMenuSlot slot;
            if (slotsCount > i)
            {
                slot = slots[i];
            }
            else
            {
                slot = slotPool.GetFromPool().GetComponent<InventoryMenuSlot>();
                slots.Add(slot);
            }
            slot.transform.SetParent(grid, false);
            slot.Init(items[i]);
            slot.OnSelect += Slot_OnSelect;
        }
        for (int i = 0; i < slotsCount - items.Length; i++)
        {
            slots[i].OnSelect -= Slot_OnSelect;
            slotPool.ReturnToPool(slots[i].gameObject);
        }
    }

    private void Slot_OnSelect(InventoryMenuSlot slot)
    {
        itemDescription.text = slot.GetItem() == null ? "" : slot.GetItem().name;
    }
}
