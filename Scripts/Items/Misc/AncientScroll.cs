using System;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{
	public class AncientScroll : Item
	{
		[Constructable]
		public AncientScroll() : this(1)
		{
		}

		[Constructable]
		public AncientScroll( int amount ) : base( 0x1F4F )
		{
			Name = "an ancient scroll";
			Hue = 1305;
            Movable = true;
            LootType = LootType.Blessed;
		}

		public AncientScroll( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
            if (!IsChildOf(from.Backpack))
            {
                from.SendMessage("This must be in your backpack."); return;
            }

            else from.Target = new BlessTarget(this);
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

        private class BlessTarget : Target
        {
            AncientScroll scroll;

            public BlessTarget(AncientScroll s)
                : base(1, false, TargetFlags.None)
            {
                scroll = s;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Item)
                {
                    Item item = targeted as Item;

                    if (!item.IsChildOf(from.Backpack))
                    {
                        from.SendMessage("This must be in your backpack.");
                        return;
                    }

                    else if (item.LootType == LootType.Blessed)
                    {
                        from.SendMessage("This would be a waste..");
                        return;
                    }

                    else
                    {
                        item.LootType = LootType.Blessed;
                        scroll.Consume();
                        from.PlaySound(0x1EA);
                        from.FixedParticles(14170, 0, 16, 1, 0, 7, EffectLayer.Waist);
                    }
                }

                else from.SendMessage("You must target an item.");
            }
        }
	}
}