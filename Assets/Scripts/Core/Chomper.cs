using Abstractions;
using Commands;
using UnityEngine;

namespace Core
{
    public sealed class Chomper : MonoBehaviour, ISelectable, IAttackable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        public Transform PivotPoint => _pivotPoint;

        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Transform _pivotPoint;

        private float _health;
        private void Start()
        {
            _health = _maxHealth;
        }

    }
}