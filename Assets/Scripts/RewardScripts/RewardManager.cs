using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private ScriptableRewardObject[] scriptableRewardObjectArray;
    [SerializeField] private ScriptableRewardObject dummyScriptableRewardObject;

    public Sprite GetIcon(int id)
    {
        return rewardObject(id).icon;
    }

    public string GetName(int id)
    {
        return rewardObject(id).rewardName;
    }

    public int GetValue(int id)
    {
        return rewardObject(id).value;
    }

    private ScriptableRewardObject rewardObject(int id)
    {
        foreach (ScriptableRewardObject reward in scriptableRewardObjectArray)
        {
            if (reward.id == id)
                return reward;
        }

        return dummyScriptableRewardObject;
    }
}
