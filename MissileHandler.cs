using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text.Json;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace DefenseServer
{
    public class MissileHandler : WebSocketBehavior
    {
        private readonly WebSocketServer _wss;
        private readonly ConcurrentQueue<Missile> _missileQueue;
        Dictionary<string, float> dict = GetDictionary();

        public MissileHandler(WebSocketServer wss, ConcurrentQueue<Missile> missileQueue)
        {
            this._wss = wss;
            this._missileQueue = missileQueue;
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine(e.Data);
            Missile missile = JsonSerializer.Deserialize<Missile>(e.Data);
            if (missile != null)
            {
                if (dict.TryGetValue(missile.Name, out float damageRadius))
                {
                    missile.DamageRadius = damageRadius;
                }
            }
            this._missileQueue.Enqueue(missile);
        }



        public static Dictionary<string, float> GetDictionary()
        {
            Dictionary<string, float> damageRadius = new Dictionary<string, float>();
            damageRadius.Add("QASSAM", 100);
            damageRadius.Add("KATYUSHA", 200);
            damageRadius.Add("GRAD", 300);
            damageRadius.Add("PATZMAR", 400);
            damageRadius.Add("FAJR-3", 500);
            damageRadius.Add("FAJR-5", 600);
            return damageRadius;
        }
        //public void BroadcastStatus(string message)
        //{
        //    this._wss.WebSocketServices["/MissileHandler"].Sessions.Broadcast(message);
        //}

    }
}
