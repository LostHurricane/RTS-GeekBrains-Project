using Abstractions;
using Commands;
using UnityEngine;

namespace Core
{
    public sealed class Chomper : MonoBehaviour, ISelectable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;


        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;

        private float _health;
        private void Start()
        {
            _health = _maxHealth;
        }

    }
}