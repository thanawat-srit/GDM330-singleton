using System;
using PhEngine.Core;
using UnityEngine;

namespace SuperGame
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public Action<float> OnPlayerTakeDamage;
        protected override void InitAfterAwake()
        {
            
        }

        public GameObject GetPlayer()
        {
            return GameObject.FindGameObjectWithTag("Player");
        }
    }
}