using System;
using System.Collections.Generic;
using Server;
using Server.Items;

namespace Server.Mobiles
{
    public class RunicDealer : BaseVendor
    {
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        [Constructable]
        public RunicDealer()
            : base("the Purveyor of Runics")
        {
            RawName = RawName + ",";
        }

        public override void InitSBInfo()
        {
            m_SBInfos.Add(new SBArtifact());
        }

        public Item ApplyHue(Item item, int hue)
        {
            item.Hue = hue;

            return item;
        }

        public override void InitOutfit()
        {
            AddItem(ApplyHue(new Robe(), Utility.RandomSlimeHue()));
            AddItem(ApplyHue(new ThighBoots(), 1175));

            if (Female)
            {
                AddItem(ApplyHue(new LeatherGloves(), 1175));
                AddItem(ApplyHue(new GoldNecklace(), 1175));
            }
            else
            {
                AddItem(ApplyHue(new PlateGloves(), 1175));
                AddItem(ApplyHue(new PlateGorget(), 1175));
            }

            switch (Utility.Random(Female ? 2 : 1))
            {
                case 0: HairItemID = 0x203C; break;
                case 1: HairItemID = 0x203D; break;
            }

            HairHue = Utility.RandomDyedHue();
        }

        public RunicDealer(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}