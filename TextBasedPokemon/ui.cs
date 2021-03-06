using System;

namespace TextBasedPokemon
{  
   /// Console input functions with prompts and safer parsing
   public class Ui 
   {
      /// After displaying the prompt, return a line from the keyboard.
      public static string PromptLine(string prompt)
      {
         Console.Write(prompt);
         return Console.ReadLine();
      }
      
      /// Prompt the user to enter an integer until the response is legal.
      /// Return the result as in int. 
      public static int PromptInt(string prompt)
      {
         var nStr = PromptLine(prompt).Trim();
         while (!IsIntString(nStr)) {
            Console.WriteLine("Bad int format!  Try again.");
            nStr = PromptLine(prompt).Trim();
         }
         return int.Parse(nStr);
      }
                                              
      /// Prompt the user to enter a decimal value until the response 
      /// is legal.  Return the result as a double. 
      public static double PromptDouble(string prompt)
      {
         var nStr = PromptLine(prompt).Trim();
         while (!IsDecimalString(nStr)) {
            Console.WriteLine("Bad decimal format!  Try again.");
            nStr = PromptLine(prompt).Trim();
         }
         return double.Parse(nStr);
      }
                                                 
      /// Prompt the user until a keyboard entry is an int
      /// in the range [lowLim, highLim].  Then return the int value 
      /// in range.  Append the range to the prompt.
      public static int PromptIntInRange(string prompt, 
                                         int lowLim, int highLim)
      {
        string longPrompt = $"{prompt} ({lowLim} through {highLim}) ";
        var number = PromptInt(longPrompt);
        while (number < lowLim || number > highLim) {
           Console.WriteLine("{0} is out of range!", number);
           number = PromptInt(longPrompt);
        }
        return number;
      }
           
      /// Prompt the user until a keyboard entry is a decimal
      /// in the range [lowLim, highLim].  Then return the double 
      /// value in range.  Append the range to the prompt.
      public static double PromptDoubleInRange(string prompt, 
                                     double lowLim, double highLim)
      {
        var longPrompt = $"{prompt} ({lowLim} through {highLim}) ";
        var number = PromptDouble(longPrompt);
        while (number < lowLim || number > highLim) {
           Console.WriteLine("{0} is out of range!", number);
           number = PromptDouble(longPrompt);
        }
        return number;
      }
           
      /// Prompt the user with a question. 
      /// Force an understandable keyboard response;
      /// Return true of false based on the final response.  
      public static bool Agree(string question)
      {
         const string meanYes = "ytYT";
          const string meanNo = "nfNF";
          const string validResponses = meanYes + meanNo;
          var answer = PromptLine(question);
         while (answer.Length == 0 ||
                !validResponses.Contains(""+answer[0])) {
            Console.WriteLine("Enter y or n!");
            answer = PromptLine(question);
         }
         return meanYes.Contains(""+answer[0]);
      }
      
      // helper string testing functions
      
      /// True when s consists of only 1 or more digits.
      public static bool IsDigits(string s)
      {
         foreach( var ch in s) {
            if (ch <'0' || ch > '9') {
               return false;
            }
			}
         return (s.Length > 0);
      }

      /// True if s is the string form of an integer. 
      public static bool IsIntString(string s)
      {
         if (s.StartsWith("-")) {
            s = s.Substring(1);
         }
         return IsDigits(s);
      }

      /// Return true if s represents a decimal string. 
      public static bool IsDecimalString(string s)
      {
         if (s.StartsWith("-")) {
            s = s.Substring(1);
         }
         var i = s.IndexOf(".", StringComparison.Ordinal);
         if (i >= 0) {
            s = s.Substring(0,i) + s.Substring(i+1);
         }
         return IsDigits(s);
      }   

   }
}
