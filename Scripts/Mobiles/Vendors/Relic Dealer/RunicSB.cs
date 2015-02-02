using System; 
using System.Collections; 
using Server.Items;
using System.Collections.Generic;


namespace Server.Mobiles 
{ 
	public class SBArtifact : SBInfo
	{
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBArtifact()
		{ 
		}

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo> 
		{
            public InternalBuyInfo()
            {
                /*Armor*/
                Add(new GenericBuyInfo("Voice Of The Fallen King", typeof(VoiceOfTheFallenKing), 100000, 1, 5063, 1361));
                Add(new GenericBuyInfo("Tunic Of Fire", typeof(TunicOfFire), 100000, 1, 5055, 1358));
                Add(new GenericBuyInfo("Spirit Of The Totem", typeof(SpiritOfTheTotem), 100000, 1, 5445, 1156));
                Add(new GenericBuyInfo("Shadow Dancer Leggings", typeof(ShadowDancerLeggings), 100000, 1, 5067, 1109));
                Add(new GenericBuyInfo("Ornate Crown Of The Harrower", typeof(OrnateCrownOfTheHarrower), 100000, 1, 5201, 1370));
                Add(new GenericBuyInfo("Midnight Bracers", typeof(MidnightBracers), 100000, 1, 5198, 1109));
                Add(new GenericBuyInfo("Leggings Of Bane", typeof(LeggingsOfBane), 100000, 1, 5054, 1369));
                Add(new GenericBuyInfo("Jackals Collar", typeof(JackalsCollar), 100000, 1, 5139, 1355));
                Add(new GenericBuyInfo("Inquisitors Resolution", typeof(InquisitorsResolution), 100000, 1, 5140, 1266));
                Add(new GenericBuyInfo("Hunters Headdress", typeof(HuntersHeaddress), 100000, 1, 5447, 1401));
                Add(new GenericBuyInfo("HolyKnights Breastplate", typeof(HolyKnightsBreastplate), 100000, 1, 5141, 1153));
                Add(new GenericBuyInfo("Helm Of Insight", typeof(HelmOfInsight), 100000, 1, 5138, 1364));
                Add(new GenericBuyInfo("Hat Of The Magi", typeof(HatOfTheMagi), 100000, 1, 5912, 1153));
                Add(new GenericBuyInfo("Gauntlets Of Nobility", typeof(GauntletsOfNobility), 100000, 1, 5099, 1378));
                Add(new GenericBuyInfo("Divine Countenance", typeof(DivineCountenance), 100000, 1, 5450, 1154));
                Add(new GenericBuyInfo("Armor of Fortune", typeof(ArmorOfFortune), 100000, 1, 5083, 1281));
                Add(new GenericBuyInfo("Arcane Shield", typeof(ArcaneShield), 100000, 1, 7032, 1366));
                Add(new GenericBuyInfo("AEgis", typeof(Aegis), 100000, 1, 7030, 1153));
                /*Weaponry*/
                Add(new GenericBuyInfo("Zyronic Claw", typeof(ZyronicClaw), 100000, 1, 3909, 1157));
                Add(new GenericBuyInfo("Titans Hammer", typeof(TitansHammer), 100000, 1, 5177, 1154));
                Add(new GenericBuyInfo("The Task Master", typeof(TheTaskmaster), 100000, 1, 5125, 1272));
                Add(new GenericBuyInfo("The Dragon Slayer", typeof(TheDragonSlayer), 100000, 1, 9920, 1328));
                Add(new GenericBuyInfo("The Berserkers Maul", typeof(TheBeserkersMaul), 100000, 1, 5179, 33));
                Add(new GenericBuyInfo("Staff Of The Magi", typeof(StaffOfTheMagi), 100000, 1, 3569, 1153));
                Add(new GenericBuyInfo("Serpents Fang", typeof(SerpentsFang), 100000, 1, 5121, 1160));
                Add(new GenericBuyInfo("Legacy Of The Dread Lord", typeof(LegacyOfTheDreadLord), 100000, 1, 3917, 1209));
                Add(new GenericBuyInfo("Frostbringer", typeof(Frostbringer), 100000, 1, 5042, 1266));
                Add(new GenericBuyInfo("Breath Of The Dead", typeof(BreathOfTheDead), 100000, 1, 9915, 1109));
                Add(new GenericBuyInfo("Bone Crusher", typeof(BoneCrusher), 100000, 1, 5127, 1540));
                Add(new GenericBuyInfo("Blade Of The Righteous", typeof(BladeOfTheRighteous), 100000, 1, 3937, 1153));
                Add(new GenericBuyInfo("Blade Of Insanity", typeof(BladeOfInsanity), 100000, 1, 5119, 1103));
                Add(new GenericBuyInfo("Axe Of The Heavens", typeof(AxeOfTheHeavens), 100000, 1, 3915, 1237));
                /*Items*/
                Add(new GenericBuyInfo("Ring Of The Vile", typeof(RingOfTheVile), 100000, 1, 4234, 1268));
                Add(new GenericBuyInfo("Ring Of The Elements", typeof(RingOfTheElements), 100000, 1, 4234, 0));
                Add(new GenericBuyInfo("Ornament Of The Magician", typeof(OrnamentOfTheMagician), 100000, 1, 4230, 299));
                Add(new GenericBuyInfo("Bracelet Of Health", typeof(BraceletOfHealth), 100000, 1, 4230, 33));
            }
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				
            }
		} 
	} 
}
