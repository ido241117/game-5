using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks.Complete
{
    /// <summary>
    /// Simple script to load scenes - easy to use with UI buttons
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        /// <summary>
        /// Load the map selection scene (SampleScene)
        /// </summary>
        public void LoadMapSelection()
        {
            SceneManager.LoadScene("SampleScene");
        }

        /// <summary>
        /// Load the next level in the sequence (Desert → Jungle → Moon)
        /// </summary>
        public void LoadNextLevel()
        {
            LevelManager.LoadNextLevel();
        }

        /// <summary>
        /// Load the first level (Desert)
        /// </summary>
        public void LoadFirstLevel()
        {
            LevelManager.LoadFirstLevel();
        }

        /// <summary>
        /// Load a scene by name
        /// </summary>
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        /// <summary>
        /// Quit the application
        /// </summary>
        public void QuitGame()
        {
            Debug.Log("Quitting game...");
            Application.Quit();
        }
    }
}
