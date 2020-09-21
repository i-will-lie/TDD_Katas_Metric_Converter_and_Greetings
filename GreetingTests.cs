using NUnit.Framework;
using System.Collections.Generic;
using Domain._01_TDD.Greetings;
using FluentAssertions;

namespace Specs.Unit._01_TDD
{
    [TestFixture]
    public class GreetingTests
    {
        private Greeting _greeting;

        [SetUp]
        public void Initialise_greeting_instance()
        {
            _greeting = new Greeting();
        }

        [Test]
        public void Greeting_with_single_name_should_greet_with_name()
        {
            var name = "bob";
            var expectedGreet = $"Hello, {name}.";

            var actualGreet = _greeting.Greet(name);

            actualGreet.Should().Be(actualGreet);

        }
      
        [Test]
        public void Greeting_with_null_list_of_null_names_shoudld_greet_with_friend_placeholder()
        {
            var expectedGreet = $"Hello, my friend.";
            var actualGreet = _greeting.Greet((List<string>)null); 

           expectedGreet.Should().Be(actualGreet);

        }

        [Test]
        public void Greeting_with_null_name_shoudld_greet_with_friend_placeholder()
        {
            var expectedGreet = $"Hello, my friend.";
            var actualGreet = _greeting.Greet((string)null);

            expectedGreet.Should().Be(actualGreet);

        }

        [Test]
        public void Greeting_with_uppercase_name_should_greet_with_uppercase_hello_and_name()
        {
            var name = "BOB";
            var expectedGreet = $"HELLO, {name}.";

            var actualGreet = _greeting.Greet(name);

            expectedGreet.Should().Be(actualGreet);
        }


        [Test]
        public void Greeting_with_two_names_should_greet_with_and_between_last_and_penultimate_name()
        {
            var names = new List<string> { "Ann", "Bob" };
            
            var expectedGreet = $"Hello, {names[0]} and {names[1]}.";

            var actualGreet = _greeting.Greet(names);

            expectedGreet.Should().Be(actualGreet);
        }


        [Test]
        public void Greeting_with_three_names_should_greet_with_and_between_last_and_penultimate_name()
        {
            var names = new List<string> { "Ann", "Bob", "Charlie" };

            var expectedGreet = $"Hello, {names[0]}, {names[1]} and {names[2]}.";

            var actualGreet = _greeting.Greet(names);

            expectedGreet.Should().Be(actualGreet);
        }


        [Test]
        public void Greeting_with_mixed_case_names_should_greet_lowercase_names_then_uppercase_names()
        {
            var names = new List<string> { "Ann", "BOB" ,"Charlie" ,"DEAN" };

        var expectedGreet = $"Hello, {names[0]} and {names[2]}. AND HELLO, {names[1]} AND {names[3]}!";

        var actualGreet = _greeting.Greet(names);


            expectedGreet.Should().Be(actualGreet);
        }



        [Test]
        public void Greeting_with_unplit_names_should_split_name_and_greet_as_per_usual()
        {
            var names = new List<string> { "Ann, BOB", "Charlie", "DEAN" };
            var splitNames = names[0].Split(",");

            var expectedGreet = $"Hello, {splitNames[0]} and {names[1]}. AND HELLO, {splitNames[1].Trim()} AND {names[2]}!";

            var actualGreet = _greeting.Greet(names);


            expectedGreet.Should().Be(actualGreet);
        }


        [Test]
        public void Quotes_around_unsplit_names_should_prevent_names_from_being_split()
        {


            var names = new List<string>() { "Bob", "\"Charlie, Dianne\"" };

            var expectedGreet = $"Hello, Bob and Charlie, Dianne.";

            var actualGreet = _greeting.Greet(names);


            expectedGreet.Should().Be(actualGreet);

        }
    }
}

