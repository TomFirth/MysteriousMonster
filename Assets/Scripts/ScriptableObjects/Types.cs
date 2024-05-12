using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Type", menuName = "Type")]
public class Types : ScriptableObject
{
    public string title;
    public string description;
    public Sprite logo;
}
