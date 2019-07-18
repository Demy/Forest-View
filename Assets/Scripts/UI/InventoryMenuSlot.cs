using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuSlot : MonoBehaviour
{
    public delegate void Select(InventoryMenuSlot slot);
    public Select OnSelect = (i) => { };

    public Image icon;

    private InventoryItem item;

    public void Init(InventoryItem item)
    {
        this.item = item;
        if (item != null)
        {
            icon.sprite = Sprite.Create(item.icon, new Rect(0, 0, item.icon.width, item.icon.height), new Vector2());
        }
    }

    public void OnClick()
    {
        OnSelect(this);
    }

    public InventoryItem GetItem()
    {
        return item;
    }
}
