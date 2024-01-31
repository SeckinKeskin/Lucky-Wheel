using System;
using UnityEngine;

public class WheelButton : MonoBehaviour
{
    public event Action ButtonNameChanged;

    private string _buttonText = "Spin";
    public string buttonText{ get => _buttonText;}

    public void SpinAvailable()
    {
        _buttonText = "Spin";

        ButtonNameHandler();
    }

    public void ClaimAvailable()
    {
        _buttonText = "Claim";

        ButtonNameHandler();
    }

    private void ButtonNameHandler()
    {
        ButtonNameChanged?.Invoke();
    }
}
