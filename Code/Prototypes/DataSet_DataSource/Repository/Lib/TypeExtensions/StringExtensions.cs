﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Domain.Lib.TypeExtensions
{
    public static class StringExtensions
    {
        //public static byte[] GetBytes(this string str)
        //{
        //    byte[] bytes = new byte[str.Length * sizeof(char)];
        //    System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        //    return bytes;
        //}

        //public static Stream ToStream(this string str)
        //{
        //    Stream StringStream = new MemoryStream();
        //    StringStream.Read(str.GetBytes(), 0, str.Length);
        //    return StringStream;
        //}

        //public static Stream ToStream(this string str)
        //{
        //    MemoryStream stream = new MemoryStream();

        //    using (StreamWriter writer = new StreamWriter(stream))
        //    {
        //        writer.Write(str);
        //        writer.Flush();
        //        stream.Position = 0;
        //    }
        //    return stream;
        //}
    }
}
