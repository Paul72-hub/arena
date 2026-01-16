using UnityEngine;

public class UIRayToggle : MonoBehaviour
{
    public GameObject[] uiRayObjects; // ex: Left Ray Interactor, Right Ray Interactor

    public void SetUIRays(bool enabled)
    {
        if (uiRayObjects == null) return;

        foreach (var go in uiRayObjects)
            if (go) go.SetActive(enabled);
    }
}
