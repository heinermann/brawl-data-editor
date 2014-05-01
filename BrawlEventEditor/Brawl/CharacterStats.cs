using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlEventEditor.Brawl
{
    class CharacterStats : IData
    {
        ushort  m_offense_ratio;
        ushort  m_defense_ratio;
        ushort  m_unknown;
        byte    m_stock;
        byte    m_unk2;
        byte    m_unk3;
        byte    m_unk4;
        ushort  m_start_damage;
        ushort  m_unk5;

        public const long SIZE = 14;

        public void load(GisSharpBlog.NetTopologySuite.IO.BEBinaryReader reader)
        {
            m_offense_ratio = reader.ReadUInt16();
            m_defense_ratio = reader.ReadUInt16();
            m_unknown       = reader.ReadUInt16();
            m_stock         = reader.ReadByte();
            m_unk2          = reader.ReadByte();
            m_unk3          = reader.ReadByte();
            m_unk4          = reader.ReadByte();
            m_start_damage  = reader.ReadUInt16();
            m_unk5          = reader.ReadUInt16();
        }

        public void save(GisSharpBlog.NetTopologySuite.IO.BEBinaryWriter writer)
        {
            writer.Write(m_offense_ratio);
            writer.Write(m_defense_ratio);
            writer.Write(m_unknown);
            writer.Write(m_stock);
            writer.Write(m_unk2);
            writer.Write(m_unk3);
            writer.Write(m_unk4);
            writer.Write(m_start_damage);
            writer.Write(m_unk5);
        }

        public long get_size()
        {
            return SIZE;
        }
    }
}
