using NUnit;
using System;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static Unity.Burst.Intrinsics.X86;

public class MobileInput : MonoBehaviour
{
    public static MobileInput I; // This makes one shared version (static) of this script that other scripts can access easily. 
    void Awake() => I = this;

    // “Tap” action (set true briefly)
    public bool jumpPressed;

    // This function is called when the player taps a UI button.
    public void JumpTap() => jumpPressed = true;

    // Both Update() and LateUpdate() run every frame, but they run at different times during that frame.
    // Think of a frame like a class period - Update(): Students do their work; LateUpdate(): Teacher checks everything after
    void LateUpdate()
    {             
        jumpPressed = false;
        // All scripts get a chance to see the input first
        // Then it resets safely at the end of the frame
    }
}
