using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Reward", menuName = "Reward")]
public class Rewards : ScriptableObject
{
    public string title;
    public string description;
    public Sprite logo;
    public string value;
}
