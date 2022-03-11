using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImageToolbox
{
    static class Check
    {
        public static void Equals(string name, object actual, params object[] expected)
        {
            foreach (object test in expected)
            {
                if ((actual == null && test == null) || actual.Equals(test))
                {
                    // got a match all good
                    return;
                }
            }

            // get here it doesn't match so generate the message
            // quote the expected value(s)
            IEnumerable<string> quoted = expected.Select(e => $"'{e}'");
            // grab the last one
            string should = quoted.Last().ToString();
            // if there's more than one build a comma separated list
            if (expected.Length > 1)
            {
                // and put it in front of the last value with an or
                should = string.Join(", ", quoted.Take(expected.Length - 1)) + " or " + should;
            }

            throw new Exception($"Unexpected {name}: got '{actual}', should be {should}");
        }

        public static void NullPadding(BinaryReader reader, int count)
        {
            // if any of the read bytes aren't null
            if (reader.ReadBytes(count).Any(b => b != 0))
            {
                throw new Exception($"Expected {count} null padding bytes");
            }
        }
    }
}
