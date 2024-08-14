using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DefenseServer
{
    public class Missile
    {
        public string Name { get; set; }
        public float Speed { get; set; }
        public float Mass { get; set; }
        public Origin Origin { get; set; }
        public Angle Angle { get; set; }
        public float DamageRadius { get; set; }
        public int Time { get; set; }

        public Missile(string name, float speed, float mass, Origin origin, Angle angle, float damageRadius, int time)
        {
            Name = name;
            Speed = speed;
            Mass = mass;
            Origin = origin;
            Angle = angle;
            DamageRadius = damageRadius;
            Time = time;
        }
        public override string ToString()
        {
            return $"Missile Name: {Name}, Speed: {Speed}, Mass: {Mass}, Origin x:{Origin.X}, Origin y:{Origin.Y}, Origin z:{Origin.Z}, Angle x: {Angle.X} , Angle y: {Angle.Y} Angle z: {Angle.Z} ,Damage Radius: {DamageRadius}, time is: {Time}";
        }
    }
}
