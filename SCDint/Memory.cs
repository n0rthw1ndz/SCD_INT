namespace SCDint
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class Memory
    {
        /// <summary>
        /// Conversion dictionary to get bytes of different data types.
        /// </summary>
        private static readonly Dictionary<Type, Func<object, byte[]>> ConvertToBytesDictionary = new Dictionary<Type, Func<object, byte[]>>
            {
                { typeof(byte), x => new[] { (byte)x } },
                { typeof(byte[]), x => (byte[])x },
                { typeof(double), x => BitConverter.GetBytes((double)x) },
                { typeof(float), x => BitConverter.GetBytes((float)x) },
                { typeof(int), x => BitConverter.GetBytes((int)x) },
                { typeof(IntPtr), x => BitConverter.GetBytes(((IntPtr)x).ToInt32()) },
                { typeof(long), x => BitConverter.GetBytes((long)x) },
                { typeof(short), x => BitConverter.GetBytes((short)x) },
                { typeof(string), x => Encoding.ASCII.GetBytes((string)x) },
                { typeof(uint), x => BitConverter.GetBytes((uint)x) },
                { typeof(ulong), x => BitConverter.GetBytes((ulong)x) },
                { typeof(ushort), x => BitConverter.GetBytes((ushort)x) }
            };

        /// <summary>
        /// Conversion dictionary to get data from a byte array.
        /// </summary>
        private static readonly Dictionary<Type, Func<byte[], dynamic>> ConvertToTypeDictionary = new Dictionary<Type, Func<byte[], dynamic>>
            {
                { typeof(byte), x => x[0] },
                { typeof(byte[]), x => x },
                { typeof(double), x => BitConverter.ToDouble(x, 0) },
                { typeof(float), x => BitConverter.ToSingle(x, 0) },
                { typeof(int), x => BitConverter.ToInt32(x, 0) },
                { typeof(IntPtr), x => new IntPtr(BitConverter.ToInt32(x, 0)) },
                { typeof(long), x => BitConverter.ToInt64(x, 0) },
                { typeof(short), x => BitConverter.ToInt16(x, 0) },
                { typeof(string), x => Encoding.ASCII.GetString(x.TakeWhile(c => c != 0).ToArray()) },
                { typeof(uint), x => BitConverter.ToUInt32(x, 0) },
                { typeof(ulong), x => BitConverter.ToUInt64(x, 0) },
                { typeof(ushort), x => BitConverter.ToUInt16(x, 0) }
            };

        /// <summary>
        /// Reads the amount of bytes from the given location.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="lpAddress"></param>
        /// <param name="btBuffer"></param>
        /// <returns></returns>
        private static bool Peek(Process p, IntPtr lpAddress, byte[] btBuffer)
        {
            if (p == null || btBuffer == null || btBuffer.Length == 0)
                return false;

            var read = new IntPtr(0);
            return NativeMethods.ReadProcessMemory(p.Handle, lpAddress, btBuffer, (uint)btBuffer.Length, ref read);
        }

        /// <summary>
        /// Writes the given bytes to the given memory location.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="lpAddress"></param>
        /// <param name="btBuffer"></param>
        /// <returns></returns>
        private static bool Poke(Process p, IntPtr lpAddress, byte[] btBuffer)
        {
            if (p == null)
                return false;

            var written = new IntPtr(0);
            return NativeMethods.WriteProcessMemory(p.Handle, lpAddress, btBuffer, (uint)btBuffer.Length, ref written);
        }

        /// <summary>
        /// Writes the given data to memory if a valid converter is found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <param name="lpAddress"></param>
        /// <param name="value"></param>
        public static void Write<T>(Process p, IntPtr lpAddress, T value)
        {
            // Attempt to locate the type to convert..
            var converter = Memory.ConvertToBytesDictionary[typeof(T)];
            if (converter == null) return;

            // Convert the data to bytes..
            var buffer = converter.Invoke(value);

            // Write the data to memory..
            Memory.Poke(p, lpAddress, buffer);
        }

        /// <summary>
        /// Reads the given address for the given type of data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p"></param>
        /// <param name="lpAddress"></param>
        /// <returns></returns>
        public static dynamic Read<T>(Process p, IntPtr lpAddress)
        {
            // Attempt to locate the type to convert..
            var converter = Memory.ConvertToTypeDictionary[typeof(T)];
            if (converter == null) return null;

            // Read the data..
            var buffer = (typeof(T) == typeof(string)) ? new byte[1024] : new byte[Marshal.SizeOf(typeof(T))];
            Memory.Peek(p, lpAddress, buffer);

            // Convert the buffer..
            return converter.Invoke(buffer);
        }
    }

    /// <summary>
    /// Internal NativeMethods Import Definitions
    /// 
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// kernel32.ReadProcessMemory Import
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="lpNumberOfBytesRead"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        
        internal static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In, Out] byte[] lpBuffer,
            UInt32 nSize,
            ref IntPtr lpNumberOfBytesRead
            );

        /// <summary>
        /// kernel32.WriteProcessMemory Import
        /// </summary>
        /// <param name="hProcess"></param>
        /// <param name="lpBaseAddress"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nSize"></param>
        /// <param name="lpNumberOfBytesWritten"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [In, Out] byte[] lpBuffer,
            UInt32 nSize,
            ref IntPtr lpNumberOfBytesWritten
            );

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetProcessWorkingSetSize(
            IntPtr hProcess,
            UInt32 dwMinimumWorkingSetSize,
            UInt32 dwMaximumWorkingSetSize,
            UInt32 Flags
            );

    }
}
