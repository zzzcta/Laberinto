public interface IEnemyState
{
    void Enter(EnemyContext context);  // L�gica al entrar al estado
    void Update(EnemyContext context); // L�gica para ejecutar cada frame
    void Exit(EnemyContext context);   // L�gica al salir del estado
}