using UnityEngine;
using UnityEngine.XR;

public class VRPauseButton : MonoBehaviour
{
    public PauseMenu pauseMenu;

    InputDevice rightHand;
    bool lastState;

    void Start()
    {
        rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
    }

    void Update()
    {
        if (!rightHand.isValid)
            rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        bool pressed;
        if (rightHand.TryGetFeatureValue(CommonUsages.menuButton, out pressed))
        {
            if (pressed && !lastState)
            {
                TogglePause();
            }
            lastState = pressed;
        }
    }

    void TogglePause()
    {
        if (Time.timeScale == 0f)
            pauseMenu.Resume();
        else
            pauseMenu.Pause();
    }
}
