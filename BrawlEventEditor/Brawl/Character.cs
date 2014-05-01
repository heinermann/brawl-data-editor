using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BrawlEventEditor.Brawl
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    class Character : IData
    {
        public byte CharacterId
        {
            get { return m_character_id; }
            set { m_character_id = value; }
        }

        public byte Status
        {
            get { return m_status; }
            set { m_status = value; }
        }

        public byte Unknown02
        {
            get { return m_unk_02; }
            set { m_unk_02 = value; }
        }

        public byte Unknown03
        {
            get { return m_unk_03; }
            set { m_unk_03 = value; }
        }

        public float Size
        {
            get { return m_chara_size; }
            set { m_chara_size = value; }
        }

        public byte Team
        {
            get { return m_team; }
            set { m_team = value; }
        }

        public byte Unknown09
        {
            get { return m_unk_09; }
            set { m_unk_09 = value; }
        }

        public byte Unknown0A
        {
            get { return m_unk_0A; }
            set { m_unk_0A = value; }
        }

        public byte Unknown0B
        {
            get { return m_unk_0B; }
            set { m_unk_0B = value; }
        }

        public byte Unknown0C
        {
            get { return m_unk_0C; }
            set { m_unk_0C = value; }
        }

        public byte Unknown0D
        {
            get { return m_unk_0D; }
            set { m_unk_0D = value; }
        }

        [Category("Stats")]
        public CharacterStats Easy
        {
            get { return m_easy_stats; }
            set { m_easy_stats = value; }
        }

        [Category("Stats")]
        public CharacterStats Medium
        {
            get { return m_medium_stats; }
            set { m_medium_stats = value; }
        }

        [Category("Stats")]
        public CharacterStats Hard
        {
            get { return m_hard_stats; }
            set { m_hard_stats = value; }
        }

        private byte  m_character_id;
        private byte  m_status;
        private byte  m_unk_02;
        private byte  m_unk_03;
        private float m_chara_size;
        private byte  m_team;
        private byte  m_unk_09;
        private byte  m_unk_0A;
        private byte  m_unk_0B;
        private byte  m_unk_0C;
        private byte  m_unk_0D;

        private CharacterStats m_easy_stats = new CharacterStats();
        private CharacterStats m_medium_stats = new CharacterStats();
        private CharacterStats m_hard_stats = new CharacterStats();

        public const uint SIZE = 14 + 3 * CharacterStats.SIZE;

        public void load(GisSharpBlog.NetTopologySuite.IO.BEBinaryReader reader)
        {
            m_character_id  = reader.ReadByte();
            m_status        = reader.ReadByte();
            m_unk_02        = reader.ReadByte();
            m_unk_03        = reader.ReadByte();
            m_chara_size    = reader.ReadSingle();
            m_team          = reader.ReadByte();
            m_unk_09        = reader.ReadByte();
            m_unk_0A        = reader.ReadByte();
            m_unk_0B        = reader.ReadByte();
            m_unk_0C        = reader.ReadByte();
            m_unk_0D        = reader.ReadByte();

            m_easy_stats.load(reader);
            m_medium_stats.load(reader);
            m_hard_stats.load(reader);
        }

        public void save(GisSharpBlog.NetTopologySuite.IO.BEBinaryWriter writer)
        {
            writer.Write(m_character_id);
            writer.Write(m_status);
            writer.Write(m_unk_02);
            writer.Write(m_unk_03);
            writer.Write(m_chara_size);
            writer.Write(m_team);
            writer.Write(m_unk_09);
            writer.Write(m_unk_0A);
            writer.Write(m_unk_0B);
            writer.Write(m_unk_0C);
            writer.Write(m_unk_0D);

            m_easy_stats.save(writer);
            m_medium_stats.save(writer);
            m_hard_stats.save(writer);
        }

        public uint get_size()
        {
            return SIZE;
        }
    }
}
