using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp6
{
    public interface Attacker
    {
        void Attack(Unit unit);
    }
    public interface Moveable { };

    public class GameObject
    {
        private int _id;
        private string _name;
        private int _x;
        private int _y;

        //public int Id => _id;
        //public string Name => _name;
        //public int X => _x;
        //public int Y => _y;

        public GameObject(int id, string name, int x, int y)
        {
            _id = id;
            _name = name;
            _x = x;
            _y = y;
        }

        public int getId()
        {
            return _id;
        }
        public string getName()
        {
            return _name;
        }
        public int getX()
        {
            return _x;
        }
        public int getY()
        {
            return _y;
        }
    }

    public class Unit : GameObject
    {
        private float _hp;

        //public float Hp => _hp;

        public Unit(int id, string name, int x, int y, float hp) : base(id, name, x, y)
        {
            _hp = hp;
        }

        public bool isAlive()
        {
            if (_hp <= 0) return false;
            return true;
        }
        public float getHP()
        {
            return _hp;
        }
        public void receiveDamage(float damage)
        {
            if (damage < 0) return;
            if (isAlive()) _hp = Math.Max(0, _hp - damage);
            else return;
        }
    }

    public class Archer : Unit, Attacker, Moveable
    {
        private int _damage;
        public int Damage => _damage;

        public Archer(int id, string name, int x, int y, float hp, int damage) : base(id, name, x, y, hp)
        {
            _damage = damage;
        }

        public void Attack(Unit unit)
        {
            if (unit == null) return;
            if (!isAlive()) return;
            unit.receiveDamage(_damage);
        }
    }

    public class Building : GameObject
    {
        private bool _isBuilt;
        //public bool IsBuilt => _isBuilt;

        public bool IsBuilt()
        {
            return _isBuilt;
        }

        public Building(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y)
        {
            _isBuilt = isBuilt;
        }
    }

    public class Fort : Building, Attacker
    {
        private int _damage;
        public int Damage => _damage;
        public Fort(int id, string name, int x, int y, bool isBuilt, int damage) : base(id, name, x, y, isBuilt)
        {
            _damage = damage;
        }

        public void Attack(Unit unit)
        {
            if (unit == null) return;
            if (IsBuilt()) unit.receiveDamage(_damage);
        }
    }

    public class MobileHouse : Building, Moveable
    {
        public MobileHouse(int id, string name, int x, int y, bool isBuilt) : base(id, name, x, y, isBuilt)
        {
        }
    }
}
