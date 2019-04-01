using System;
using System.Collections.Generic;
using System.Text;

namespace BigBlueBox_lib.Group
{
    public class Troop
    {
        public readonly List<Patrol> Patrols = new List<Patrol>();
    
        public String TroopName { get; }

        public Troop(String TroopName)
        {
            this.TroopName = TroopName;
        }
        public Troop(String TroopName, List<Patrol> Patrols)
        {
            this.TroopName = TroopName;
            this.Patrols = Patrols;
        }
    }
}
