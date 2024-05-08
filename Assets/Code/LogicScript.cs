using System.Collections;
using UnityEngine;

namespace Assets.Code
{
    public class LogicScript : MonoBehaviour
    {
        public PlayerScript player;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        }

        public void KillPlayer()
        {
            player.isAlive = false;
        }
    }
}