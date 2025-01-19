using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CanvasManagerSO", menuName = "Managers/CanvasManagerSO")]
public class CanvasManagerSO : ScriptableObject
{
    public event Action FresaComida;
    public void FresaUI()
    {
        FresaComida?.Invoke();
    }
}
