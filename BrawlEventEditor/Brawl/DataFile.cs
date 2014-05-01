using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using GisSharpBlog.NetTopologySuite.IO;

namespace BrawlEventEditor.Brawl
{
    class DataFile<T> where T: IData
    {
        SortedDictionary<string, T> m_entries = new SortedDictionary<string, T>();

        const uint HEADER_SIZE = 32;
        const uint ENTRY_SIZE = 8;

        void load(string filename)
        {
            m_entries.Clear();
            FileStream stream = new FileStream(filename, FileMode.Open);
            BEBinaryReader reader = new BEBinaryReader(stream, Encoding.UTF8);

            // Read data header
            uint file_size = reader.ReadUInt32();
            uint table_offset = reader.ReadUInt32() + HEADER_SIZE;
            reader.ReadUInt32();
            uint num_entries = reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();
            reader.ReadUInt32();

            // Read entries
            for ( uint i = 0; i < num_entries; ++i )
            {
                // Read table entry
                stream.Position = table_offset + i * ENTRY_SIZE;
                uint data_offset = reader.ReadUInt32() + HEADER_SIZE;
                uint string_offset = reader.ReadUInt32() + table_offset + num_entries * ENTRY_SIZE;

                // Read data string
                StringBuilder builder = new StringBuilder();
                stream.Position = string_offset;
                char c;
                while ((c = reader.ReadChar()) != '\0')
                    builder.Append(c);
                
                // Read data entry
                stream.Position = data_offset;
                T data = default(T);
                data.load(reader);

                m_entries.Add(builder.ToString(), data);
            }
        }

        void save(string filename)
        {
            FileStream stream = new FileStream(filename, FileMode.CreateNew);
            BEBinaryWriter writer = new BEBinaryWriter(stream, Encoding.UTF8);

            // Retrieve information
            uint file_size = HEADER_SIZE;
            uint table_offset = 0;
            foreach (KeyValuePair<string, T> p in m_entries)
            {
                table_offset += p.Value.get_size();

                file_size += p.Value.get_size();
                file_size += ENTRY_SIZE;
                file_size += (uint)p.Key.Length + 1;
            }

            // Write header data
            writer.Write(file_size);
            writer.Write(table_offset);
            writer.Write((uint)0);
            writer.Write((uint)m_entries.Count);
            writer.Write((uint)0);
            writer.Write((uint)0);
            writer.Write((uint)0);
            writer.Write((uint)0);

            // Write event data, record offsets
            SortedDictionary<string, uint> entry_offsets = new SortedDictionary<string, uint>();
            foreach (KeyValuePair<string, T> p in m_entries)
            {
                entry_offsets.Add(p.Key, (uint)stream.Position - HEADER_SIZE);
                p.Value.save(writer);
            }

            // Write table data
            uint current_string_offset = 0;
            foreach (KeyValuePair<string, uint> p in entry_offsets) // expected to iterate the same as m_entries
            {
                writer.Write(p.Value);
                writer.Write(current_string_offset);
                current_string_offset += (uint)p.Key.Length + 1;
            }

            // Write string data
            foreach (KeyValuePair<string, uint> p in entry_offsets) // expected to iterate the same as m_entries
            {
                writer.Write(p.Key.ToCharArray());
                writer.Write('\0');
            }
        }
    }
}
