using UnityEngine;

namespace SpaceEscape
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly Collider2D _unitCollider;
        private readonly IPlayerModel _unitData;
        private readonly CameraController _cameraController;
        private float _horizontal;
        private float _vertical;
        private Vector3 _move;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;

        public MoveController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical) input,
            Transform unit, IPlayerModel unitData, CameraController cameraController)
        {
            _unit = unit;
            _unitCollider = _unit.gameObject.GetComponent<Collider2D>();
            _unitData = unitData;
            _cameraController = cameraController;
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

            _move.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _unit.localPosition += _move;

            if(!_cameraController.CheckObjectInsideFrustum(_unitCollider))
            {
                _unit.localPosition -= 5 *_move;  // не нравится мне эта фигня....
            }
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
