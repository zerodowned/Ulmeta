// Version date: 5/18/2014
// Creator:  ViWinfii

using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Gumps
{
    public class ChooseCultureGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("ChooseCulture", AccessLevel.Player, new CommandEventHandler(ChooseCulture_OnCommand));
        }

        [Usage("ChooseCulture")]
        [Description("Choose your actual cultural language for use with autotranslation.")]
        private static void ChooseCulture_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile.HasGump(typeof(ChooseCultureGump)))
                e.Mobile.CloseGump(typeof(ChooseCultureGump));

            e.Mobile.SendGump(new ChooseCultureGump(e.Mobile));
        }

        private static Dictionary<string, string> m_Cultures;

        private string[] st;

        public static Dictionary<string, string> Cultures
        {
            get
            {
                if (m_Cultures == null)
                {
                    m_Cultures = new Dictionary<string, string>();
                    m_Cultures.Add("English", "en");
                    m_Cultures.Add("Espanol", "es");
                    m_Cultures.Add("Français", "fr");
                    m_Cultures.Add("Deutsch", "de");
                    m_Cultures.Add("Chinese", "zh");
                    m_Cultures.Add("Japanese", "ja");
                    m_Cultures.Add("Korean", "ko");
                    m_Cultures.Add("Portuguese", "pt");
                    m_Cultures.Add("Italian", "it");
                }
                return m_Cultures;
            }
        }

        public ChooseCultureGump(Mobile from)
            : base(0, 0)
        {
            int counter = 0;
            int step = 20;

            this.Closable = false;
            this.Disposable = false;
            this.Dragable = true;
            this.Resizable = false;

            AddPage(0);

            AddBackground(7, 42, 205, 75 + step * Cultures.Count, 9200);

            AddButton(187, 48, 5003, 5003, 0, GumpButtonType.Reply, 0);

            AddLabel(70, 51, 0, @"Culture Menu");
            AddLabel(20, 75, 0, @"Choose your cultural language:");

            st = new string[Cultures.Count];

            foreach (string langname in Cultures.Keys)
            {
                st[counter] = langname;
                this.AddLabel(73, 101 + (step * counter), 0, langname);

                AddButton(143, 108 + (step * counter), 210, 211,  counter, GumpButtonType.Reply, 0);

                counter++;
            }


        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Player from = (Player)sender.Mobile;
            from.Culture =  Cultures[ st[info.ButtonID] ];
            from.SendMessage("Your culture is now set to " + st[info.ButtonID]);
        }
    }
}
