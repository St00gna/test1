using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CodeWars
{
    public static string Encode(string text)
        => string.Concat(text.SelectMany(c => Convert.ToString((int)c, 2).PadLeft(8, '0')
            .SelectMany(c => Enumerable.Repeat(c, 3))));

    public static string Decode(string bits)
        => string.Concat(Enumerable.Range(0, bits.Length / 3).Select(i => bits[(3 * i)..(3 * i + 3)] switch
        {
            "000" or "001" or "010" or "100" => 0,
            "111" or "011" or "101" or "110" => 1
        }).Chunk(8).Select(bs => (char)bs.Aggregate((a, b) => (a << 1) | b)));
}