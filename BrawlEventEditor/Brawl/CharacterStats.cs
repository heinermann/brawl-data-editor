using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BrawlEventEditor.Brawl
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    class CharacterStats : IData
    {
        public ushort OffenseRatio
        {
            get { return m_offense_ratio; }
            set { m_offense_ratio = value; }
        }

        public ushort DefenseRatio
        {
            get { return m_defense_ratio; }
            set { m_defense_ratio = value; }
        }

        public byte Unknown04
        {
            get { return m_unk04; }
            set { m_unk04 = value; }
        }

        public byte Unknown05
        {
            get { return m_unk05; }
            set { m_unk05 = value; }
        }

        public byte Stock
        {
            get { return m_stock; }
            set { m_stock = value; }
        }

        public byte Unknown07
        {
            get { return m_unk07; }
            set { m_unk07 = value; }
        }

        public byte Unknown08
        {
            get { return m_unk08; }
            set { m_unk08 = value; }
        }

        public byte Unknown09
        {
            get { return m_unk09; }
            set { m_unk09 = value; }
        }

        public ushort Damagge
        {
            get { return m_start_damage; }
            set { m_start_damage = value; }
        }

        public byte Unknown0C
        {
            get { return m_unk0C; }
            set { m_unk0C = value; }
        }

        public byte Unknown0D
        {
            get { return m_unk0D; }
            set { m_unk0D = value; }
        }

        public ushort  m_offense_ratio;
        public ushort  m_defense_ratio;
        public byte    m_unk04;
        public byte    m_unk05;
        public byte    m_stock;
        public byte    m_unk07;
        public byte    m_unk08;
        public byte    m_unk09;
        public ushort  m_start_damage;
        public byte    m_unk0C;
        public byte    m_unk0D;

        public const uint SIZE = 14;

        public void load(GisSharpBlog.NetTopologySuite.IO.BEBinaryReader reader)
        {
            m_offense_ratio = reader.ReadUInt16();
            m_defense_ratio = reader.ReadUInt16();
            m_unk04         = reader.ReadByte();
            m_unk05         = reader.ReadByte();
            m_stock         = reader.ReadByte();
            m_unk07         = reader.ReadByte();
            m_unk08         = reader.ReadByte();
            m_unk09         = reader.ReadByte();
            m_start_damage  = reader.ReadUInt16();
            m_unk0C         = reader.ReadByte();
            m_unk0D         = reader.ReadByte();
        }

        public void save(GisSharpBlog.NetTopologySuite.IO.BEBinaryWriter writer)
        {
            writer.Write(m_offense_ratio);
            writer.Write(m_defense_ratio);
            writer.Write(m_unk04);
            writer.Write(m_unk05);
            writer.Write(m_stock);
            writer.Write(m_unk07);
            writer.Write(m_unk08);
            writer.Write(m_unk09);
            writer.Write(m_start_damage);
            writer.Write(m_unk0C);
            writer.Write(m_unk0D);
        }

        public uint get_size()
        {
            return SIZE;
        }
    }
}
