public interface IEnemyState
{
    void Enter(EnemyContext context);  // Lógica al entrar al estado
    void Update(EnemyContext context); // Lógica para ejecutar cada frame
    void Exit(EnemyContext context);   // Lógica al salir del estado
}