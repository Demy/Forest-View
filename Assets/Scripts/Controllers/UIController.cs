using UnityEngine;

public class UIController : MonoBehaviour
{
    public MainCharacter mainCharacter;

    public InventoryMenu inventory;

    private bool isOn = true;

    private void Start()
    {
        inventory.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isOn)
        {
            GameObject menu = GetMenuToToggle();
            if (menu != null)
                ToggleMenu(menu);
        }
    }

    private GameObject GetMenuToToggle()
    {
        if (Input.GetKeyDown(KeyCode.I))
            return inventory.gameObject;
        return null;
    }

    private void ToggleMenu(GameObject menu)
    {
        bool setOn = !menu.activeSelf;
        menu.SetActive(setOn);
        mainCharacter.Freeze(setOn);
        mainCharacter.movement.enabled = !setOn;
        Cursor.lockState = setOn ? CursorLockMode.Confined : CursorLockMode.Locked;

        if (setOn && menu == inventory.gameObject)
        {
            inventory.Show(mainCharacter);
        }
    }

    public void Enable(bool isOn)
    {
        this.isOn = isOn;
    }
}
