namespace MainGame.Enemy
{
    public interface IEnemy
    {
        void Attack();
        void Hurt(int dmg);
        void Move();
    }
}