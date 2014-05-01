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
        }
    }
}
