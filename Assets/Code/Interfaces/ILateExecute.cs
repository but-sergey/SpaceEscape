namespace RollABall
{
    internal interface ILateExecute : IController
    {
        public void LateExecute(float deltaTime);
    }
}
