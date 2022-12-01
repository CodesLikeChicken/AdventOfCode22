using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public abstract class InputParser
    {
        public abstract List<string> InputTokens { get; }

        public virtual string ProjectRootDir
        {
            get
            {
                return "..\\..\\..\\Input\\";
            }
        }

        virtual public List<string> SplitInput(string inputLine)
        {

            var finalToken = ',';

            while (inputLine.Contains(finalToken))
            {
                finalToken++;
            }

            var tokenizedString = new StringBuilder();
            tokenizedString.Append(inputLine);
            foreach (var token in InputTokens)
            {
                tokenizedString = tokenizedString.Replace(token, finalToken.ToString());
            }

            return tokenizedString.ToString().Split(finalToken).Where(value => !string.IsNullOrEmpty(value)).ToList();
        }

        public virtual string InputFile { get; set; }

        protected List<string> InputLines;
        protected List<List<string>> InputLinesByParameter;

        public AdventBaseClass()
        {
            ParseInput();
        }

        protected virtual void ParseInput()
        {
            if (!string.IsNullOrEmpty(InputFile))
            {
                var inputStream = new StreamReader(Path.Combine(ProjectRootDir, InputFile));

                InputLines = new List<string>();
                InputLinesByParameter = new List<List<string>>();

                string inputLine;
                while ((inputLine = inputStream.ReadLine()) != null)
                {
                    InputLines.Add(inputLine);
                    InputLinesByParameter.Add(SplitInput(inputLine));
                }

                inputStream.Close();
            }
        }

        abstract public void Calculate();

        protected void PrintEstimatedCompletion(long total, long numberComplete, TimeSpan elapsedTime)
        {
            var percentDone = (double)numberComplete / total;

            var completionTime = new TimeSpan();
            for (double timeSpanIndex = 0; timeSpanIndex < 1 / percentDone; ++timeSpanIndex)
            {
                completionTime += elapsedTime;
            }

            Console.WriteLine($"{numberComplete} ({percentDone * 100}%) finished in {elapsedTime}");
            Console.WriteLine($"  {completionTime} projected total run time.\n");
        }
    }
}
