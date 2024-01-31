using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Reward_Data", menuName = "Create Reward/New Reward", order = 1)]
public class ScriptableRewardObject : ScriptableObject
{
    [SerializeField] public int id = 0;
    [SerializeField] public string rewardName = "Reward";
    [SerializeField] public Sprite icon;
    [SerializeField] public int value = 0;
}
