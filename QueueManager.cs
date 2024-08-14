using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace DefenseServer
{
    public class QueueManager
    {
        private readonly WebSocketServer _wss;
        private readonly ConcurrentQueue<Missile> _missileQueue;
       
        static int ironDomeAmount = 4;
        public QueueManager(ConcurrentQueue<Missile> missileQueue, WebSocketServer wss)
        {
            this._missileQueue = missileQueue;
            this._wss = wss;
            
        }


        public void Start()
        {

            
            for (int i = 0; i < ironDomeAmount; i++)
            {
                Thread interceptorThread = new Thread(() => Interceptor(i.ToString()));
                interceptorThread.Start();
            }

        }

        public async void Interceptor(string name)
        {
            IronDome ironDome = new IronDome();
            while (true)
            {
                
                if (this._missileQueue.TryDequeue(out Missile missileToIntercept))
                {

                    bool result = await ironDome.handleMissile(missileToIntercept);
                    var message = new { intercepted = result, missileName = missileToIntercept.Name };
                    var json = JsonSerializer.Serialize(message);
                    this._wss.WebSocketServices["/MissileHandler"].Sessions.Broadcast(json);
                }
            }
        }
    }
}
