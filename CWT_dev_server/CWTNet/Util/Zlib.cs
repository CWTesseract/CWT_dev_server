﻿using System;
using System.IO;
using Ionic.Zlib;

namespace CWT_dev_server.CWTNet.Util
{
    // Class ripped directly from LastExceed/Exceed.
    public class Zlib
    {
        public static byte[] Compress(byte[] buffer)
        {
            byte[] compressed;
            using (var input = new MemoryStream(buffer))
            using (var compressStream = new MemoryStream())
            using (var compressor = new ZlibStream(compressStream, CompressionMode.Compress, CompressionLevel.BestCompression, true))
            {
                input.CopyTo(compressor);
                compressor.Close();
                compressed = compressStream.ToArray();
            }
            return compressed;
        }

        public static byte[] Decompress(byte[] buffer)
        {
            byte[] toDecompress = new byte[buffer.Length - 2];
            Array.Copy(buffer, 2, toDecompress, 0, toDecompress.Length);

            return DeflateStream.UncompressBuffer(toDecompress);
        }
    }
}
