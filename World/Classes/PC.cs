using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thyrsus.World.Classes
{
    public class PC
    {
        public PCItem PCItem;
        public PCItemInventoryMgr PCInventoryManager;
        public PCSkill PCSkill;
        public PCPacketHandler PCPacketHandler;
        public PCBattle PCBattle;
        public PCQuestEvent PCQuestEvent;
        public PCProperty PCProperty;

        public PC()
        {
            PCItem = new PCItem(this);
            PCInventoryManager = new PCItemInventoryMgr(this);
            PCSkill = new PCSkill(this);
            PCPacketHandler = new PCPacketHandler(this);
            PCBattle = new PCBattle(this);
            PCQuestEvent = new PCQuestEvent(this);
            PCProperty = new PCProperty(this);
        }

        public void Init()
        {
            PCItem.Init();
            PCInventoryManager.Init();
            PCSkill.Init();
            PCPacketHandler.Init();
            PCBattle.Init();
            PCQuestEvent.Init();
            PCProperty.Init();
        }
    }
}
