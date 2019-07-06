﻿using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Game/Inventory Item")]
public class InventoryItem : ScriptableObject
{
    [SerializeField]
    public int itemId;
    [SerializeField]
    public bool rightHand;
    [SerializeField]
    public bool leftHand;
    [SerializeField]
    public GameObject wearable;
}