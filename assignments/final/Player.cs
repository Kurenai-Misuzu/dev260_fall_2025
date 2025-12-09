using System;

namespace finalProject
{
    public class Player : IEquatable<Player>
    {
        private string shortName;
        private string longName;
        private int jerseyNumber;
        private int receives;
        private int pointsScored;
        private int blocks;

        // constrctor
        public Player()
        {
            shortName = "";
            longName = "";
            jerseyNumber = -1;
            receives = -1;
            pointsScored = -1;
            blocks = -1;
        }

        // getters
        public int getJerseyNumber
        {
            get
            {
                return jerseyNumber;
            }
        }

        public string getShortName
        {
            get
            {
                return shortName;
            }
        }

        public string getLongName
        {
            get
            {
                return longName;
            }
        }

        public int getReceives
        {
            get
            {
                return receives;
            }
        }

        public int getBlocks
        {
            get
            {
                return blocks;
            }
        }

        public int getPoints
        {
            get
            {
                return pointsScored;
            }
        }

        // methods
        public Player(string shortName, string longName, int jerseyNumber = 0, int receives = 0, int pointsScored = 0, int blocks = 0)
        {
            this.shortName = shortName;
            this.longName = longName;
            this.jerseyNumber = jerseyNumber;
            this.receives = receives;
            this.pointsScored = pointsScored;
            this.blocks = blocks;
        }

        public void printPlayer()
        {
            Console.WriteLine($"{jerseyNumber}: {shortName}");
            Console.WriteLine($"Full Name: {longName}");
            Console.WriteLine($"Receives: {receives}");
            Console.WriteLine($"Points Scored: {pointsScored}");
            Console.WriteLine($"Blocks: {blocks}");
        }

        // some bullshit
        // Implement IEquatable<Player>.Equals for type-safe comparison
        public bool Equals(Player? other)
        {
            if (other == null) return false;
            // Compare based on the longName property (case-insensitive is often useful)
            return string.Equals(this.longName, other.longName, StringComparison.OrdinalIgnoreCase);
        }

        // Override object.Equals to handle boxing/unboxing
        public override bool Equals(object? obj)
        {
            if (obj is Player otherPlayer)
            {
                return Equals(otherPlayer);
            }
            return false;
        }

        // Override GetHashCode so that equal objects return the same hash code
        public override int GetHashCode()
        {
            // Generate a hash code based ONLY on the longName property
            // Use a case-insensitive hash code to match the Equals method
            return longName == null ? 0 : longName.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }
    }


}