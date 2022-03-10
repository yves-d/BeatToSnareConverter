using System.Collections.Generic;

namespace BeatToSnareConverter
{
    public interface IBeatConverter
    {
        List<int> ConvertBeatToInts(List<int> beats);

        string ConvertBeatsToSnares(List<int> beats);
    }
}
