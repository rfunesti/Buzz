using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput I;   // quick singleton access (optional)
    void Awake() => I = this;

    // “Tap” actions (set true briefly)
    public bool jumpPressed;
    public bool firePressed;

    public void JumpTap() => jumpPressed = true;
    public void FireTap() => firePressed = true;

    void LateUpdate()
    {
        // reset tap actions each frame
        jumpPressed = false;
        firePressed = false;
    }
}
