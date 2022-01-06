using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SpaceEscape
{
    public sealed class GUIController : IInitialization, IExecute, ICleanup
    {
        private ScoreController _scoreController;
        private MainMenuData _mainMenuData;

        private Canvas _guiRootCanvas;
        private Image _mainMenuBackgroundImage;
        private GameObject _mainMenuRoot;
        private Button _newGameButton;
        private TextMeshProUGUI _newGameButtonText;
        private Button _continueButton;
        private TextMeshProUGUI _continueButtonText;
        private Button _exitButton;
        private TextMeshProUGUI _exitButtonText;

        private GameObject _osdRoot;
        private TextMeshProUGUI _scoreLabelText;
        private TextMeshProUGUI _scoreCounterText;
        private TextMeshProUGUI _playerHealthLabelText;
        private TextMeshProUGUI _playerHealthCounterText;

        private float _defaultTimeScale;

        public GUIController(MainMenuData mainMenuData, ScoreController scoreController)
        {
            _scoreController = scoreController;
            _mainMenuData = mainMenuData;
        }

        public void Initialization()
        {
            _scoreController.SetNewScore += OnScoreChanged;
            _guiRootCanvas = GameObject.Instantiate<Canvas>(_mainMenuData.GUIRootCanvas);
            _mainMenuRoot = GameObject.Instantiate(_mainMenuData.MainMenuRoot, _guiRootCanvas.transform);
            _mainMenuBackgroundImage = GameObject.Instantiate<Image>(_mainMenuData.MainMenuBackgroundImage, _mainMenuRoot.transform);
            _newGameButton = GameObject.Instantiate<Button>(_mainMenuData.NewGameButton, _mainMenuBackgroundImage.transform);
            _newGameButtonText = GameObject.Instantiate<TextMeshProUGUI>(_mainMenuData.NewGameButtonText, _newGameButton.transform);
            _continueButton = GameObject.Instantiate<Button>(_mainMenuData.ContinueButton, _mainMenuBackgroundImage.transform);
            _continueButtonText = GameObject.Instantiate<TextMeshProUGUI>(_mainMenuData.ContinueButtonText, _continueButton.transform);
            _exitButton = GameObject.Instantiate<Button>(_mainMenuData.ExitButton, _mainMenuBackgroundImage.transform);
            _exitButtonText = GameObject.Instantiate<TextMeshProUGUI>(_mainMenuData.ExitButtonText, _exitButton.transform);


            _osdRoot = GameObject.Instantiate(_mainMenuData.OSDRoot, _guiRootCanvas.transform);
            _scoreLabelText = GameObject.Instantiate<TextMeshProUGUI>(_mainMenuData.ScoreLabelText, _osdRoot.transform);
            _scoreCounterText = GameObject.Instantiate<TextMeshProUGUI>(_mainMenuData.ScoreCounterText, _osdRoot.transform);
            _playerHealthLabelText = GameObject.Instantiate<TextMeshProUGUI>(_mainMenuData.PlayerHealthLabelText, _osdRoot.transform);
            _playerHealthCounterText = GameObject.Instantiate<TextMeshProUGUI>(_mainMenuData.PlayerHealthCounterText, _osdRoot.transform);

            _mainMenuRoot.gameObject.SetActive(false);

            _defaultTimeScale = Time.timeScale;

            _continueButton.onClick.AddListener(OnMenuExit);
            _newGameButton.onClick.AddListener(OnNewGame);
            _exitButton.onClick.AddListener(OnGameExit);

        }

        public void Execute(float deltatime)
        {
            if (Input.GetKeyDown(KeyManager.MAIN_MENU))
            {
                Time.timeScale = 0;
                _mainMenuRoot.gameObject.SetActive(true);
            }
        }

        public void Cleanup()
        {
            _scoreController.SetNewScore -= OnScoreChanged;
            _continueButton.onClick.RemoveAllListeners();
            _newGameButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }

        private void OnScoreChanged(int newScore)
        {
            _scoreCounterText.text = newScore.ToString();
        }

        private void OnMenuExit()
        {
            _mainMenuRoot.gameObject.SetActive(false);
            Time.timeScale = _defaultTimeScale;
        }

        private void OnNewGame()
        {
            Time.timeScale = _defaultTimeScale;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnGameExit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }
    }
}