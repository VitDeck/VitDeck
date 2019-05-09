using UnityEngine;

[ExecuteInEditMode]
public class NotEditableComponent: MonoBehaviour
{
  
    void OnEnable()
    {
        this.gameObject.hideFlags =  UnityEngine.HideFlags.NotEditable;
    }

    void OnDisable()
    {

    }
}