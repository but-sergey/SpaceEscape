using System;
using UnityEngine;

namespace SpaceEscape
{
    public sealed class PCInputFire : IUserKeyInputProxy
    {
        public event Action<bool> KeyOnChange = delegate (bool b) { };

        public void GetKey()
        {
            KeyOnChange.Invoke(Input.GetKeyDown(KeyManager.FIRE));
        }
    }
}
