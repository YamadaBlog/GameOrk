using System.Numerics;

namespace CoursTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player Player = new Player("Herck the Goblin Slayer", 100, 10, 25);
            List<Character> Monster = new List<Character>();
            Monster.Add(new Goblin("Goblin", 50, 5, 15));
            Monster.Add(new Ork("Ork", 50, 5, 15));

            int Length = Monster.Count;
            int compteur = 0;
            while (Length >= 0 || Player.life < 0)
            {
                foreach (Character m in Monster)
                {
                    if (Player.life > 0 && m.life > 0)
                    {
                        compteur++;
                        Console.WriteLine("Tour n°" + compteur);
                        Player.Attack(m);
                        if (m.life > 0)
                        {
                            m.Attack(Player);
                        }
                    }
                    else if(m.life <= 0) { Length -= 1; }
                }
            }
            Console.WriteLine("\nPlayer.life of " + Player.type + " : " + Player.life) ;
        }


        abstract class Character
        {
            public string type;
            public int life;
            public int defense;
            public int attack;

            protected Character(string type, int life, int defense, int attack) {
                this.life = life;
                this.defense = defense;
                this.attack = attack;
                this.type = type;
            }
            
            public void Attack(Character m) {
                m.life = m.life - this.attack + m.defense;
                Console.WriteLine(this.type +" : "+this.life+" and attack the "+m.type+( m.life <= 0 ?" who has been killed": " : "+m.life));
            }

        }



        class Player : Character {
            public Player(string type, int life, int def, int atk) : base(type, life, def, atk) { }
        }
        class Monster : Character {
            public Monster(string type, int life, int def, int atk) : base(type, life, def, atk) { }

        }
        class Goblin : Monster{
            public Goblin(string type, int life, int def, int atk) : base(type, life, def, atk) { }

        }

        class Ork : Monster {
        public Ork(string type, int life, int def, int atk) : base(type, life, def, atk) { }

        }
    }
}