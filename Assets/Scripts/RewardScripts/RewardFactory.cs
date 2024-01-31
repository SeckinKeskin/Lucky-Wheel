using UnityEngine;

public class RewardFactory : MonoBehaviour
{
    [SerializeField] private RewardManager rewardManager;

    public Reward GetReward(int id)
    {
        Reward reward = new Reward();
        reward.icon = rewardManager.GetIcon(id);
        reward.name = rewardManager.GetName(id);
        reward.value = rewardManager.GetValue(id);
        reward.id = id;

        return reward;
    }
}
