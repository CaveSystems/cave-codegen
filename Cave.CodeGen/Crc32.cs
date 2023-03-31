using System;
using System.Runtime.CompilerServices;

#pragma warning disable CS0162

namespace Cave.CodeGen;

/// <summary>Provides a fast managed implementation of the Cyclic Redundancy Checksum with 32 bits taken from the cave-extensions package.</summary>
public sealed class Crc32
{
    #region Static

    /// <summary>The final xor value.</summary>
    public const uint FinalXor = 0xffffffff;

    /// <summary>The initializer value.</summary>
    public const uint Initializer = 0xffffffff;

    /// <summary>The name of the hash.</summary>
    public const string Name = "CRC-32";

    /// <summary>
    /// Provides the default polynomial (*the* standard CRC-32 polynomial, first popularized by Ethernet)
    /// x^32+x^26+x^23+x^22+x^16+x^12+x^11+x^10+x^8+x^7+x^5+x^4+x^2+x^1+x^0 (little endian value).
    /// </summary>
    public const uint Polynomial = 0x04c11db7;

    /// <summary>The reflect input flag.</summary>
    public const bool ReflectInput = true;

    /// <summary>The reflect output flag.</summary>
    public const bool ReflectOutput = true;

    static readonly uint[] table = CalculateReflectedTable();

    /// <summary>
    /// Calculates the combined (crc32) hashcode for the specified objects (using the objects GetHashCode function).
    /// </summary>
    /// <param name="items">Items to get hashcode for.</param>
    /// <returns>Returns a crc32 checksum of all hashcodes.</returns>
    public static int GetHashCode(params object[] items)
    {
        var hash = new Crc32();
        foreach (var item in items)
        {
            var itemHash = item?.GetHashCode() ?? 0;
            hash.HashCore(itemHash);
        }

        return (int)hash.Value;
    }

    /// <summary>
    /// Calculates the combined (crc32) hashcode for the specified items (using the items GetHashCode function).
    /// </summary>
    /// <param name="items">Items to get hashcode for.</param>
    /// <returns>Returns a crc32 checksum of all hashcodes.</returns>
    public static int GetHashCode<T>(params T[] items)
    {
        var hash = new Crc32();
        foreach (var item in items)
        {
            var itemHash = item?.GetHashCode() ?? 0;
            hash.HashCore(itemHash);
        }

        return (int)hash.Value;
    }

    /// <summary>Reflects 32 bits.</summary>
    /// <param name="x">The bits.</param>
    /// <returns>Returns a center reflection.</returns>
    [MethodImpl(256)]
    static uint Reflect32(uint x)
    {
        // move bits
        x = ((x & 0x55555555) << 1) | ((x >> 1) & 0x55555555);
        x = ((x & 0x33333333) << 2) | ((x >> 2) & 0x33333333);
        x = ((x & 0x0F0F0F0F) << 4) | ((x >> 4) & 0x0F0F0F0F);

        // move bytes
        x = (x << 24) | ((x & 0xFF00) << 8) | ((x >> 8) & 0xFF00) | (x >> 24);
        return x;
    }

    #endregion

    #region Properties

    /// <summary>Gets the value of the computed hash code.</summary>
    public byte[] Hash => BitConverter.GetBytes(Value);

    /// <summary>Gets the size, in bits, of the computed hash code.</summary>
    public int HashSize => 32;

    /// <summary>Gets or sets the checksum computed so far.</summary>
    public uint Value
    {
        get
        {
            if (ReflectOutput)
            {
                return currentCRC ^ FinalXor;
            }

            return ~currentCRC ^ FinalXor;
        }
        set => currentCRC = value;
    }

    #endregion

    #region Members

    /// <summary>Directly hashes one byte.</summary>
    /// <param name="byte">The byte.</param>
    [MethodImpl(256)]
    public void HashCore(byte @byte)
    {
        if (ReflectInput)
        {
            var i = (currentCRC ^ @byte) & 0xFF;
            currentCRC = (currentCRC >> 8) ^ table[i];
        }
        else
        {
            var i = ((currentCRC >> 24) ^ @byte) & 0xFF;
            currentCRC = (currentCRC << 8) ^ table[i];
        }
    }

    /// <summary>Adds one hash code to the checksum.</summary>
    /// <param name="value">hash code to add.</param>
    [MethodImpl(256)]
    public void HashCore(int value)
    {
        for (var i = 0; i < 4; i++)
        {
            HashCore((byte)value);
            value >>= 8;
        }
    }

    /// <summary>Updates the hash for the specified data.</summary>
    /// <param name="buffer">Array of bytes to hash.</param>
    /// <param name="offset">Start index of data.</param>
    /// <param name="count">Size of data in bytes.</param>
    public void HashCore(byte[] buffer, int offset, int count)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer));
        }

        for (var i = 0; i < count; i++)
        {
            HashCore(buffer[offset++]);
        }
    }

    #endregion

    #region private funtionality

    uint currentCRC = Initializer;

    static uint[] CalculateReflectedTable()
    {
        var poly = Reflect32(Polynomial);
        var table = new uint[256];
        for (uint i = 0; i < 256; i++)
        {
            var crc = i;
            unchecked
            {
                for (uint n = 0; n < 8; n++)
                {
                    if ((crc & 1) != 0)
                    {
                        crc = (crc >> 1) ^ poly;
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
            }

            table[i] = crc;
        }

        return table;
    }

    #endregion private funtionality
}
