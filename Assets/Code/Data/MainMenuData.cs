using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "MainMenuData", menuName = "Data/Main menu data")]
    public sealed class MainMenuData : ScriptableObject
    {
        public Canvas MainMenuCanvas;
        public Image MainMenuBackgroundImage;
        public Button NewGameButton;
        public TextMeshProUGUI NewGameButtonText;
        public Button ContinueButton;
        public TextMeshProUGUI ContinueButtonText;

        public GameObject OSDRoot;
        public TextMeshProUGUI ScoreLabel;
        public TextMeshProUGUI ScoreCounter;

        public TextMeshProUGUI PlayerHealthLabel;
        public TextMeshProUGUI PlayerHealthCounter;

    }
}