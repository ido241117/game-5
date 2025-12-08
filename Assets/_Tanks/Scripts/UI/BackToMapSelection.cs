using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks.Complete
{
    /// <summary>
    /// Handles ESC key press to return to map selection screen
    /// Add this script to any GameObject in the game scenes
    /// </summary>
    public class BackToMapSelection : MonoBehaviour
    {
        [Tooltip("Name of the scene that contains the map selection menu")]
        public string m_MapSelectionSceneName = "SampleScene";

        [Tooltip("Key to press to return to map selection")]
        public KeyCode m_BackKey = KeyCode.Escape;

        private void Update()
        {
            // Check if ESC key is pressed
            if (Input.GetKeyDown(m_BackKey))
            {
                ReturnToMapSelection();
            }
        }

        /// <summary>
        /// Load the map selection scene
        /// </summary>
        public void ReturnToMapSelection()
        {
            Debug.Log("Returning to map selection...");
            SceneManager.LoadScene(m_MapSelectionSceneName);
        }

        /// <summary>
        /// Load Desert scene
        /// </summary>
        public void LoadDesertScene()
        {
            Debug.Log("Loading Desert scene...");
            SceneManager.LoadScene("Demo_Game_Desert");
        }

        /// <summary>
        /// Load Jungle scene
        /// </summary>
        public void LoadJungleScene()
        {
            Debug.Log("Loading Jungle scene...");
            SceneManager.LoadScene("Demo_Game_Jungle");
        }

        /// <summary>
        /// Load Moon scene
        /// </summary>
        public void LoadMoonScene()
        {
            Debug.Log("Loading Moon scene...");
            SceneManager.LoadScene("Demo_Game_Moon");
        }
    }
}
