using UnityEngine;

public interface IReward
{
    Sprite icon{ get; set; }
    string name{ get; set; }
    int value{ get; set; }
    int id { get; set; }
}
