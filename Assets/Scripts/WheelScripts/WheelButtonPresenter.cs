using UnityEngine;
using UnityEngine.UI;

public class WheelButtonPresenter : MonoBehaviour
{
    [SerializeField] private WheelButton wheelButton;
    [SerializeField] private Text buttonText;
    [SerializeField] private WheelManager wheelManager;
    [SerializeField] private SpinBehaviour spinBehaviour;
    [SerializeField] private Button button;

    private void OnEnable()
    {
        button.onClick.AddListener(SpinEventListener);

        wheelButton.ButtonNameChanged += ButtonNameChangeEvent;
        spinBehaviour.SpinEnded += SpinEndedHandler;
        wheelManager.CollectEnded += ClaimEndedHandler;
    }

    private void SpinEventListener()
    {
        button.interactable = false;

        wheelButton.SpinAvailable();
        wheelManager.SetReward();
    }
    private void ClaimEventListener()
    {
        button.interactable = false;
        
        wheelManager.CollectReward();
        wheelButton.SpinAvailable();
    }

    private void SpinEndedHandler()
    {
        button.interactable = true;

        wheelButton.ClaimAvailable();
        button.onClick.AddListener(ClaimEventListener);
    }

    private void ClaimEndedHandler()
    {
        button.interactable = true;

        wheelButton.SpinAvailable();
        button.onClick.AddListener(SpinEventListener);
    }

    private void UpdateButton()
    {
        buttonText.text = wheelButton.buttonText;
        button.onClick.RemoveAllListeners();
    }

    private void ButtonNameChangeEvent()
    {
        UpdateButton();
    }
}