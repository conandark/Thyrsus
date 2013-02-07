using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thyrsus.Shared;

namespace Thyrsus.World.Classes
{
    public class Worker
    {
        public ManualResetEvent ServerShutdown;
        public static Worker Singleton;

        private const int port = 5000;

        private WorldConfigMgr _worldConfigMgr;
        private CookingSystem _cookingSystem;
        private ScriptMobTombInfo _scriptMobTombInfo;
        private AgitInvestMgr _agitInvestMgr;
        private BigMonster _bigMonster;
        private ChangeMaterialMgr _changeMaterialMgr;
        private Collection _collection;
        private MonsterTransformMgr _monsterTransformMgr;
        private TcpListener listener;

        public Worker()
        {
            try
            {
                Logging.CriticalLog(Environment.NewLine + LogoGenerator.GeneratorLogo());

                ServerShutdown = new ManualResetEvent(false);
                Worker.Singleton = this;

                _worldConfigMgr = new WorldConfigMgr();
                _worldConfigMgr.Init();
                _cookingSystem = new CookingSystem();
                _agitInvestMgr = new AgitInvestMgr();
                _scriptMobTombInfo = new ScriptMobTombInfo();
                _bigMonster = new BigMonster();
                _changeMaterialMgr = new ChangeMaterialMgr();
                _changeMaterialMgr.Init();
                _collection = new Collection();
                _collection.LoadLuaFile();
                _monsterTransformMgr = new MonsterTransformMgr();
                _monsterTransformMgr.LoadLuaFile();
            }
            catch (Exception ex)
            {
                Logging.CriticalLog(ex.Message);
            }
        }

        public void Start()
        {
            Thread th = new Thread(WorkerThread);
            th.Start();
        }

        public void Stop()
        {
            ServerShutdown.Set();
        }

        public void WorkerThread()
        {
            this.listener = new TcpListener(new IPEndPoint(System.Net.IPAddress.Any, port));
            this.listener.Start();
            do
            {
                while (this.listener.Pending() == false)
                {
                    if (ServerShutdown.WaitOne(100)) break;
                }
                PC pc = new PC() { Socket = this.listener.AcceptSocket() };
                Thread th = new Thread(pc.Start);
                th.Start();
            } while (true);
        }
    }
}
