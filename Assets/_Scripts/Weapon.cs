using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private int damage = 2; // Da�o que hace el arma
    [SerializeField] private Animator weaponAnimator; // Controlador de animaciones
    [SerializeField] private string attackAnimationTrigger = "Attack"; // Trigger para la animaci�n de ataque
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
        if (isAttacking) return; // Prevenir m�ltiples ataques simult�neos

        isAttacking = true;

        // Iniciar animaci�n
        if (weaponAnimator != null)
        {
            weaponAnimator.SetTrigger(attackAnimationTrigger);
            FindAnyObjectByType<AudioManager>().Play("WeaponAttack");
        }

        // Ejecutar l�gica de da�o despu�s de la animaci�n
        Invoke(nameof(DealDamage), 0.78f); // Ajusta el tiempo seg�n la duraci�n de la animaci�n
        
    }

    private void DealDamage()
    {
        // Detectar enemigos dentro del rango de ataque
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            // Aplicar da�o al enemigo
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

