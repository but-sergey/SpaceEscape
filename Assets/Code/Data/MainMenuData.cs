using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "MainMenuData", menuName = "Data/Main menu data")]
    public sealed class MainMenuData : ScriptableObject
    {
        [Header("GUI root")]
        [SerializeField] private Canvas _guiRootCanvas;
        [SerializeField] private Image _mainMenuBackgroundImage;
        [Header("Buttons")]
        [SerializeField] private GameObject _mainMenuRoot;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private TextMeshProUGUI _newGameButtonText;
        [SerializeField] private Button _continueButton;
        [SerializeField] private TextMeshProUGUI _continueButtonText;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TextMeshProUGUI _exitButtonText;
        [Header("OSD")]
        [SerializeField] private GameObject _osdRoot;
        [SerializeField] private TextMeshProUGUI _scoreLabelText;
        [SerializeField] private TextMeshProUGUI _scoreCounterText;
        [SerializeField] private TextMeshProUGUI _playerHealthLabelText;
        [SerializeField] private TextMeshProUGUI _playerHealthCounterText;

        public Canvas GUIRootCanvas => _guiRootCanvas;
        public Image MainMenuBackgroundImage => _mainMenuBackgroundImage;
        public GameObject MainMenuRoot => _mainMenuRoot;
        public Button NewGameButton => _newGameButton;
        public TextMeshProUGUI NewGameButtonText
        {
            get
            {
                return _newGameButtonText;
            }
            set
            {
                _newGameButtonText = value;
            }
        }
        public Button ContinueButton => _continueButton;
        public TextMeshProUGUI ContinueButtonText
        {
            get
            {
                return _continueButtonText;
            }
            set
            {
                _continueButtonText = value;
            }
        }
        public Button ExitButton => _exitButton;
        public TextMeshProUGUI ExitButtonText
        {
            get
            {
                return _exitButtonText;
            }
            set
            {
                _exitButtonText = value;
            }
        }

        public GameObject OSDRoot => _osdRoot;
        public TextMeshProUGUI ScoreLabelText => _scoreLabelText;
        public TextMeshProUGUI ScoreCounterText => _scoreCounterText;

        public TextMeshProUGUI PlayerHealthLabelText
        {
            get
            {
                return _playerHealthLabelText;
            }
            set
            {
                _playerHealthLabelText = value;
            }
        }            
        public TextMeshProUGUI PlayerHealthCounterText
        {
            get
            {
                return _playerHealthCounterText;
            }
            set
            {
                _playerHealthCounterText = value;
            }
        }

    }
}