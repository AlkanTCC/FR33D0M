using UnityEngine;

[CreateAssetMenu(fileName = "NPCObject", menuName = "Scriptable Objects/NPCObject")]
public class NPCObject : ScriptableObject
{
    [Header("Type")]
    public bool enemy;
    public bool civilian;

    [Header("Character")]
    public bool scared;
    public bool neutral;
    public bool brave;

    [Header("Stats")]
    public float health;
    public float speed;
}