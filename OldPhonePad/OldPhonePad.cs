using System.Text;

namespace IronSW;

/// <summary>
/// Class <c>OldPhonePadTranslator</c> translates key strokes from an old phone keypad into a string.
/// </summary>
public class OldPhonePadTranslator
{
    /// <summary>
    /// Dictionary <c>OLDPAD_MAP</c> maps each key stroke with the generated character.
    /// </summary>
    private static readonly Dictionary<char, string> OLDPAD_MAP = new Dictionary<char, string>() {
        {'1', "&'("},
        {'2', "ABC"},
        {'3', "DEF"},
        {'4', "GHI"},
        {'5', "JKL"},
        {'6', "MNO"},
        {'7', "PQRS"},
        {'8', "TUV"},
        {'9', "WXYZ"},
        {'0', " "}
    };

    /// <summary>
    /// Method <c>OldPhonePad</c> gets a sequence of symbold from an old phone pad as an input and returns the translated string.
    /// </summary>
    public static string OldPhonePad(string input)
    {
        StringBuilder output = new StringBuilder();
        char prevChar = ' ';
        int consecutiveCount = 0;

        /// Iterate over input
        foreach (char c in input)
        {
            if (c == '#')  /// end of input
            {
                break;
            }
            else if (c == '*')  /// delete key
            {
                if (output.Length > 0)  /// delete makes sense only if there's something to delete
                {
                    output.Remove(output.Length - 1, 1);
                    prevChar = ' ';
                }
            }
            else if (c == ' ')  /// reset previous character after stroke pause
            {
                prevChar = ' ';
            }
            else
            {
                if (c == prevChar)  /// the same key has been pressed more than once in a row
                {
                    if (consecutiveCount == OLDPAD_MAP[c].Length)  /// reset count based on the number of characters available for each key
                    {
                        consecutiveCount = 0;
                    }

                    output[output.Length - 1] = OLDPAD_MAP[c][consecutiveCount];
                    consecutiveCount++;
                }
                else   /// new key
                {
                    output.Append(OLDPAD_MAP[c][0]);
                    prevChar = c;
                    consecutiveCount = 1;
                }
            }
        }

        return output.ToString();
    }
}
