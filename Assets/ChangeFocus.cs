using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangeFocus : MonoBehaviour
{
    [SerializeField] PostProcessVolume volume;
    DepthOfField dofSetting;
    public Vector2 focusRanges;
    private void Awake()
    {
        dofSetting = volume.profile.GetSetting<DepthOfField>();
        SetFocus(0);                            
    }
    public void SetFocus(float f)
    {
        dofSetting.focalLength.value= Mathf.Lerp(focusRanges.x, focusRanges.y, f);
    }
}
