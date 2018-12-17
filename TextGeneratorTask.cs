using System.Collections.Generic;

namespace TextAnalysis
{
	static class TextGeneratorTask
	{
		public static string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning, int wordsCount)
		{
			var listWords = phraseBeginning.ToLower().Split(new char[] { ' ' });
			LinkedList<string> intermediatePhrase = new LinkedList<string>();
			foreach (var w in listWords)
				intermediatePhrase.AddLast(w);
			for (var i = 0; i < wordsCount; i++)
			{
				if (nextWords.ContainsKey((intermediatePhrase.Count > 1
					? intermediatePhrase.Last.Previous.Value
					: "") + " " + intermediatePhrase.Last.Value))
					intermediatePhrase.AddLast(
						nextWords[intermediatePhrase.Last.Previous.Value 
						+ " " + intermediatePhrase.Last.Value]);
				else if (nextWords.ContainsKey(intermediatePhrase.Last.Value))
					intermediatePhrase.AddLast(nextWords[intermediatePhrase.Last.Value]);
				else return phraseBeginning;
				phraseBeginning += " " + intermediatePhrase.Last.Value.ToString();
			}
			return phraseBeginning;
		}
	}
}