using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tanks.Complete
{
    /// <summary>
    /// Handles the map selection screen where players choose which map to play on
    /// </summary>
    public class MapSelectionUI : MonoBehaviour
    {
        [Header("Map Configuration")]
        [Tooltip("Scene names of the available maps (must match scene names in Build Settings)")]
        public string[] m_MapSceneNames = new string[]
        {
            "SampleScene",
            "Demo_Game_Desert", 
            "Demo_Game_Jungle",
            "Demo_Game_Moon"
        };

        [Tooltip("Display names for the maps shown in UI")]
        public string[] m_MapDisplayNames = new string[]
        {
            "Classic Arena",
            "Desert Storm",
            "Jungle Warfare", 
            "Lunar Battle"
        };

        [Tooltip("Short descriptions for each map")]
        public string[] m_MapDescriptions = new string[]
        {
            "The original battlefield",
            "Fight in the scorching desert",
            "Battle through dense jungle",
            "Low gravity combat on the moon"
        };

        [Header("UI References")]
        public GameObject m_MapSelectionPanel;      // The panel containing map selection UI
        public GameObject m_StartMenuPanel;         // The tank selection menu panel
        public Button[] m_MapButtons;               // Buttons for each map (4 buttons)
        public TextMeshProUGUI m_TitleText;         // Title text "SELECT MAP"

        // Static variable to store selected map across scenes
        public static string SelectedMapScene { get; private set; } = "SampleScene";

        private void Start()
        {
            // Show map selection panel
            if (m_MapSelectionPanel != null)
                m_MapSelectionPanel.SetActive(true);

            // Hide start menu panel initially
            if (m_StartMenuPanel != null)
                m_StartMenuPanel.SetActive(false);

            // Set up map buttons
            SetupMapButtons();

            // Set title
            if (m_TitleText != null)
                m_TitleText.text = "SELECT MAP";
        }

        private void SetupMapButtons()
        {
            // Ensure we have the right number of buttons
            if (m_MapButtons == null || m_MapButtons.Length < m_MapSceneNames.Length)
            {
                Debug.LogError("Not enough map buttons assigned! Need " + m_MapSceneNames.Length + " buttons.");
                return;
            }

            // Setup each button
            for (int i = 0; i < m_MapSceneNames.Length; i++)
            {
                if (m_MapButtons[i] == null)
                    continue;

                // Get button text component
                TextMeshProUGUI buttonText = m_MapButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    // Set button text to map display name
                    buttonText.text = m_MapDisplayNames[i];
                }

                // Capture index for closure
                int mapIndex = i;

                // Add click listener
                m_MapButtons[i].onClick.AddListener(() => SelectMap(mapIndex));
            }
        }

        /// <summary>
        /// Called when a map button is clicked
        /// </summary>
        /// <param name="mapIndex">Index of the selected map</param>
        public void SelectMap(int mapIndex)
        {
            if (mapIndex < 0 || mapIndex >= m_MapSceneNames.Length)
            {
                Debug.LogError("Invalid map index: " + mapIndex);
                return;
            }

            // Store selected map
            SelectedMapScene = m_MapSceneNames[mapIndex];

            Debug.Log("Selected map: " + m_MapDisplayNames[mapIndex] + " (" + SelectedMapScene + ")");

            // Load the selected scene directly
            UnityEngine.SceneManagement.SceneManager.LoadScene(SelectedMapScene);
        }

        /// <summary>
        /// Go back to map selection (called when returning from tank selection)
        /// </summary>
        public void ShowMapSelection()
        {
            if (m_MapSelectionPanel != null)
                m_MapSelectionPanel.SetActive(true);

            if (m_StartMenuPanel != null)
                m_StartMenuPanel.SetActive(false);
        }
    }
}
