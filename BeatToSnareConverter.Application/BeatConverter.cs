using System.Collections.Generic;
using System.Linq;

namespace BeatToSnareConverter
{
    public class BeatConverter : IBeatConverter
    {
        public List<int> ConvertBeatToInts(List<int> beats)
        {
            List<int> outPutBeats = new List<int>();
            int totalCount = beats.Count();
            int beatLength = 1;

            for (int i = (totalCount - 1); i >= 0; i--)
            {
                if (beats[i] == 1)
                {
                    outPutBeats.Add(totalCount / beatLength);
                    beatLength = 1;
                }
                else
                {
                    beatLength++;
                }
            }
            outPutBeats.Reverse();

            return outPutBeats;
        }

        public string ConvertBeatsToSnares(List<int> beats)
        {
            string output = "";
            var snares = ConvertBeatToInts(beats);
            
            foreach(var snare in snares)
            {
                output = $"{output} sn{snare}";
            }
            return output.Trim();
        }
    }
}
