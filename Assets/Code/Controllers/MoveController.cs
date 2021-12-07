using UnityEngine;

namespace RollABall
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly IPlayerModel _unitData;
        private float _horizontal;
        private float _vertical;
        private Vector3 _move;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            Transform unit, IPlayerModel unitData)
        {
            _unit = unit;
            _unitData = unitData;
            _horizontalInputProxy = input.inputHorizontal;
            _verticalInputProxy = input.inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        public void Execute(float deltaTime)
        {
            var speed = deltaTime * _unitData.Speed;
            _move.Set(_horizontal * speed, 0.0f, _vertical * speed);
            _unit.localPosition += _move;
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
