using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace BrawlEventEditor.Brawl
{
    enum CharacterType : byte
    {
        Mario,
        DonkeyKong,
        Link,
        Samus,
        ZeroSuitSamus,
        Yoshi,
        Kirby,
        Fox,
        Pikachu,
        Luigi,
        CaptainFalcon,
        Ness,
        Bowser,
        Peach,
        Zelda,
        Sheik,
        IceClimbers,
        Popo,
        Nana,
        Marth,
        GameWatch,
        Falco,
        Ganon,
        Wario,
        Metaknight,
        Pit,
        Olimar,
        Lucas,
        DiddyKong,
        TrainerCharizard,
        Charizard,
        TrainerVenasaur,
        Venasaur,
        TrainerSquirtle,
        Squirtle,
        KingDedede,
        Lucario,
        Ike,
        ROB,
        Jigglypuff,
        ToonLink,
        Wolf,
        Snake,
        Sonic,
        GigaBowser,
        WarioMan,
        RedAlloy,
        BlueAlloy,
        YellowAlloy,
        GreenAlloy,
        MarioD,
        BossPeteyPiranha,
        BossRayquaza,
        BossPorkyStatue,
        BossPorky,
        BossGalleom,
        BossRidley,
        BossDuon,
        BossMetaRidley,
        BossTabuu,
        BossMasterHand,
        BossCrazyHand,
        None
    };

    enum Status : byte
    {
        Normal,
        Metal,
        Flat
    };

    [TypeConverter(typeof(ExpandableObjectConverter))]
    class Character : IData
    {
        public CharacterType CharacterType
        {
            get { return (CharacterType)m_character_id; }
            set { m_character_id = (byte)value; }
        }

        public Status Status
        {
            get { return (Status)m_status; }
            set { m_status = (byte)value; }
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

        [TypeConverter(typeof(Types.FloatTypeConverter))]
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

        public byte StartPosition
        {
            get { return m_start_pos; }
            set { m_start_pos = value; }
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
        private byte  m_start_pos;
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
            m_start_pos     = reader.ReadByte();
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
            writer.Write(m_start_pos);
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
