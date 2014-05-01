using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GisSharpBlog.NetTopologySuite.IO;

namespace BrawlEventEditor.Brawl
{
    interface IData
    {
        void load(BEBinaryReader reader);
        void save(BEBinaryWriter writer);

        uint get_size();
    }
}
