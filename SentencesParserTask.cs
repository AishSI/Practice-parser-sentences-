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
			var listSentences = text.ToLower().Split(new char[] { '.', '!', '?', ';', ':', '(', ')' })
				.Select(tag => tag.Trim())
				.Where(tag => !string.IsNullOrEmpty(tag))
				.ToList();
			return GoListListSentences(listSentences);
		}

		//составляем список списков: по каждому предложению отдельный список слов
		public static List<List<string>> GoListListSentences(List<string> listSentences)
		{
			var listListSentences = listSentences
			.Select(sentences => SenteceToWords(sentences)
			.Split(new char[] { ' ' })
			.Select(tag => tag.Trim())
			.Where(tag => !string.IsNullOrEmpty(tag))
			.ToList()).ToList();
			return listListSentences;
		}

		// убираем в предложениях все небуквенные символы оставляем только слова (включая символ ' ) и пробелы
		public static string SenteceToWords(string sentence)
		{
			return new string(sentence
			.Select(ch => (char.IsLetter(ch) || ch == '\'') ? ch : ' ').ToArray());
		}
	}
}