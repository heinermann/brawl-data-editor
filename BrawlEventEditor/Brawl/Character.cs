using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrawlEventEditor.Brawl
{
    class Character : IData
    {
        public byte  m_character_id;
        public byte  m_status;
        public byte  m_unk_02;
        public byte  m_unk_03;
        public float m_chara_size;
        public byte  m_team;
        public byte  m_unk_09;
        public byte  m_unk_0A;
        public byte  m_unk_0B;
        public byte  m_unk_0C;
        public byte  m_unk_0D;

        public CharacterStats Easy = new CharacterStats();
        public CharacterStats Medium = new CharacterStats();
        public CharacterStats Hard = new CharacterStats();

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

            Easy.load(reader);
            Medium.load(reader);
            Hard.load(reader);
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

            Easy.save(writer);
            Medium.save(writer);
            Hard.save(writer);
        }

        public uint get_size()
        {
            return SIZE;
        }
    }
}
