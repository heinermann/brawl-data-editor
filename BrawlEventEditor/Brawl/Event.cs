using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlEventEditor.Brawl
{
    enum MatchType
    {
        Time,
        Stock,
        Coin
    };

    enum EventExtension
    {
        Standard4,
        Roster9,
        Everyone38
    };

    class Event : IData
    {
	    uint   m_event_ext;
	    uint   m_u04;
	    byte   m_match_type;
	    byte   m_u09;
	    byte   m_u0A;
	    byte   m_u0B;
	    uint   m_u0C;
	    uint   m_flags_10;
	    uint   m_u14;
	    ushort m_u18;
	    ushort m_u1A;
	    byte   m_u1C;
	    byte   m_u1D;
	    byte   m_u1E;
	    byte   m_stage_id;
	    uint   m_flags_20;
	    uint   m_u24;
        uint   m_item_switch1;
        uint   m_item_switch2;
	    uint   m_poke_switch;
	    uint   m_assist_switch;
	    float  m_game_speed;
	    float  m_camera_shake;
	    uint   m_u40;
	    ushort m_music_catagory;
	    ushort m_music_id;
	    ushort m_u48;
	    ushort m_u4A;
	    uint   m_u4C;

        List<Character> m_characters = new List<Character>();

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
            m_u14               = reader.ReadUInt32();
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
            m_music_catagory    = reader.ReadUInt16();
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
            writer.Write(m_music_catagory);
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
