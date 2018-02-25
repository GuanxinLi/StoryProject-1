using System; 

using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models; 
using System.Collections.Generic;

namespace CSharp
{

	// A public object class for the story line
	public class StoryLine {
		public string[] languageResult, keywordResult;
		public double[] sentimentResult;

		public StoryLine(string[] languageResult, string[] keywordResult, double[] sentimentResult) {
			this.languageResult = languageResult;
			this.keywordResult = keywordResult;
			this.sentimentResult = sentimentResult;
		}
	}


    public static class Story
    {
        static void Main(string[] args)
        {
        	string inputString = "I live in HongKong for nine years now. After that, I went to UCSD for college. I miss food from hometown.";
            //Story myStory = new Story();
            StoryLine myStory = createStory(inputString);
            string[] test = myStory.keywordResult;
            foreach(var key in test) {
            	Console.WriteLine(key);
            }


        }


        public static StoryLine createStory(string userInput) 
        {

            // Create a client.
            ITextAnalyticsAPI client = new TextAnalyticsAPI();
            client.AzureRegion = AzureRegions.Westus;
            client.SubscriptionKey = "49bd3a3a1a244fd289aa30b7a5594b05";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Extracting language
            Console.WriteLine("===== LANGUAGE EXTRACTION ======");

            // CALLING TAMMY's FUNCTION TO GET THE USER INPUT STRING


            string inputString = "I live in HongKong for nine years now. After that, I went to UCSD for college. I miss food from hometown.";
            // Split each line according to period. Afterr the speech ends, return an empty string.
            string [] singleLine  = inputString.Split('.');
            string [] keyWordResult = new string[singleLine.Length];
            double [] sentimentResult = new double[singleLine.Length];

            List<Input> inputLine = new List<Input>();
            int count = 0;
            foreach(var line in singleLine) {
            	//Console.WriteLine($"<{line}>");
            	inputLine.Add(new Input(count.ToString(),line));
            	count++;
            }


            string[] languages = new string[inputLine.Count];
            LanguageBatchResult result = client.DetectLanguage(
                    new BatchInput( 
                    	inputLine
                        ));

            // Updating language results.
            count = 0;
            foreach (var document in result.Documents)
            {
                //Console.WriteLine("Document ID: {0} , Language: {1}", document.Id, document.DetectedLanguages[0].Iso6391Name);
            	languages[count] = document.DetectedLanguages[0].Iso6391Name;
            	count++;
            }

            // Getting key-phrases
            Console.WriteLine("\n\n===== KEY-PHRASE EXTRACTION ======");
            int languageCount = 0;
            count = 0;
            List<MultiLanguageInput> inputKeywordLine = new List<MultiLanguageInput>();
            foreach(var key in singleLine) {
            	//Console.WriteLine("The language is: {0}, The count is {1}, the key is {2}", languages[languageCount], count.ToString(),key);	
            	inputKeywordLine.Add(new MultiLanguageInput(languages[languageCount], count.ToString(),key));
            	count++;
            }

            KeyPhraseBatchResult result2 = client.KeyPhrases(
                    new MultiLanguageBatchInput(
                    	inputKeywordLine
                        ));


            // Printing keyphrases
            foreach (var document in result2.Documents)
            {

                //Console.WriteLine("Document ID: {0} ", document.Id);
                //Console.WriteLine("\t Key phrases: {0}", document.KeyPhrases[0]);

                keyWordResult[Int32.Parse(document.Id)] = document.KeyPhrases[0];
                //Console.WriteLine(keyWordResult[Int32.Parse(document.Id)]);
/*
                foreach (string keyphrase in document.KeyPhrases)
                {
                    Console.WriteLine("\t\t" + keyphrase);
                }
                */
            }

            // Extracting sentiment
            Console.WriteLine("\n\n===== SENTIMENT ANALYSIS ======");

            SentimentBatchResult result3 = client.Sentiment(
                    new MultiLanguageBatchInput(
                    	inputKeywordLine
                    	/*
                        new List<MultiLanguageInput>()
                        {
                          new MultiLanguageInput("en", "1", "I live in HongKong for nine years now."),
                          new MultiLanguageInput("en", "2", "After that, I went to UCSD for college."),
                          new MultiLanguageInput("en", "3", " I miss food from hometown."),
                         }*/
                         ));


            // Printing sentiment results
            foreach (var document in result3.Documents)
            {
            	sentimentResult[Int32.Parse(document.Id)] = Convert.ToDouble(document.Score);
            	//Console.WriteLine(sentimentResult[Int32.Parse(document.Id)]);
            }

        return new StoryLine(languages, keyWordResult, sentimentResult);
        }
    }
}
