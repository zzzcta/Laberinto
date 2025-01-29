using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar; // Referencia a la barra de vida
    private EnemyHealth enemyHealth;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();

        // Asegurar que la barra de vida inicie con el valor correcto
        if (healthBar != null)
        {
            healthBar.value = 1f; // 100% de vida
        }
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth; // Normalizar el valor entre 0 y 1
        }
    }
}
