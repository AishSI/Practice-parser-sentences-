using System.Collections.Generic;

namespace TextAnalysis
{
	static class TextGeneratorTask
	{
		public static string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
		{
			LinkedList<string> intermediatePhrase = new LinkedList<string>();
			intermediatePhrase.AddLast(phraseBeginning);

			for (var i = 0; i < wordsCount; i++)
			{
				if (intermediatePhrase.Count > 1)
					{
					if (nextWords.ContainsKey(intermediatePhrase.Last.Previous.Value + " " + intermediatePhrase.Last.Value))
						intermediatePhrase.AddLast(nextWords[intermediatePhrase.Last.Previous.Value + " " + intermediatePhrase.Last.Value]);
					else if (nextWords.ContainsKey(intermediatePhrase.Last.Value))
						intermediatePhrase.AddLast(nextWords[intermediatePhrase.Last.Value]);
					else return phraseBeginning;
					phraseBeginning += " " + intermediatePhrase.Last.Value.ToString();
					}
				if (intermediatePhrase.Count == 1)
					if (nextWords.ContainsKey(intermediatePhrase.Last.Value))
				{
					intermediatePhrase.AddLast(nextWords[intermediatePhrase.Last.Value]);
					phraseBeginning += " " + intermediatePhrase.Last.Value.ToString();
				}
			}
			return phraseBeginning;
		}
	}
}