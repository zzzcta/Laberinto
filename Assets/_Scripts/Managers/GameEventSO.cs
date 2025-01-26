using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameEventSO", menuName = "Managers/GameEventSO")]
public class GameEventSO : ScriptableObject
{
    // Eventos
    public event Action<int> OnBaldosaPulsada;
    public event Action<int> OnPlayerDamaged;
    public event Action OnFresaComida;
    public event Action OnFresaSpinComida;
    public event Action OnEnemyDead;
    public event Action OnMerengueMovedizo;
    public event Action OnPlayerDead;

    // Métodos para invocar eventos
    public void TriggerBaldosaPulsada(int idBaldosa)
    {
        OnBaldosaPulsada?.Invoke(idBaldosa);
    }
    public void TriggerPlayerDamaged(int daño)
    {
        OnPlayerDamaged?.Invoke(daño);
    }

    public void TriggerFresaComida()
    {
        OnFresaComida?.Invoke();
    }

    public void TriggerFresaSpinComida()
    {
        OnFresaSpinComida?.Invoke();
    }

    public void TriggerEnemyDead()
    {
        OnEnemyDead?.Invoke();
    }

    public void TriggerMerengueMovedizo()
    {
        OnMerengueMovedizo?.Invoke();
    }

    public void PlayerDead()
    {
        OnPlayerDead?.Invoke();
    }
}
