using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BrawlEventEditor.Brawl
{
    enum MatchType : byte
    {
        Time,
        Stock,
        Coin
    };

    enum EventExtension : uint
    {
        Standard4,
        Roster9,
        Everyone38
    };

    enum ItemLevel : ushort
    {
        None,
        Low,
        Medium,
        High,
        Raining
    };

    enum Stage : ushort
    {
        Dummy,
        Battlefield,
        FinalDestination,
        DelfinoPlaza,
        LuigisMansion,
        MushroomyKingdom,
        MarioCircuit,
        Donnkey75m,
        RumbleFalls,
        PirateShip,
        Zelda2,
        Norfair,
        FrigateOrpheon,
        YoshisIsland,
        Halberd,
        TestHalberd00,
        TestHalberd01,
        TestHalberd02,
        Karby2,
        LylatCruise,
        PokemonStadium2,
        SpearPillar,
        PortTownAeroDive,
        Summit,
        FlatZone2,
        CastleSiege,
        TestEmblem00,
        TestEmblem01,
        WarioWareInc,
        DistantPlanet,
        Skyworld,
        MarioBros,
        NewPorkCity,
        Smashville,
        ShadowMosesIsland,
        GreenHillZone,
        PictoChat,
        Hanenbow,
        ConfigTest,
        Viewer,
        Result,
        MeleeTemple,
        MeleeYoshisIsland,
        MeleeJungleJapes,
        MeleeOnett,
        MeleeGreens,
        MeleePokemonStadium,
        MeleeRainbowCruise,
        MeleeCorneria,
        MeleeBigBlue,
        MeleeBrinstar,
        BridgeOfEldin,
        HomerunContest,
        StageEdit,
        Heal,
        OnlineTraining,
        TargetBreak,
        CharaRoll,
        General,
        Adventure,
        Adventure0,
        Adventure2,
        AdvMeleeTest,
        AdvMelee,
        BattleS,
        BattleFieldS
    }

    class Event : IData
    {
        public EventExtension EventExtension
        {
            get { return (EventExtension)m_event_ext; }
        }

        public uint Unknown04
        {
            get { return m_u04; }
            set { m_u04 = value; }
        }

        public MatchType MatchType
        {
            get { return (MatchType)m_match_type; }
            set { m_match_type = (byte)value; }
        }

        public byte Unknown09
        {
            get { return m_padding09; }
            set { m_padding09 = value; }
        }

        public byte Unknown0A
        {
            get { return m_padding0A; }
            set { m_padding0A = value; }
        }

        public byte Unknown0B
        {
            get { return m_padding0B; }
            set { m_padding0B = value; }
        }


        public uint CountdownTime
        {
            get { return m_countdown; }
            set { m_countdown = value; }
        }

        [TypeConverter(typeof(Types.UInt32HexTypeConverter))]
        public uint Flags10
        {
            get { return m_flags_10; }
            set { m_flags_10 = value; }
        }

        [TypeConverter(typeof(Types.FloatTypeConverter))]
        public float Unknown14
        {
            get { return m_u14; }
            set { m_u14 = value; }
        }

        // 0x80 = hide damage
        public byte Flags18
        {
            get { return m_u18; }
            set { m_u18 = value; }
        }

        public bool IsTeamGame
        {
            get { return m_is_team_game != 0; }
            set { m_is_team_game = (byte)(value ? 0 : 1); }
        }

        [Category("Item Switch")]
        public ItemLevel ItemLevel
        {
            get { return (ItemLevel)m_item_level; }
            set { m_item_level = (ushort)value; }
        }

        public byte Unknown1C
        {
            get { return m_u1C; }
            set { m_u1C = value; }
        }

        public byte Unknown1D
        {
            get { return m_u1D; }
            set { m_u1D = value; }
        }

        public Stage Stage
        {
            get { return (Stage)m_stage_id; }
            set { m_stage_id = (ushort)value; }
        }

        [TypeConverter(typeof(Types.UInt32HexTypeConverter))]
        public uint Flags20
        {
            get { return m_flags_20; }
            set { m_flags_20 = value; }
        }

        public uint Unknown24
        {
            get { return m_u24; }
            set { m_u24 = value; }
        }

        [Category("Item Switch"), TypeConverter(typeof(Types.UInt32HexTypeConverter))]
        public uint ItemSwitch1
        {
            get { return m_item_switch1; }
            set { m_item_switch1 = value; }
        }

        [Category("Item Switch"), TypeConverter(typeof(Types.UInt32HexTypeConverter))]
        public uint ItemSwitch2
        {
            get { return m_item_switch2; }
            set { m_item_switch2 = value; }
        }

        [Category("Item Switch"), TypeConverter(typeof(Types.UInt32HexTypeConverter))]
        public uint PokemonSwitch
        {
            get { return m_poke_switch; }
            set { m_poke_switch = value; }
        }

        [Category("Item Switch"), TypeConverter(typeof(Types.UInt32HexTypeConverter))]
        public uint AssistTrophySwitch
        {
            get { return m_assist_switch; }
            set { m_assist_switch = value; }
        }

        [TypeConverter(typeof(Types.FloatTypeConverter))]
        public float GameSpeed
        {
            get { return m_game_speed; }
            set { m_game_speed = value; }
        }

        [TypeConverter(typeof(Types.FloatTypeConverter))]
        public float CameraShake
        {
            get { return m_camera_shake; }
            set { m_camera_shake = value; }
        }

        [TypeConverter(typeof(Types.UInt32HexTypeConverter))]
        public uint Unknown40
        {
            get { return m_u40; }
            set { m_u40 = value; }
        }

        public uint Music
        {
            get { return m_music_id; }
            set { m_music_id = value; }
        }

        public ushort Unknown48
        {
            get { return m_u48; }
            set { m_u48 = value; }
        }

        public ushort Unknown4A
        {
            get { return m_u4A; }
            set { m_u4A = value; }
        }

        public uint Unknown4C
        {
            get { return m_u4C; }
            set { m_u4C = value; }
        }

        public List<Character> Characters
        {
            get { return m_characters; }
        }

	    private uint    m_event_ext;
	    private uint    m_u04;
	    private byte    m_match_type;
	    private byte    m_padding09;
	    private byte    m_padding0A;
	    private byte    m_padding0B;
	    private uint    m_countdown;
	    private uint    m_flags_10;
	    private float   m_u14;
        private byte    m_u18;
        private byte    m_is_team_game;
	    private ushort  m_item_level;
	    private byte    m_u1C;
	    private byte    m_u1D;
	    private ushort  m_stage_id;
	    private uint    m_flags_20;
	    private uint    m_u24;
        private uint    m_item_switch1;
        private uint    m_item_switch2;
	    private uint    m_poke_switch;
	    private uint    m_assist_switch;
	    private float   m_game_speed;
	    private float   m_camera_shake;
	    private uint    m_u40;
	    private uint    m_music_id;
	    private ushort  m_u48;
	    private ushort  m_u4A;
	    private uint    m_u4C;

        private List<Character> m_characters = new List<Character>();

        public const uint HEAD_SIZE = 80;

        uint num_players(EventExtension ext)
        {
            switch (ext)
            {
                case EventExtension.Standard4: return 4;
                case EventExtension.Roster9: return 9;
                case EventExtension.Everyone38: return 38;
                default: return 0;
            }
        }

        EventExtension get_event_ext(long num_players)
        {
            if (num_players <= 4) return EventExtension.Standard4;
            else if (num_players <= 9) return EventExtension.Roster9;
            else if (num_players <= 38) return EventExtension.Everyone38;
            else return EventExtension.Everyone38;
        }

        public void load(GisSharpBlog.NetTopologySuite.IO.BEBinaryReader reader)
        {
            m_event_ext         = reader.ReadUInt32();
            m_u04               = reader.ReadUInt32();
            m_match_type        = reader.ReadByte();
            m_padding09         = reader.ReadByte();
            m_padding0A         = reader.ReadByte();
            m_padding0B         = reader.ReadByte();
            m_countdown         = reader.ReadUInt32();
            m_flags_10          = reader.ReadUInt32();
            m_u14               = reader.ReadSingle();
            m_u18               = reader.ReadByte();
            m_is_team_game      = reader.ReadByte();
            m_item_level        = reader.ReadUInt16();
            m_u1C               = reader.ReadByte();
            m_u1D               = reader.ReadByte();
            m_stage_id          = reader.ReadUInt16();
            m_flags_20          = reader.ReadUInt32();
            m_u24               = reader.ReadUInt32();
            m_item_switch1      = reader.ReadUInt32();
            m_item_switch2      = reader.ReadUInt32();
            m_poke_switch       = reader.ReadUInt32();
            m_assist_switch     = reader.ReadUInt32();
            m_game_speed        = reader.ReadSingle();
            m_camera_shake      = reader.ReadSingle();
            m_u40               = reader.ReadUInt32();
            m_music_id          = reader.ReadUInt32();
            m_u48               = reader.ReadUInt16();
            m_u4A               = reader.ReadUInt16();
            m_u4C               = reader.ReadUInt32();

            long num_chara = num_players((EventExtension)m_event_ext);
            for (long i = 0; i < num_chara; ++i)
            {
                Character newchara = new Character();
                newchara.load(reader);
                m_characters.Add(newchara);
            }
        }

        public void save(GisSharpBlog.NetTopologySuite.IO.BEBinaryWriter writer)
        {
            writer.Write(m_event_ext);
            writer.Write(m_u04);
            writer.Write(m_match_type);
            writer.Write(m_padding09);
            writer.Write(m_padding0A);
            writer.Write(m_padding0B);
            writer.Write(m_countdown);
            writer.Write(m_flags_10);
            writer.Write(m_u14);
            writer.Write(m_u18);
            writer.Write(m_is_team_game);
            writer.Write(m_item_level);
            writer.Write(m_u1C);
            writer.Write(m_u1D);
            writer.Write(m_stage_id);
            writer.Write(m_flags_20);
            writer.Write(m_u24);
            writer.Write(m_item_switch1);
            writer.Write(m_item_switch2);
            writer.Write(m_poke_switch);
            writer.Write(m_assist_switch);
            writer.Write(m_game_speed);
            writer.Write(m_camera_shake);
            writer.Write(m_u40);
            writer.Write(m_music_id);
            writer.Write(m_u48);
            writer.Write(m_u4A);
            writer.Write(m_u4C);

            foreach (Character chara in m_characters)
                chara.save(writer);
        }

        public uint get_size()
        {
            return HEAD_SIZE + num_players(get_event_ext(m_characters.Count))*Character.SIZE;
        }
    }
}
