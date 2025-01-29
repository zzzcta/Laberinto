using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private int damage = 2; // Daño que hace el arma
    [SerializeField] private Animator weaponAnimator; // Controlador de animaciones
    [SerializeField] private string attackAnimationTrigger = "Attack"; // Trigger para la animación de ataque
    [SerializeField] private LayerMask enemyLayer; // Capa de los enemigos
    [SerializeField] private Transform attackPoint; // Punto desde donde se lanza el ataque
    [SerializeField] private float attackRange = 1.5f; // Alcance del ataque

    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            PerformAttack();
        }
    }

    private void PerformAttack()
    {
        if (isAttacking) return; // Prevenir múltiples ataques simultáneos

        isAttacking = true;

        // Iniciar animación
        if (weaponAnimator != null)
        {
            weaponAnimator.SetTrigger(attackAnimationTrigger);
            FindAnyObjectByType<AudioManager>().Play("WeaponAttack");
        }

        // Ejecutar lógica de daño después de la animación
        Invoke(nameof(DealDamage), 0.78f); // Ajusta el tiempo según la duración de la animación
        
    }

    private void DealDamage()
    {
        // Detectar enemigos dentro del rango de ataque
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            // Aplicar daño al enemigo
            if (enemy.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(damage);
            }
        }

        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        // Dibujar el rango de ataque en la vista del editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

