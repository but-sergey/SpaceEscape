using System;

namespace SpaceEscape
{
    public interface IUserKeyInputProxy
    {
        event Action<bool> KeyOnChange;
        void GetKey();
    }
}
