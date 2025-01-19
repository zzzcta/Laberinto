using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventSO", menuName = "Managers/GameEventSO")]
public class GameEventSO : ScriptableObject
{
    public event Action <int> OnBaldosaPulsada;
    public void BaldosaPulsada(int idBaldosa)
    {
        OnBaldosaPulsada?.Invoke(idBaldosa);
    }

    public event Action OnFresaComida; 
    public void FresaComida()
    {
        OnFresaComida?.Invoke();
    }
}
