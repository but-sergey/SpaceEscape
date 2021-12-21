using UnityEngine;
using UnityEngine.UI;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "MainMenuData", menuName = "Data/Main menu data")]
    public sealed class MainMenuData : ScriptableObject
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private GameObject _mainMenu;


        public Button ContinueButton
        {
            get
            {
                return _continueButton;
            }
            set
            {
                _continueButton = value;
            }
        }
    }
}