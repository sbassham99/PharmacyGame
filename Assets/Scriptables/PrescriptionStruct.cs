using UnityEngine;

[System.Serializable]
public struct PrescriptionStruct
{
    // 0 = green, 1 = blue
    public int alienTypeThatTakesMed;
    public int pillQtyToCount;
    public Sprite prescription;
}