namespace SpaceEscape
{
    public struct InputData
    {
        public IUserInputProxy InputHorizontal;
        public IUserInputProxy InputVertical;
        public IUserKeyInputProxy InputFire;

        public InputData(IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserKeyInputProxy inputFire)
        {
            InputHorizontal = inputHorizontal;
            InputVertical = inputVertical;
            InputFire = inputFire;
        }
    }
}
