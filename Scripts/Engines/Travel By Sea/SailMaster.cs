using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using System.Collections.Generic;

namespace Khazman.TravelBySea
{
	public class FerryCaptain : BaseVendor
	{
        private List<SBInfo> m_SBInfos = new List<SBInfo>();
		private static bool m_Talked;
        protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

		public override bool DisallowAllMoves{ get{ return true; } }
		public override bool ShowFameTitle{ get{ return false; } }

        Point3D endPoint, ferryLocation;
        string locationName;

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D EndPoint
        {
            get { return ferryLocation; }
            set { ferryLocation = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D FerryLocation
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public string LocationName 
        { 
            get { return locationName;  }
            set { locationName = value;  }
        } 

		[Constructable]
		public FerryCaptain() : base( "the ferry captain" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBSailMaster() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();
		}

		public FerryCaptain( Serial serial ) : base( serial )
		{
		}

		public override bool HandlesOnSpeech( Mobile from )
		{
			if ( from.InRange( this.Location, 5 ) )
				return true;

			return base.HandlesOnSpeech( from );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
		  	if( m_Talked == false && m is PlayerMobile )
			{
				if ( m.InRange( this, 1 ) )
				{
					m_Talked = true;
					this.Say( "Hail and well met." );
					this.Say( "When thee are wishing to sail, just say so and we can make arrangements." );
					this.Direction = GetDirectionTo( m.Location );
					SpamTimer t = new SpamTimer();
					t.Start();
				}
			}
		}
 
		private class SpamTimer : Timer
		{
			public SpamTimer() : base( TimeSpan.FromSeconds( 15 ) )
			{
				Priority = TimerPriority.OneSecond;
			}

			protected override void OnTick()
			{
					m_Talked = false;
			}
		}

		public override void OnSpeech(SpeechEventArgs e )
		{
			if ( !e.Handled && e.Mobile.InRange( Location, 1 ) )
			{
				if (e.Speech.ToLower().IndexOf( "sail" ) >= 0 )
				{
					e.Mobile.SendGump( new SailDestinationGump( e.Mobile, Location, FerryLocation, EndPoint, LocationName ) );
					Direction = GetDirectionTo( e.Mobile.Location );
				}
			}

			base.OnSpeech( e );
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );

            writer.Write(EndPoint);
            writer.Write(FerryLocation);
            writer.Write(LocationName);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            EndPoint = reader.ReadPoint3D();
            FerryLocation = reader.ReadPoint3D();
            LocationName = reader.ReadString();
		}
	}
}