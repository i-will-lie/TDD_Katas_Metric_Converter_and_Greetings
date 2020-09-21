using System;
using System.Collections.Generic;
using System.Text;

namespace Domain._01_TDD.Greetings
{
    public class Greeting
    {
        

        public string Greet(string name)
        {
            if(name == null)
            {
                return GreetFriend();
            }
            return GreetName(name);
           /* else if(
                name.GetType() == typeof(string)) {
               
            }
            else
            {
                return GreetFriends(names);
            }*/
        }



        public string GreetFriend()
        {
            return "Hello, my friend.";
        }

        //private static greet


        public string GreetName(string name)
        {
            var hello = StringUtil.IsAllUpper(name) ? "HELLO" : "Hello";
            return $"{hello}, {name}.";
        }


        public string Greet(List<string> names)
        {
            if(names == null)
            {
                return GreetFriend();
            }
            if(names.Count == 0)
            {
                return GreetFriend();
            }
            var splitNames = HandleSplitNames(names);
            var (normalNames, upperNames) = StringUtil.SplitNormalCaseAndUpper(splitNames);

            var greeting = "";
            if(normalNames.Count > 0)
            {
                greeting += BuildGreeting(normalNames, false);
            }

            if (upperNames.Count > 0)
            {
                if (normalNames.Count > 0)
                {
                    greeting += " AND ";
                }

                greeting += BuildGreeting(upperNames, true);
            }
            return greeting;

          
   

        }

        private string BuildGreeting(List<string> names, bool isUpper)
        {
            if(names.Count == 0)
            {
                return "";
            }

            string greeting = isUpper ? "HELLO" : "Hello";

            // add first name
            greeting += $", {names[0]}";

            // add middle names
            int i = 1;
            for (; i < names.Count - 1; i++) //stops at penultimate name. Last name will need "and" before it
            {
                greeting += $", {names[i]}";
            }

            // add final name if not added already
            // append "and" if there is another name remaing after loop
            if(i < names.Count)
            {
                var and = isUpper ? "AND" : "and";
                greeting += $" {and} {names[names.Count-1]}";
            }
          
               greeting += isUpper?"!":".";
    

            return greeting;
        }

        private List<string> HandleSplitNames(List<string> names)
        {
            var splitNames = new List<string>();
            foreach(var name in names)
            {
                if (StringUtil.HasComma(name) && !StringUtil.HasQuoteMarks(name))
                {
                  
                        foreach (string splitName in StringUtil.SplitByComma(name))
                        {
                            splitNames.Add(splitName.Trim());
                        }
              
                 
                }
                else
                {
                    splitNames.Add(name.Trim('\"'));
                }
            }
            return splitNames;
        }
    }
}
