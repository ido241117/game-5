using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tanks.Complete
{
    /// <summary>
    /// Cheat system for player-controlled tanks only
    /// Auto-enabled in Infinity scene for player tanks
    /// </summary>
    public class TankCheat : MonoBehaviour
    {
        [Header("Cheat Settings")]
        [Tooltip("Auto-enable cheats in Infinity scene for player")]
        public bool m_AutoEnableInInfinity = true;

        [Header("Cheat Status")]
        public bool m_IsGodMode = false;        // God Mode: Infinite health, no damage taken
        public bool m_IsOneHitKill = false;     // One Hit Kill: All shots kill instantly

        private TankMovement m_TankMovement;
        private TankHealth m_TankHealth;
        private TankShooting m_TankShooting;

        private void Awake()
        {
            // Get references to tank components
            m_TankMovement = GetComponent<TankMovement>();
            m_TankHealth = GetComponent<TankHealth>();
            m_TankShooting = GetComponent<TankShooting>();
        }
        
        private void Start()
        {
            // Auto-enable cheats in Infinity scene for player-controlled tanks
            if (m_AutoEnableInInfinity && m_TankMovement != null && !m_TankMovement.m_IsComputerControlled)
            {
                string currentScene = SceneManager.GetActiveScene().name;
                if (currentScene.Equals("Infinity", System.StringComparison.OrdinalIgnoreCase))
                {
                    m_IsGodMode = true;
                    m_IsOneHitKill = true;
                    Debug.Log($"<color=cyan>[AUTO-CHEAT] Player {m_TankMovement.m_PlayerNumber} - GOD MODE + ONE HIT KILL enabled in Infinity scene!</color>");
                }
            }
        }

        /// <summary>
        /// Check if this tank should take damage (God Mode check)
        /// </summary>
        public bool ShouldTakeDamage()
        {
            if (m_IsGodMode)
            {
                Debug.Log("<color=yellow>[CHEAT] God Mode - No damage taken!</color>");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get damage multiplier for shots (One Hit Kill check)
        /// </summary>
        public float GetDamageMultiplier()
        {
            if (m_IsOneHitKill)
            {
                // Return a very high multiplier to ensure one-hit kill
                return 100f;
            }
            return 1f;
        }
    }
}
