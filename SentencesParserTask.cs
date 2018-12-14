using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextAnalysis
{
	public static class SentencesParserTask
	{
		public static List<List<string>> ParseSentences(string text)
		{
			var listListSentences = new List<List<string>>();

			var listSentences = text.ToLower().Split(new char[] { '.', '!', '?', ';', ':', '(', ')' })
				.Select(tag => tag.Trim())
				.Where(tag => !string.IsNullOrEmpty(tag))
				.ToList();

			foreach (var sentence in listSentences)
			{
				var words = SenteceToWords(sentence).ToString()
					.Split(new char[] { ' ' })
					.Select(tag => tag.Trim())
					.Where(tag => !string.IsNullOrEmpty(tag))
					.ToList();
				if (words.Count > 0)
					listListSentences.Add(words);
			}
			return listListSentences;
		}

		public static StringBuilder SenteceToWords(string sentence)
		{
			StringBuilder builder = new StringBuilder();
			foreach (var letter in sentence)
			{
				if ((char.IsLetter(letter) || letter == '\''))
					builder.Append(letter);
				else
					builder.Append(' ');
			}

			return builder;
		}
	}
}