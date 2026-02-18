using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayable_GP2_Kevin
{
    internal class Health
    {
        public int _health { get; private set; }
        protected int _maxHealth;
        protected bool _isAlive = true;

        public Health(int HP)
        {
            _maxHealth = HP;
            _health = HP;
        }
        public void TakeDamage(int DMG)
        {
            _health -= DMG;
            if (_health <= 0)
            {
                _isAlive = false;
                _health = 0;
            }
        }
        public bool CheakIfAlive()
        {
            return _isAlive;
        }
        public void Heal(int Recover)
        {
            _health += Recover;
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
            }
        }
        public void FullHeal()
        {
            _health = _maxHealth;
        }
    }
}

