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

    public event Action OnFresa—amComida; 
    public void Fresa—amComida()
    {
        OnFresa—amComida?.Invoke();
    }

    public event Action OnFresaSpinComida;
    public void FresaSpinComida()
    {
        OnFresaSpinComida?.Invoke();
    }
    public event Action OnDead;
    internal void Dead()
    {
        OnDead?.Invoke();
    }
}