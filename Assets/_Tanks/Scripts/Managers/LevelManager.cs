using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks.Complete
{
    /// <summary>
    /// Manages linear level progression through the game
    /// Handles loading levels in order: Desert → Jungle → Moon
    /// </summary>
    public class LevelManager : MonoBehaviour
    {
        // Define the order of levels
        private static readonly string[] LevelOrder = new string[]
        {
            "Demo_Game_Desert",   // Level 1
            "Demo_Game_Jungle",   // Level 2
            "Demo_Game_Moon"      // Level 3
        };

        /// <summary>
        /// Get the next level name based on current scene
        /// </summary>
        public static string GetNextLevel()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            
            // Find current level index
            for (int i = 0; i < LevelOrder.Length; i++)
            {
                if (LevelOrder[i] == currentScene)
                {
                    // If not the last level, return next level
                    if (i < LevelOrder.Length - 1)
                    {
                        return LevelOrder[i + 1];
                    }
                    else
                    {
                        // Last level - loop back to first level
                        return LevelOrder[0];
                    }
                }
            }
            
            // If current scene not found in order, default to first level
            Debug.LogWarning("Current scene not in level order, loading first level");
            return LevelOrder[0];
        }

        /// <summary>
        /// Load the next level in sequence
        /// </summary>
        public static void LoadNextLevel()
        {
            string nextLevel = GetNextLevel();
            Debug.Log("Loading next level: " + nextLevel);
            SceneManager.LoadScene(nextLevel);
        }

        /// <summary>
        /// Load the first level (Desert)
        /// </summary>
        public static void LoadFirstLevel()
        {
            Debug.Log("Loading first level: " + LevelOrder[0]);
            SceneManager.LoadScene(LevelOrder[0]);
        }

        /// <summary>
        /// Check if current level is the last level
        /// </summary>
        public static bool IsLastLevel()
        {
            string currentScene = SceneManager.GetActiveScene().name;
            return currentScene == LevelOrder[LevelOrder.Length - 1];
        }
    }
}
