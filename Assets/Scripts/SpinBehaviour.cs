using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpinBehaviour : MonoBehaviour
{
    [SerializeField] private Transform spinTransform;
    [SerializeField] private float spinDuration = 1f;
    [SerializeField] private float spinMultiplier = 1;

    public event Action SpinEnded;

    public void StartSpin(int rewardId, int totalReward)
    {
        float rotateCount = 360 * spinMultiplier;
        float rewardAngle = 360 / totalReward;
        float targetAngel = (rewardAngle * rewardId) + rotateCount;
        float spinAngle = spinTransform.eulerAngles.z;
        Vector3 targetRotation = new Vector3(0, 0, targetAngel);

        spinTransform.DORotate(targetRotation, spinDuration, RotateMode.FastBeyond360).onComplete = SpinEndHandler;
    }

    private void SpinEndHandler()
    {
        SpinEnded?.Invoke();
    }
}