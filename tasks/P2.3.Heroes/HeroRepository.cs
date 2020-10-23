using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        public HeroRepository()
        {
            this.data = new List<Hero>();
        }
        private List<Hero> data;
        public int Count
        {
            get
            {
                return this.data.Count;
            }
        }
        public void Add(Hero hero)
        {           
            {
                this.data.Add(hero);
            }
        }
        public bool Remove(string name)
        {
            
            foreach (var hero in this.data)
            {
                if (hero.Name == name)
                {
                    this.data.Remove(hero);
                    return true;
                }             
            }
            return false;
        }
        public Hero GetHeroWithHighestStrength()
        {
            var hero = this.data.OrderByDescending(h => h.Item.Strength).First();
            return hero;
        }
        public Hero GetHeroWithHighestAbility()
        {
            var hero = this.data.OrderByDescending(h => h.Item.Ability).First();
            return hero;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            var hero = this.data.OrderByDescending(h => h.Item.Intelligence).First();
            return hero;
        }
        public override string ToString()
        {
            return String.Join(Environment.NewLine, this.data);
        }
    }
}
