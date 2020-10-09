using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoopPractice.Controllers
{
    public class LoopPracticeController : ApiController
    {

        /// <summary>
        /// Counts from One to Value
        /// </summary>
        /// <param name="Value">Number to count to</param>
        /// <returns>string of numbers deliminated with "," which count from one to {Value}.</returns>
        /// <example>
        /// GET api/LoopPractice/OneToValue/4 ->
        /// "1,2,3,4"
        /// </example>
        /// /// <example>
        /// GET api/LoopPractice/OneToValue/8 ->
        /// "1,2,3,4,5,6,7,8"
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/OneToValue/{Value}")]
        public string OneToValue(int Value)
        {
            int counter = 1;
            string message = "";
            while (counter <= Value)
            {
                message = message + counter.ToString() + ",";
                counter = counter + 1;
            }
            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});

            return message;
        }

        /// <summary>
        /// Counts from Ten to Thirty.
        /// </summary>
        /// <returns>A string of numbers deliminated by "," which count from Ten to Thirty.</returns>
        /// <example>
        /// GET : api/LoopPractice/TenToThirty
        /// "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30"
        /// </example>
        [HttpGet]
        public string TenToThirty()
        {
            string message = "";

            for (int counter = 10; counter<=30; counter = counter + 1)
            {
                message = message + counter + ",";
            }
            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});

            return message;
        }

        /// <summary>
        /// Counts from {start} to {end}
        /// </summary>
        /// <param name="start">The starting number</param>
        /// <param name="end">The ending number</param>
        /// <returns>A string of numbers deliminated by ",". The numbers will count up if {start} is less than {end}, will count down if {start} is greater than {end}</returns>
        /// <example>
        /// GET : api/LoopPractice/ValueToValue/5/8 ->
        /// "5,6,7,8,"
        /// </example>
        /// <example>
        /// GET : api/LoopPractice/ValueToValue/8/5 ->
        /// "8,7,6,5,"
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/ValueToValue/{start}/{end}")]
        public string ValueToValue(int start, int end)
        {
            string message = "";
            //Counting up from {start} to {end}
            if (start < end) 
            {
                while (start <= end)
                {
                    message = message + start + ",";
                    start = start + 1;
                }
            }
            //Count down from {start} to {end}
            else
            {
                while (start >= end)
                {
                    message = message + start + ",";
                    start = start - 1;
                }

            }
            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});

            return message;

        }

        /// <summary>
        /// Prints a list of favorite snacks stored in a List<string>
        /// </summary>
        /// <returns>A string of snacks deliminated by ",".</returns>
        /// <example>
        /// GET : api/LoopPractice/FavoriteSnacks ->
        /// "Blackberries, Almonds, Sunflower Seeds, Strawberries, Chips,"
        /// </example>
        [HttpGet]
        public string FavoriteSnacks()
        {
            //Array of Strings
            List<string> Snacks = new List<string>{"Blackberries","Almonds","Sunflower Seeds" };

            Snacks.Add("Strawberries");
            Snacks.Add("Chips");

            string message = "";

            foreach(string Snack in Snacks)
            {
                message = message + Snack + ",";

            }
            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});

            return message;
        }

        /// <summary>
        /// Counts from -5 to -20
        /// </summary>
        /// <returns>a string of comma deliminated values from -5 to -20</returns>
        /// <example>
        /// GET : api/LoopPractice/MinusFiveToMinusTwenty ->
        /// "-5,-6,-7,-8,-9,-10,-11,-12,-13,-14,-15,-16,-17,-18,-19,-20,"
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/MinusFiveToMinusTwenty")]
        public string MinusFiveToMinusTwenty()
        {
            string message = "";
            int counter = -5;

            while (counter >= -20)
            {
                message = message + counter.ToString();

                counter = counter - 1;
            }

            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});

            return message;
        }

        /// <summary>
        /// Prints a string of numbers from -10 to 10 counting by {step}
        /// </summary>
        /// <param name="step"></param>
        /// <returns>A string of numbers deliminated by ","</returns>
        /// <example>
        /// GET : api/LoopPractice/MinusTenToTen/3
        /// "-10,-7,-4,-1,2,5,8,"
        /// </example>
        /// <example>
        /// GET : api/LoopPractice/MinusTenToTen/2
        /// "-10,-8,-6,-4,-2,0,2,4,6,8,10,"
        /// </example>
        /// <example>
        /// GET : api/LoopPractice/MinusTenToTen/-5
        /// "Invalid Step. Must be greater than 0."
        /// </example>
        [Route("api/LoopPractice/MinusTenToTen/{step}")]
        [HttpGet]
        public string MinusTenToTen(int step)
        {
            string message = "";
            //start off with 

            //how long do we want to stay in the loop?

            if (step >= 1)
            {
                for (int i = -10; i <= 10; i = i + step)
                {
                    message = message + i.ToString() + ",";
                }
            }
            else
            {
                message = "Invalid Step. Must be greater than 0.";
            }

            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});
            return message;
        }

        /// <summary>
        /// Prints a string of colors of Colors using a Colors array.
        /// </summary>
        /// <returns>A string of colors deliminated by ","</returns>
        /// <example>
        /// GET : api/LoopPractice/ListColors   ->
        /// "Green,Blue,Purple,"
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/ListColors")]
        public string ListColors()
        {
            string message = "";
            string[] colors = new string[] { "Green", "Blue", "Purple" };

            

            foreach (string color in colors)
            {
                message = message + color + ",";

            }
            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});
            return message;
        }


        
        /// <summary>
        /// Splits a message string character by character 
        /// </summary>
        /// <param name="message">string message to split</param>
        /// <returns>A string of characters deliminated by ","</returns>
        /// <example>
        /// GET : api/LoopPractice/SplitString/Hello There  ->
        /// "H,e,l,l,o, ,T,h,e,r,e,"
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/SplitString/{message}")]
        public string SplitString(string message)
        {
            string output = "";
            //char is a data type for a single character.
            foreach(char m in message)
            {
                output = output + m + ",";
            }
            //Include below line to remove trailing ',' character.
            //output = output.Trim(new char[] {','});
            return output;
        }

        /// <summary>
        /// Counts from {start} to {step} by {limit}
        /// </summary>
        /// <param name="start">The starting position</param>
        /// <param name="limit">The limit, either upper limit or lower limit</param>
        /// <param name="step">The value to increment by per loop iteration</param>
        /// <returns>A list of integers which represent counting from {start} to {limit} by {step}</returns>
        /// <example>
        /// GET: api/LoopPractice/CounterList/0/4/1		->	[0,1,2,3,4]
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterList/-10/30/10		->	[-10,0,10,20,30]
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterList/-10/-17/2		->	[0]
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterList/-10/-17/-2	->	[-10,-12,-14,-16]
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/Counter/{start}/{limit}/{step}")]
        public IEnumerable<int> CounterList(int start, int limit, int step)
        {
            bool isIncreasing = (start < limit) && (step > 0);
            bool isDecreasing = (start > limit) && (step < 0);

            List<int> Steps = new List<int>();

            //prevent an invalid loop.
            if (!isIncreasing || !isDecreasing)
            {
                Steps.Add(0);
            }
            else
            {
                for (int i = start; i <= limit; i += step)
                {
                    Steps.Add(i);
                }
            }
            return Steps;
        }

        /// <summary>
        /// Counts from {start} to {step} by {limit}
        /// </summary>
        /// <param name="start">The starting position</param>
        /// <param name="limit">The limit, either upper limit or lower limit</param>
        /// <param name="step">The value to increment by per loop iteration</param>
        /// <returns>A string of comma deliminated integers represent counting from {start} to {limit} by {step}</returns>
        /// <example>
        /// GET: api/LoopPractice/CounterString/0/4/1		->	"0,1,2,3,4,"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterString/-10/30/10		->	"-10,0,10,20,30,"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterString/-10/-17/2		->	"0"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterString/-10/-17/-2	->	"-10,-12,-14,-16,"
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/Counter/{start}/{limit}/{step}")]
        public string CounterString(int start, int limit, int step)
        {
            bool isIncreasing = (start <= limit) && (step > 0);
            bool isDecreasing = (start >= limit) && (step < 0);

            string message = "";

            //prevent an invalid loop.
            if (!isIncreasing && !isDecreasing)
            {
                message = "0";
            }
            else
            {
                //begin at {start}; continue until {limit}; increment by {step}
                for (int i = start; i <= limit; i += step)
                {
                    message += i.ToString() + ",";
                }
            }
            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});
            return message;
        }

        /// <summary>
        /// a string which counts from {start} to {limit} counting by {step} with FizzBuzz rules applied.
        /// </summary>
        /// <param name="start">The starting position</param>
        /// <param name="limit">The limit, either upper limit or lower limit</param>
        /// <param name="step">The value to increment by per loop iteration</param>
        /// <param name="fizzy">The "Fizzy" number, which will be compared for divisibility.</param>
        /// <param name="buzzy">The "Buzzy" number, which will be compared for divisibility.</param>
        /// <returns>A comma deliminated string of integers, representing how to count from {start} to {limit} by {step}. Integers divisible by {fizzy} are replaced with "Fizzy". Integers divisible by {buzzy} are divisible by "Buzzy". Integers divisible by both {fizzy} AND {buzzy} are replaced with "FizzyBuzzy".</returns>
        /// <example>
        /// GET: api/LoopPractice/FizzyBuzzy/1/25/4/3/7 
        /// ->   "1,5,Fizzy,13,17,FizzyBuzzy,25"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/FizzyBuzzy/1/4/1/1/4
        /// ->	"Fizzy, Fizzy, Fizzy, FizzyBuzzy"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/FizzyBuzzy/2/15/4/3/4
        ///->	"2,Fizzy,10,14"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/FizzyBuzzy/10/60/12/200/200
        ///->	"10,22,34,46,58"
        /// </example>
        /// <example>
        /// GET:  api/LoopPractice/FizzyBuzzy/-40/-20/3/-2/-5
        ///->	"FizzyBuzzy,-37,Fizzy,-31,Fizzy,Buzzy,Fizzy"
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/FizzyBuzzy/{start}/{limit}/{step}/{fizzy}/{buzzy}")]
        public string FizzyBuzzy(int start, int limit, int step, int fizzy, int buzzy)
        {
            string message = "";

            bool isIncreasing = (start <= limit) && (step > 0);
            bool isDecreasing = (start >= limit) && (step < 0);

            //prevent an invalid loop.
            if (!isIncreasing && !isDecreasing)
            {
                message = "0";
            }
            else
            {
                //begin at {start}; continue until {limit}; increment by {step}
                for (int i = start; i <= limit; i += step)
                {
                    bool isFizzy = (i % fizzy) == 0;
                    bool isBuzzy = (i % buzzy) == 0;
                    if (isFizzy && isBuzzy) message += "FizzyBuzzy,";
                    else if (isFizzy) message += "Fizzy,";
                    else if (isBuzzy) message += "Buzzy,";
                    else message += i.ToString() + ",";
                }
            }
            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});
            

            return message;
        }

        /// <summary>
        /// Lists the minimum required Canadian denominations of $20 or less to arrive at {amount}
        /// </summary>
        /// <param name="amount">The amount to provide minimum change for.</param>
        /// <returns>A list of strings describing the minimum number of bills and coins needed to achieve the {amount}.</returns>
        /// <example>
        /// GET : api/LoopPractice/GetChange/100.23/
	    /// ->	["Twenties : 5","Dimes : 2", "Pennies : 3"]
        /// </example>
        /// <example>
        /// GET : api/LoopPractice/GetChange/13.68/	
        ///->	["Tens : 1","Toonies : 1","Loonies : 1","Quarters : 2", "Dimes : 1","Nickels : 1","Pennies : 3"]
        /// </example>
        [HttpGet]
        [Route("api/LoopPractice/GetChange/{amount}")]
        public List<string> GetChange(decimal amount)
        {
            decimal twentyValue = 20.00M;
            int twenties = 0;
            decimal tenValue = 10.00M;
            int tens = 0;
            decimal fiveValue = 5.00M;
            int fives = 0;
            decimal toonieValue = 2.00M;
            int toonies = 0;
            decimal loonieValue = 1.00M;
            int loonies = 0;
            decimal quarterValue = 0.25M;
            int quarters = 0;
            decimal dimeValue = 0.10M;
            int dimes = 0;
            decimal nickelValue = 0.05M;
            int nickels = 0;
            decimal pennyValue = 0.01M;
            int pennies = 0;

            List<string> denominations = new List<string>();

            //return an empty list if the amount is invalid.
            //can be invalid if {amount} is less than 0 or has more than 2 decimal places.
            if(amount<=0 || (Math.Round(amount,2) != amount))
            {
                return denominations;
            }

            while ((amount - twentyValue) >= 0)
            {
                amount = amount - twentyValue;
                twenties++;
            }
            while ((amount - tenValue) >= 0)
            {
                amount = amount - tenValue;
                tens++;
            }
            while ((amount - fiveValue) >= 0)
            {
                amount = amount - fiveValue;
                fives++;
            }
            while ((amount - toonieValue) >= 0)
            {
                amount = amount - toonieValue;
                toonies++;
            }
            while ((amount - loonieValue) >= 0)
            {
                amount = amount - loonieValue;
                loonies++;
            }
            while((amount - quarterValue) >= 0)
            {
                amount = amount - quarterValue;
                quarters++;
            }
            while ((amount - dimeValue) >=0)
            {
                amount = amount - dimeValue;
                dimes++;
            }
            while ((amount - nickelValue) >= 0)
            {
                amount = amount - nickelValue;
                nickels++;
            }
            while ((amount - pennyValue) >= 0)
            {
                amount = amount - pennyValue;
                pennies++;
            }

            

            if (twenties > 0) denominations.Add("Twenties : "+twenties);
            if (tens > 0) denominations.Add("Tens : " + tens);
            if (fives > 0) denominations.Add("Fives : " + fives);
            if (toonies > 0) denominations.Add("Toonies : " + toonies);
            if (loonies > 0) denominations.Add("Loonies : " + loonies);
            if (quarters > 0) denominations.Add("Quarters : " + quarters);
            if (nickels > 0) denominations.Add("Nickels : " + nickels);
            if (dimes > 0) denominations.Add("Dimes : " + dimes);
            if (pennies > 0) denominations.Add("Pennies : " + pennies);

            return denominations;

        }

    }
}
