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
            set { m_u04 = (byte)value; }
        }

        public byte Unknown09
        {
            get { return m_u09; }
            set { m_u09 = value; }
        }

        public byte Unknown0A
        {
            get { return m_u0A; }
            set { m_u0A = value; }
        }

        public byte Unknown0B
        {
            get { return m_u0B; }
            set { m_u0B = value; }
        }

        public uint Unknown0C
        {
            get { return m_u0C; }
            set { m_u0C = value; }
        }

        [TypeConverter(typeof(Types.UInt32HexTypeConverter))]
        public uint Flags10
        {
            get { return m_flags_10; }
            set { m_flags_10 = value; }
        }

        public float Unknown14
        {
            get { return m_u14; }
            set { m_u14 = value; }
        }

        public ushort Unknown18
        {
            get { return m_u18; }
            set { m_u18 = value; }
        }

        public ushort Unknown1A
        {
            get { return m_u1A; }
            set { m_u1A = value; }
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

        public byte Unknown1E
        {
            get { return m_u1E; }
            set { m_u1E = value; }
        }

        public byte Stage
        {
            get { return m_stage_id; }
            set { m_stage_id = value; }
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

        public float GameSpeed
        {
            get { return m_game_speed; }
            set { m_game_speed = value; }
        }

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

        public ushort Unknown44
        {
            get { return m_u44; }
            set { m_u44 = value; }
        }

        public ushort Music
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

	    private uint   m_event_ext;
	    private uint   m_u04;
	    private byte   m_match_type;
	    private byte   m_u09;
	    private byte   m_u0A;
	    private byte   m_u0B;
	    private uint   m_u0C;
	    private uint   m_flags_10;
	    private float  m_u14;
	    private ushort m_u18;
	    private ushort m_u1A;
	    private byte   m_u1C;
	    private byte   m_u1D;
	    private byte   m_u1E;
	    private byte   m_stage_id;
	    private uint   m_flags_20;
	    private uint   m_u24;
        private uint   m_item_switch1;
        private uint   m_item_switch2;
	    private uint   m_poke_switch;
	    private uint   m_assist_switch;
	    private float  m_game_speed;
	    private float  m_camera_shake;
	    private uint   m_u40;
	    private ushort m_u44;
	    private ushort m_music_id;
	    private ushort m_u48;
	    private ushort m_u4A;
	    private uint   m_u4C;

        private List<Character> m_characters = new List<Character>();

        public const uint HEAD_SIZE = 70;

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
            m_u09               = reader.ReadByte();
            m_u0A               = reader.ReadByte();
            m_u0B               = reader.ReadByte();
            m_u0C               = reader.ReadUInt32();
            m_flags_10          = reader.ReadUInt32();
            m_u14               = reader.ReadSingle();
            m_u18               = reader.ReadUInt16();
            m_u1A               = reader.ReadUInt16();
            m_u1C               = reader.ReadByte();
            m_u1D               = reader.ReadByte();
            m_u1E               = reader.ReadByte();
            m_stage_id          = reader.ReadByte();
            m_flags_20          = reader.ReadUInt32();
            m_u24               = reader.ReadUInt32();
            m_item_switch1      = reader.ReadUInt32();
            m_item_switch2      = reader.ReadUInt32();
            m_poke_switch       = reader.ReadUInt32();
            m_assist_switch     = reader.ReadUInt32();
            m_game_speed        = reader.ReadSingle();
            m_camera_shake      = reader.ReadSingle();
            m_u40               = reader.ReadUInt32();
            m_u44    = reader.ReadUInt16();
            m_music_id          = reader.ReadUInt16();
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
            writer.Write(m_u09);
            writer.Write(m_u0A);
            writer.Write(m_u0B);
            writer.Write(m_u0C);
            writer.Write(m_flags_10);
            writer.Write(m_u14);
            writer.Write(m_u18);
            writer.Write(m_u1A);
            writer.Write(m_u1C);
            writer.Write(m_u1D);
            writer.Write(m_u1E);
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
            writer.Write(m_u44);
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
