using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trainer", menuName = "Trainer")]
public class Trainer : ScriptableObject
{
    public string title;
    public int[] location;
    public string intro;
    public string outro;

    public Sprite sprite;

    public Types type;
    public Monster[] monster;

    public int level;
    public bool reward;
    public Rewards rewardType;
    public string[] dialog;
}
