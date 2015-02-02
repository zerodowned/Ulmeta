using System;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
    public class KOGump : Gump
    {
        private Player _from;

        public KOGump( Player from, TimeSpan respawnTime )
            : base(0, 0)
        {
            _from = from;

            this.Closable = false;
            this.Disposable = false;
            this.Dragable = false;
            this.Resizable = false;

            Timer.DelayCall(respawnTime, new TimerStateCallback(Resend), Tuple.Create<Player, TimeSpan>(from, respawnTime));

            AddPage(1);

            for (int i = 0; i <= 9; i++)
            {
                int xOffset = 127;
                int yOffset = 125;

                for (int j = 0; j <= 10; j++)
                {
                    this.AddImage(j * xOffset, i * yOffset, 5058, 2999);
                }
            }

            AddHtml(65, 75, 215, 100, "<Center>You have been knocked out! You must wait here for another adventurer to assist you, or wait to regain consciousness on your own.</Center>", true, false);
            AddHtml(65, 175, 215, 30, String.Format("<Center>Current Knockout Count: {0}</Center>", from.KOCount), true, false);
            AddHtml(65, 225, 215, 30, String.Format("<CENTER>Automatic recovery in {0} second{1}.</CENTER>", respawnTime.Seconds, (respawnTime.Seconds == 1 ? "" : "s")), true, false);
        }

        public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
        {
               //if( info.ButtonID == 1 )
                //Suicide Maybe?
        }

        private void Resend( object state )
        {
            Tuple<Player, TimeSpan> args = (Tuple<Player, TimeSpan>)state;
            Player pm = args.Item1;
            TimeSpan minToRespawn = args.Item2;

            if( pm == null || pm.Alive )
                return;

            pm.CloseGump(typeof(KOGump));

            if( minToRespawn.Minutes <= 0 && pm.NetState != null )
                pm.AutoRespawn();
            else
               pm.SendGump(new KOGump(pm, minToRespawn));
        }
    }
}