using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thyrsus.Shared;

namespace Thyrsus.World.Classes
{
    public class Worker
    {
        private WorldConfigMgr _worldConfigMgr;
        private CookingSystem _cookingSystem;
        private ScriptMobTombInfo _scriptMobTombInfo;
        private AgitInvestMgr _agitInvestMgr;
        private BigMonster _bigMonster;
        private ChangeMaterialMgr _changeMaterialMgr;
        private Collection _collection;
        private MonsterTransformMgr _monsterTransformMgr;

        public Worker()
        {
            try
            {
                Logging.CriticalLog(Environment.NewLine + LogoGenerator.GeneratorLogo());

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
            throw new NotImplementedException();
        }
    }
}
