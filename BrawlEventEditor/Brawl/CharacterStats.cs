using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlEventEditor.Brawl
{
    class CharacterStats : IData
    {
        public ushort  m_offense_ratio;
        public ushort  m_defense_ratio;
        public ushort  m_unknown;
        public byte    m_stock;
        public byte    m_unk2;
        public byte    m_unk3;
        public byte    m_unk4;
        public ushort  m_start_damage;
        public ushort  m_unk5;

        public const uint SIZE = 14;

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

        public uint get_size()
        {
            return SIZE;
        }
    }
}
