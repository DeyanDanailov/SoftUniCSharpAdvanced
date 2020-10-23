using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }
        private List<Player> roster;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return this.roster.Count;
            }
        }
        public void AddPlayer(Player player)
        {
            if (this.roster.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            foreach (var player in this.roster)
            {
                if (player.Name == name)
                {
                    this.roster.Remove(player);
                    return true;
                }
            }
            return false;
        }
       
        public void PromotePlayer(string name)
        {
           
            foreach (var player in this.roster)
            {
                if (player.Name == name && player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
            
        }
        public void DemotePlayer(string name)
        {

            foreach (var player in this.roster)
            {
                if (player.Name == name && player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
            }

        }
        public Player[] KickPlayersByClass(string classs)
        {
            var playerList = this.roster.Where(p => p.Class == classs).ToList();
            this.roster = this.roster.Where(p => p.Class != classs).ToList();
            return playerList.ToArray();
        }
        public string Report()
        {           
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            sb.AppendLine(String.Join(Environment.NewLine, this.roster));

            return sb.ToString().TrimEnd();
        }


    }
}
