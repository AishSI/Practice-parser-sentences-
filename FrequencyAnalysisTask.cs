using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
	static class FrequencyAnalysisTask
	{
		public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> lexicon)
		{
			var bigram = GetContinuationNgram(GetFrequencyDictionaryBigram(lexicon));
			var trigram = GetContinuationNgram(GetFrequencyDictionaryTrigram(lexicon));

			var result = bigram.Concat(trigram).ToDictionary(x => x.Key, x => x.Value);
			return result;
		}

		public static Dictionary<string, Dictionary<string, int>> GetFrequencyDictionaryBigram(List<List<string>> lexicon)
		{
			var result = new Dictionary<string, Dictionary<string, int>>();
			foreach (var sentence in lexicon)
				for (int i = 0; i < sentence.Count - 1; i++)
				{
					if (!result.ContainsKey(sentence[i]))
					{
						result[sentence[i]] = new Dictionary<string, int>();
						result[sentence[i]][sentence[i + 1]] = 0;
					}
					if (!result[sentence[i]].ContainsKey(sentence[i + 1]))
						result[sentence[i]][sentence[i + 1]] = 0;

					result[sentence[i]][sentence[i + 1]]++;
				}
			return result;
		}

		public static Dictionary<string, Dictionary<string, int>> GetFrequencyDictionaryTrigram(List<List<string>> lexicon)
		{
			var result = new Dictionary<string, Dictionary<string, int>>();
			foreach (var sentence in lexicon)
				for (int i = 0; i < sentence.Count - 2; i++)
				{
					var startTrigram = sentence[i] + " " + sentence[i + 1];
					if (!result.ContainsKey(startTrigram))
					{
						result[startTrigram] = new Dictionary<string, int>();
						result[startTrigram][sentence[i + 2]] = 0;
					}
					if (!result[startTrigram].ContainsKey(sentence[i + 2]))
						result[startTrigram][sentence[i + 2]] = 0;

					result[startTrigram][sentence[i + 2]]++;
				}
			return result;
		}

		public static Dictionary<string, string> GetContinuationNgram(Dictionary<string, Dictionary<string, int>> frecuent)
		{
			var result = frecuent.ToDictionary(
				kvp => kvp.Key,
				kvp => kvp.Value
				.OrderByDescending(ikvp => ikvp.Value)
				.ThenBy(ikvp => ikvp.Key, StringComparer.Ordinal)
				.First().Key);
			return result;
		}
	}
}