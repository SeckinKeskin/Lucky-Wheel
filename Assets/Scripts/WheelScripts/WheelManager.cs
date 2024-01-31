using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    [SerializeField] private List<RewardBehaviour> rewardBehaviourList;
    [SerializeField] private RewardFactory rewardFactory;
    [SerializeField] private SpinBehaviour spinBehaviour;
    [SerializeField] private Transform collectDestination;
    [SerializeField] private float collectDuration = 2.0f;
    private List<IReward> rewardList;
    private IReward collectableReward;

    public event Action CollectEnded;

    private void Awake()
    {
        SetRewardList();
    }

    private void SetRewardList()
    {
        IReward reward;
        int rewardId = 0;
        rewardList = new List<IReward>();

        foreach (RewardBehaviour rewardBehaviour in rewardBehaviourList)
        {
            reward = rewardFactory.GetReward(rewardId);
            rewardBehaviour.Initialize(reward);
            rewardList.Add(reward);

            rewardId++;
        }
    }

    public void SetReward()
    {
        int rndmRange = UnityEngine.Random.Range(0, rewardList.Count);
        collectableReward = rewardList[rndmRange];
        
        spinBehaviour.StartSpin(collectableReward.id, rewardList.Count);
    }
    public void CollectReward()
    {
        Image rewardImage = GetRewardBehaviour().iconRenderer;
        Vector2 maxScale = new Vector2(2.5f, 2.5f);
        rewardImage.transform.DOScale(maxScale, collectDuration / 2);
        rewardImage.transform.DOMove(collectDestination.position, collectDuration).onComplete = CollecEndHandler;
    }

    public void CollecEndHandler()
    {
        Debug.Log("Reward is " + collectableReward.name + 
                    " | Value: " + collectableReward.value +
                        " | ID: " + collectableReward.id);

        GetRewardBehaviour().ResetTransform();

        CollectEnded?.Invoke();
    }

    public RewardBehaviour GetRewardBehaviour()
    {
        foreach (RewardBehaviour reward in rewardBehaviourList)
        {
            if(reward.data.id == collectableReward.id)
                return reward;
        }

        return null;
    }
}
